using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using LabPI.Models;

namespace LabPI.Controllers
{
    public class AccountController : Controller
    {
        User user = null;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);

                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
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
                User user = new User();
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Login == model.Login);
                }
                if (user == null)
                {
                    using (UserContext db = new UserContext())
                    {
                        db.Users.Add(new User { Login = model.Login, Name = model.Name, Email = model.Email, Password = model.Password, RoleId = 2 });
                        db.SaveChanges();

                        user = db.Users.Where(u => u.Login == model.Login && u.Password == model.Password).FirstOrDefault();
                    }
                    if (user != null)
                    {
                        // FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [ChildActionOnly]
        public PartialViewResult UserL()
        {
            return PartialView("~/Views/Account/UserL.cshtml");
        }
    }
}