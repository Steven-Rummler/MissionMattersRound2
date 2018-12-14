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

//This is the code for Project 2
//We are group 1-15
//Tanner Garrett    Sierra Johnson
//Steven Rummler    Tyler Kraupp

namespace MissionMattersRound2.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private MissionMattersContext db = new MissionMattersContext();

        //Our lovely home page!
        public ActionResult Index()
        {
            return View();
        }

        //A method presenting a view that allows users to consider our delightful selection of missions.
        public ActionResult Missions()
        {
            return View(db.Missions.ToList());
        }

        //A mission served a la carte, with details galore!
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

        //VIP access only! Our proprietary FAQ section, complete with inspired questions and meaningful answers.
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

        //An in-depth look at our glorious cause, along with links to other inspired websites.
        public ActionResult About()
        {
            ViewBag.Message = "About us!";

            return View();
        }

        public ActionResult ContactForm()
        {
           

            return View();
        }


        //Here, users can join in our quest by answering the questions of the uninitiated.
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

        //This method deftly collects answers and changes to answers and carries them safely home.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "missionQuestionID,missionID,userID,question,answer")] MissionQuestion missionQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(missionQuestion).State = EntityState.Modified;
                db.SaveChanges();               
            }
            return RedirectToAction("FAQs", new { id = missionQuestion.missionID });
        }


        //An opportunity to ask the questions of the soul.
        public ActionResult Create(int? id)
        {

            ViewBag.missionID = id;
            return View();
        }

        //Bringing these special questions into the care of our database.
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
                return RedirectToAction("FAQs", new { id = missionQuestion.missionID });
            }

            ViewBag.missionID = new SelectList(db.Missions, "missionID", "missionName", missionQuestion.missionID);
            return View(missionQuestion);
        }
    }
}