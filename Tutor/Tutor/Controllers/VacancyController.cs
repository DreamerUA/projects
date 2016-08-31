using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tutor.Core;
using Tutor.Core.Entities;
using Tutor.Interfaces;


namespace Tutor.Web.Controllers
{
    public class VacancyController : Controller
    {
        IUserRepository userRepo;
        IUniversalRepository universalRepo;
        IUserInfoRepository infoRepo;
        IVacancyRepository vacancyRepo;
        ISkillRepository skillRepo;
        public VacancyController(IVacancyRepository vacancy, IUniversalRepository univers, IUserRepository user, ISkillRepository skill, IUserInfoRepository info)
        {
            skillRepo = skill;
            infoRepo = info;
            vacancyRepo = vacancy;
            userRepo = user;
            universalRepo = univers;
        }

        public ActionResult DeleteVacancy(int id)
        {
            Vacancy vac = vacancyRepo.GetVacancyById(id);
            vacancyRepo.Delete(id);
            vacancyRepo.Save();
            return RedirectToAction("UserVacancies");
        }
        // GET: Vacancy
        public ActionResult Index()
        {
            return View(universalRepo.GetVacancyList());
        }
        public ActionResult AddVacancy()
        {
            ViewBag.UserId = userRepo.GetUserByLogin(User.Identity.Name).UserId;
            return View();
        }
        [HttpPost]
       public ActionResult AddVacancy(Vacancy model)
        {
            if (ModelState.IsValid)
            {
                vacancyRepo.Create(model);
                vacancyRepo.Save();
                return RedirectToAction("EditVacancy",new { id = model.VacancyId });
            }
            ViewBag.UserId = userRepo.GetUserByLogin(User.Identity.Name).UserId;
            return View();
        }

        [HttpGet]
        public ActionResult EditVacancy(int id)
        {
            return View(new EditVacancyModel { Vacancy = vacancyRepo.GetVacancyById(id), Skills = universalRepo.GetList()});
        }
        [HttpPost]
        public ActionResult EditVacancy(Vacancy model)
        {
            if (ModelState.IsValid)
            {
                vacancyRepo.Update(model);
                vacancyRepo.Save();
            }
            ViewBag.IsEdit = "CHANGED";
            return View(new EditVacancyModel { Vacancy = model, Skills = universalRepo.GetList() });
        }   
        //  добавить ViewBag.Add
        public ActionResult UserVacancies()
        {
            return View(vacancyRepo.GetVacancyListByLogin(User.Identity.Name));
        }
        public ActionResult VacancyPage(int id)
        {
            Vacancy vac = vacancyRepo.GetVacancyById(id);
            ICollection <SummaryPageModel> l= universalRepo.AutoCompleteSummary(vac).ToList(); ;
            return View(new NewVacancyPageModel { Vacancy = vac, Owner = infoRepo.GetUserInfoByUserId(vac.UserId), Summaries =  l.ToList() });
        }
        
        public ActionResult DeleteSkill(int id, int vacId)
        {
            DeleteSkillModel m = new DeleteSkillModel { SkillId = id, Id = vacId};
            vacancyRepo.DeleteSkillVacancy(m);
            vacancyRepo.Save();
            //return RedirectToAction("UserSkill");
            return RedirectToAction("EditVacancy", new { id = vacId });
        }
        //Создаем и добавляем скилл текущему пользователю
        public ActionResult CreateSkill(string name, int vacancyId)
        {
            Skill skill = new Skill { Name = name };
            Skill s = skillRepo.GetSkillByName(name);
            if (s != null)
            {
                //добавить ViewBag в представление
                ViewBag.IsAdded = "Такое умение уже есть, вопользуйтесь поиском";
                return RedirectToAction("VacancySkill", new {vacId = vacancyId });
            }
            Vacancy vac = vacancyRepo.GetVacancyById(vacancyId);
            vac.Skills.Add(skill);
            vacancyRepo.Save();
            skillRepo.Save();
            return RedirectToAction("VacancySkill", new { vacId = vacancyId });
        }
        [HttpPost]
        public ActionResult AddSkill(string SkillId, int vacancyId)
        {
            Skill skill = universalRepo.GetSkillById(Convert.ToInt32(SkillId));
            Vacancy vac = universalRepo.GetVacancyById(vacancyId);
            skill.Vacancys.Add(vac);
            vac.Skills.Add(skill);
            universalRepo.Save(true);

            return RedirectToAction("VacancySkill", new { vacId = vacancyId });
        }
        public ActionResult VacancySkill(int vacId)
        {
            ViewBag.VacId = vacId;
            return PartialView(vacancyRepo.GetVacancyById(vacId).Skills);
        }
        public IEnumerable<VacancyPageModel> RandomVacancy()
        {

            return vacancyRepo.GetRandomVacancy(3);
        }

        public ActionResult Search()
        {
            return View(skillRepo.GetList());
        }
        [HttpPost]
        public ActionResult Search(SearchWorkModel model, int[] skills)
        {
            return View("~/Views/Vacancy/SearchResult.cshtml",universalRepo.SearchVacancy(model, skills));
        }
    }
}