using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;
using System.Net;
using LabPI.Models;
using xNet;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace LabPI.Controllers
{
    public class ParseController : Controller
    {
        //
        // GET: /Parse/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Olx()
        {
            return View();

        }
        public ActionResult Weather()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Page(int page, string product, string city)
        {
            if (String.IsNullOrEmpty(city))
            { city = "list"; }
            string link = "http:/" + "/olx.ua/" + city.ToLower() + "/q-" + product.Replace(" ", "-").ToLower().ToString() + "/";
            int pagesCount = GetCountPages(link);
            ViewBag.List = GetItems(page, link);
            ViewBag.Page = pagesCount;
            ViewBag.City = city;
            ViewBag.Product = product;
            ViewBag.CurrentPage = page;
            return View("ParseOlx");
        }
        [HttpPost]
        public ActionResult ParseOlx(string product, string city)
        {
            if (String.IsNullOrEmpty(city))
            { city = "list"; }
            string link = "http:/" + "/olx.ua/" + city.ToLower() + "/q-" + product.Replace(" ", "-").ToLower().ToString() + "/";
            int i = GetCountPages(link);
            ViewBag.List = GetItems(i, link);
            ViewBag.Page = i;
            ViewBag.City = city;
            ViewBag.Product = product;
            return View();
        }
        public int GetCountPages(string link)
        {
            int countPages = 0;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
            Stream stream = request.GetResponse().GetResponseStream();
            string sourcePage = null;
            using (stream)
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("UTF-8")))
                {
                    sourcePage = reader.ReadToEnd();
                }
                var foo = sourcePage.Substrings("page=", "\">", 0);
                if (foo.Length < 14)
                {
                    if (foo.Length == 0)
                    {
                        countPages = 1;
                    }
                    else
                    {
                        int l = foo.Length;
                        countPages = Convert.ToInt32(sourcePage.Substrings("page=", "\">", 0)[l - 1]);
                    }
                }
                else
                {
                    countPages = Convert.ToInt32(foo[14]);
                }
            }
            return countPages;
        }
        public string GetItems(int num, string link)
        {
            HtmlDocument html = new HtmlDocument();
            var web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8,
            };
            html = web.Load(link + "/?page=" + num);

            return html.DocumentNode.SelectNodes("//table[@id='offers_table']").Cast<HtmlNode>().Aggregate(string.Empty, (current, node) => current + node.OuterHtml);

        }

        public ActionResult ParseWeather(string station1, string station2, string time)
        {
          //  CheckStation(station1, station2);
            TrainModel train = ParsePZ(2204001, 2200001, Convert.ToDateTime(time));
            if (train.trains == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return View(train);
        }

        public TrainModel ParsePZ(int st1, int st2, DateTime date)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://www.pz.gov.ua/rezervGR/aj_g60.php");

            var postData = "kstotpr=" + st1 + "&kstprib=" + st2 + "&sdate=27-12-2015";

            var data = Encoding.GetEncoding(1251).GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            TrainModel m = JsonConvert.DeserializeObject<TrainModel>(responseString);
            //////////проверка на отсутствие поездов
         

            return m;
        }
        public void CheckStation(string s1, string s2)
        {      
            string url = "http://www.pz.gov.ua/rezervGR/aj_stattion.php?stan="+"киев";

            //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            //httpWebRequest.Method = WebRequestMethods.Http.Get;
            //httpWebRequest.Accept = "*/*";
            //httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            //HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            //response.Close();

            ////////////////////////////////////
            //var client = new HttpClient();
            //var uri = new Uri("http://ponify.me/stats.php");
            //Stream respStream = await client.GetStreamAsync(uri);
            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(rootObject));
            //rootObject feed = (rootObject)ser.ReadObject(respStream);
            ////////////////////////////////////
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string res = reader.ReadToEnd();

            }
        }
    }
}