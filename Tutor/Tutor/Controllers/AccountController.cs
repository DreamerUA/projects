using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using Tutor.Interfaces;
using Tutor.Core;
using Tutor.Core.Entities;
using System.Web;
using System.IO;

namespace Tutor.Controllers
{
    public class AccountController : Controller
    {
        IUserRepository userRepo;
        IUserInfoRepository infoRepo;
        ISkillRepository skillRepo;
        IUniversalRepository universalRepo;
        IReviewRepository reviewRepo;
        public AccountController(IUserRepository user, IUserInfoRepository info, ISkillRepository skill, IUniversalRepository universal, IReviewRepository review)
        {
            skillRepo = skill;
            userRepo = user;
            infoRepo = info;
            reviewRepo = review;
            universalRepo = universal;
        }
        public ActionResult Index()
        {
            return View(userRepo.GetUserList());
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                User user = null;

                user = userRepo.Login(model.Login, model.Password);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    Session["UserId"] = user.UserId.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;

                user = userRepo.Register(model.Login, model.Email);
                if (user == null)
                {
                    // создаем нового пользователя
                    userRepo.Create(new User { Login = model.Login, Password = model.Password, Email = model.Email, RoleId = 2 });
                    userRepo.Save();

                    user = userRepo.Login(model.Login, model.Password);

                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Login, true);
                        return RedirectToAction("CreateInfo", "Account");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с такими данными уже существует");
                }
            }
            return View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult CreateInfo()
        {
            ViewBag.UserId = userRepo.GetUserByLogin(User.Identity.Name).UserId;
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreateInfo(UserInfo model, HttpPostedFileBase file)
        {
            const string pathToSave = "/Upload/Images/";
           
                if (file != null)
                {
                    var filename = file.FileName;
                    var filePathOriginal = Server.MapPath(pathToSave);
                    string savedFileName = Path.Combine(filePathOriginal, filename);
                    file.SaveAs(savedFileName);
                    model.ImagePath = Path.Combine(pathToSave,filename);
                   
                }
                else {
                    model.ImagePath = "/Upload/Images/default.jpg";
                }
            
                infoRepo.Create(new UserInfo(model));
                infoRepo.Save();
                ViewBag.Add = "Info create";
                return RedirectToAction("UserPage", new { Id = model.UserId });
            
            ViewBag.UserId = userRepo.GetUserByLogin(User.Identity.Name).UserId;
            return View();
        }

        [Authorize]
        public ActionResult GetUserPage()
        {
            UserInfo i = infoRepo.GetUserInfoByLogin(User.Identity.Name);
            ReviewModel r = reviewRepo.GetAllCommentsByUserId(i.UserId);
            ViewBag.Login = User.Identity.Name;
            return View("~/Views/Account/UserPage.cshtml", new UserPageModel { comments = r, info = i,user=userRepo.GetUserByLogin(User.Identity.Name), Summaries =universalRepo.GetRandomSummaries()});
        }
        public ActionResult UserPage(int Id)
        {
            ReviewModel r = reviewRepo.GetAllCommentsByUserId(Id);
            UserInfo i = infoRepo.GetUserInfoByUserId(Id);
            ViewBag.Login = userRepo.GetUserById(Id).Login;
            return View(new UserPageModel { comments = r, info = i,user = userRepo.GetUserById(Id),Summaries = universalRepo.GetRandomSummaries() });
        }
        [Authorize]
        public ActionResult EditUser(int id)
        {
            UserInfo info = infoRepo.GetUserInfoByUserId(id);
            if (info == null)
            {
                return HttpNotFound();
            }
            return View(new EditUserModel { userInfo = info, skillList = skillRepo.GetList() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult EditUser(UserInfo info, HttpPostedFileBase file)
        {

            const string pathToSave = "/Upload/Images/";
            if (file != null)
            {
                var filename = file.FileName;
                var filePathOriginal = Server.MapPath(pathToSave);
                string savedFileName = Path.Combine(filePathOriginal, filename);
                file.SaveAs(savedFileName);
                info.ImagePath = Path.Combine(pathToSave, filename);

            }
            else
            {
                info.ImagePath = "/Upload/Images/default.jpg";
            }           
                infoRepo.Update(info);
                infoRepo.Save();

            ViewBag.IsEdit = "CHANGED";
            return View(new EditUserModel { userInfo = info, skillList = skillRepo.GetList() });
        }

        public ActionResult DeleteSkill(int id)
        {
            DeleteSkillModel m = new DeleteSkillModel { SkillId = id, Id = userRepo.GetUserByLogin(User.Identity.Name).UserId };
            infoRepo.DeleteSkillInfo(m);
            infoRepo.Save();
            //return RedirectToAction("UserSkill");
            return RedirectToAction("EditUser", new { id = userRepo.GetUserByLogin(User.Identity.Name).UserId });
        }
        //Создаем и добавляем скилл текущему пользователю
        public ActionResult CreateSkill(string name)
        {
            Skill skill = new Skill { Name = name };
            Skill s = skillRepo.GetSkillByName(name);
            if (s != null)
            {
                //добавить ViewBag в пердставление
                ViewBag.IsAdded = "Такое умение уже есть, вопользуйтесь поиском";
                return RedirectToAction("UserSkill");
            }
            UserInfo user = infoRepo.GetUserInfoByLogin(User.Identity.Name);
            user.Skills.Add(skill);
            infoRepo.Save();
            skillRepo.Save();
            return RedirectToAction("UserSkill");
        }
        [HttpPost]
        public ActionResult AddSkill(string SkillId)
        {
            Skill skill = universalRepo.GetSkillById(Convert.ToInt32(SkillId));
            UserInfo user = universalRepo.GetUserInfoByLogin(User.Identity.Name);
            skill.Users.Add(user);
            user.Skills.Add(skill);
            universalRepo.Save(true);

            return RedirectToAction("UserSkill");
        }
        public ActionResult UserSkill()
        {
            ICollection<Skill> data = infoRepo.GetUserInfoByLogin(User.Identity.Name).Skills;
            return PartialView(data);
        }

    }
}
