using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S1G4_SISDB1.Models;

namespace S1G4_SISDB1.Controllers
{
    public class StudyTermsController : Controller
    {
        private Entities db = new Entities();

        // GET: StudyTerms
        public ActionResult Index()
        {
            return View(db.StudyTerms.ToList());
        }

        // GET: StudyTerms/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyTerms studyTerms = db.StudyTerms.Find(id);
            if (studyTerms == null)
            {
                return HttpNotFound();
            }
            return View(studyTerms);
        }

        // GET: StudyTerms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudyTerms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TermID,TermName,TermStartDate,TermEndDate,TermYear,TermSeason")] StudyTerms studyTerms)
        {
            if (ModelState.IsValid)
            {
                db.StudyTerms.Add(studyTerms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studyTerms);
        }

        // GET: StudyTerms/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyTerms studyTerms = db.StudyTerms.Find(id);
            if (studyTerms == null)
            {
                return HttpNotFound();
            }
            return View(studyTerms);
        }

        // POST: StudyTerms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TermID,TermName,TermStartDate,TermEndDate,TermYear,TermSeason")] StudyTerms studyTerms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studyTerms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studyTerms);
        }

        // GET: StudyTerms/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyTerms studyTerms = db.StudyTerms.Find(id);
            if (studyTerms == null)
            {
                return HttpNotFound();
            }
            return View(studyTerms);
        }

        // POST: StudyTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StudyTerms studyTerms = db.StudyTerms.Find(id);
            db.StudyTerms.Remove(studyTerms);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
