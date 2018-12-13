using MissionMattersRound2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MissionMattersRound2.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public static List<Question> Korea = new List<Question>();

        public static List<Question> Canada = new List<Question>();

        public static List<Question> Texas = new List<Question>();

        public ActionResult Index()
        {
            if (Korea.Count == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    Korea.Add(new Question());
                    Canada.Add(new Question());
                    Texas.Add(new Question());
                }
            }
            return View();
        }

        public ActionResult Missions()
        {
            return View();
        }

        public ActionResult Seoul()
        {
            ViewBag.name = "Seoul Korea South Mission";
            ViewBag.president = "Roger W. Turner";
            ViewBag.address = "29 Wiryeseong-daero 22-gil (Ogeum - dong) Songpa - gu Seoul - teukbyeolsi 05655 South Korea";
            ViewBag.language = "Korean";
            ViewBag.climate = "Subtropical";
            ViewBag.dominate = "Atheist";
            ViewBag.flag = "/Content/Images/korea.png";
            return View("Mission", Korea);
        }

        public ActionResult Montreal()
        {
            ViewBag.name = "Canada Montreal Mission";
            ViewBag.president = "Robert Lee Phillips";
            ViewBag.address = "470 Rue Gilford, Montréal, QC H2J 1N3, Canada";
            ViewBag.language = "French";
            ViewBag.climate = "Continental";
            ViewBag.dominate = "Catholic";
            ViewBag.flag = "/Content/Images/quebec.png";
            return View("Mission", Canada);
        }

        public ActionResult Lubbock()
        {
            ViewBag.name = "Texas Lubbock Mission";
            ViewBag.president = "David G. Hales";
            ViewBag.address = "6310 114th St, Lubbock, Texas";
            ViewBag.language = "Spanish/English";
            ViewBag.climate = "Semi-arid";
            ViewBag.dominate = "Baptist";
            ViewBag.flag = "/Content/Images/texas.png";
            return View("Mission", Texas);
        }

        public ActionResult About()
        {
            ViewBag.Message = "About us!";

            return View();
        }



        public ActionResult ContactForm()
        {
           

            return View();
        }
    }
}