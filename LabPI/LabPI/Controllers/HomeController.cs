using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.User = "Вы не авторизованы";
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.User = "Ваше полное имя: " + User.Identity.Name;
            }
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}