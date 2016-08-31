using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class CalculatorController : Controller
    {
        //
        // GET: /Calculator/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Count(string x, string y, string action1)
        {
            double a = 0;
            double b = 0;
            if (String.IsNullOrEmpty(x))
            {
                ViewBag.ErrorValue = "Введите первый параметр";
                return PartialView("Error");
            } 
            if (String.IsNullOrEmpty(y))
            {
                ViewBag.ErrorValue = "Введите второй параметр";
                return PartialView("Error");
            }

            try
            {
                a = Convert.ToDouble(x);
            }
            catch (System.FormatException)
            {
                ViewBag.ErrorValue = "Первый параметр имеет неверный формат данных";
                return PartialView("Error");
            }

            try
            {
                b = Convert.ToDouble(y);
               
                if (action1 == "Разделить" && b == 0)
                {
                    throw new System.ArgumentException("Деление на ноль невозможно", "exception");
                }
            }
            catch (System.FormatException)
            {
                ViewBag.ErrorValue = "Второй параметр имеет неверный формат данных";
                return PartialView("Error");
            }
            catch (System.ArgumentException)
            {
                ViewBag.ErrorValue = "Деление на ноль невозможно";
                return PartialView("Error");
            }
            switch (action1)
            {
                case "Умножить":
                    ViewBag.Result = a * b;
                    break;
                case "Разделить":
                    ViewBag.Result = a / b;
                    break;
                case "Сложить":
                    ViewBag.Result = a + b;
                    break;
                case "Отнять":
                    ViewBag.Result = a - b;
                    break;
            }
            ViewBag.Action = action1;
            return PartialView();
        }
    }
}