using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MissionMattersRound2.DAL;
using MissionMattersRound2.Models;

namespace MissionMattersRound2.Controllers
{
    public class HomeController : Controller
    {
        //VARIABLES
        public static List<Question> Korea = new List<Question>();
        public static List<Question> Canada = new List<Question>();
        public static List<Question> Texas = new List<Question>();
        private MissionMattersContext db = new MissionMattersContext();



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
            return View(db.Missions.ToList());
        }

        public ActionResult Mission(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mission mission = db.Missions.Find(id);
            if (mission == null)
            {
                return HttpNotFound();
            }
            return View(mission);
        }

        [Authorize]
        public ActionResult FAQs(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mission mission = db.Missions.Find(id);
            if (mission == null)
            {
                return HttpNotFound();
            }
            return View(mission);
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


        //METHOD TO ANSWER QUESTIONS IN Q/A FORM
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestion missionQuestion = db.MissionQuestions.Find(id);
            if (missionQuestion == null)
            {
                return HttpNotFound();
            }
            return View(missionQuestion);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "missionQuestionID,missionID,userID,question,answer")] MissionQuestion missionQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(missionQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Mission", new { id = missionQuestion.missionID });
            }
            return View("Mission");
        }


        // GET: MissionQuestions/Create
        public ActionResult Create(int? id)
        {

            ViewBag.missionID = id;
            return View();
        }

        // POST: MissionQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "missionQuestionID,userID,question,answer,missionID")] MissionQuestion missionQuestion, int? id)
        {
            if (ModelState.IsValid)
            {
                missionQuestion.missionID = id;
                db.MissionQuestions.Add(missionQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.missionID = new SelectList(db.Missions, "missionID", "missionName", missionQuestion.missionID);
            return View(missionQuestion);
        }
    }
}