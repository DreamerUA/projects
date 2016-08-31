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
    public class SummaryController : Controller
    {
        IUserRepository userRepo;
        IUniversalRepository universalRepo;
        ISummaryRepository summaryRepo;
        ISkillRepository skillRepo;
        IVacancyRepository vacancyRepo;
        IUserInfoRepository infoRepo;
        public SummaryController(ISummaryRepository summary, IUniversalRepository univers, 
            IUserRepository user, ISkillRepository skill, IVacancyRepository vacRepo, IUserInfoRepository info)
        {
            infoRepo = info;
            vacancyRepo = vacRepo;
            skillRepo = skill;
            summaryRepo = summary;
            userRepo = user;
            universalRepo = univers;
        }

        public ActionResult DeleteSummary(int id)
        {
            Summary sum = summaryRepo.GetSummaryById(id);
            summaryRepo.Delete(id);
            summaryRepo.Save();
            return RedirectToAction("UserSummaries");
        }

        public ActionResult Index()
        {
            return View(universalRepo.GetSummaryList());
        }
        public ActionResult AddSummary()
        {
            ViewBag.UserId = userRepo.GetUserByLogin(User.Identity.Name).UserId;
            return View();
        }
        [HttpPost]
        public ActionResult AddSummary(Summary model)
        {
            if (ModelState.IsValid)
            {
                summaryRepo.Create(model);
                summaryRepo.Save();
                return RedirectToAction("EditSummary", new { id = model.SummaryId });
            }
            ViewBag.UserId = userRepo.GetUserByLogin(User.Identity.Name).UserId;
            return View();
        }

        [HttpGet]
        public ActionResult EditSummary(int id)
        {
            return View(new EditSummaryModel { Summary = summaryRepo.GetSummaryById(id), Skills = universalRepo.GetList() });
        }
        [HttpPost]
        public ActionResult EditSummary(Summary model)
        {
            if (ModelState.IsValid)
            {
                summaryRepo.Update(model);
                summaryRepo.Save();
            }
            ViewBag.IsEdit = "CHANGED";
            return View(new EditSummaryModel { Summary = model, Skills = universalRepo.GetList() });
        }
        //  добавить ViewBag.Add
        public ActionResult UserSummaries()
        {
            return View(summaryRepo.GetSummaryListByLogin(User.Identity.Name));
        }
        public ActionResult SummaryPage(int id)
        {
            Summary sum = summaryRepo.GetSummaryById(id);
            ICollection<VacancyPageModel> v = universalRepo.AutoCompleteVacancy(sum);
            return View(new NewSummaryPageModel {Summary = sum, Owner = infoRepo.GetUserInfoByUserId(sum.UserId), Vacancies= v.ToList() });
        }       
        public ActionResult DeleteSkill(int id, int sumId)
        {
            DeleteSkillModel m = new DeleteSkillModel { SkillId = id, Id = sumId };
            summaryRepo.DeleteSkillSummary(m);
            summaryRepo.Save();
            //return RedirectToAction("UserSkill");
            return RedirectToAction("EditSummary", new { id = sumId });
        }
        //Создаем и добавляем скилл текущему пользователю
        public ActionResult CreateSkill(string name, int summaryId)
        {
            Skill skill = new Skill { Name = name };
            Skill s = skillRepo.GetSkillByName(name);
            if (s != null)
            {
                //добавить ViewBag в представление
                ViewBag.IsAdded = "Такое умение уже есть, вопользуйтесь поиском";
                return RedirectToAction("SummarySkill", new { sumId = summaryId });
            }
            Summary sum = summaryRepo.GetSummaryById(summaryId);
            sum.Skills.Add(skill);
            summaryRepo.Save();
            skillRepo.Save();
            return RedirectToAction("SummarySkill", new { sumId = summaryId });
        }
        [HttpPost]
        public ActionResult AddSkill(string SkillId, int summaryId)
        {
            Skill skill = universalRepo.GetSkillById(Convert.ToInt32(SkillId));
            Summary sum = universalRepo.GetSummaryById(summaryId);
            skill.Summarys.Add(sum);
            sum.Skills.Add(skill);
            universalRepo.Save(true);

            return RedirectToAction("SummarySkill", new { sumId = summaryId });
        }
        public ActionResult SummarySkill(int sumId)
        {
            ViewBag.SumId = sumId;
            return PartialView(summaryRepo.GetSummaryById(sumId).Skills);
        }
        public ActionResult Search()
        {
            return View(skillRepo.GetList());
        }
        [HttpPost]
        public ActionResult Search(SearchModel model, int[] skills)
        {
            return View("~/Views/Summary/SearchResult.cshtml", universalRepo.SearchSummary(model, skills));
        }

        public IEnumerable<VacancyPageModel> RandomVacancy()
        {
            return vacancyRepo.GetRandomVacancy(3);
        }
    }
}