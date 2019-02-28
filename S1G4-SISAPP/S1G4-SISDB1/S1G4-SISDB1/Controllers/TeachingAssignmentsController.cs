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
    public class TeachingAssignmentsController : Controller
    {
        private Entities db = new Entities();

        // GET: TeachingAssignments
        public ActionResult Index()
        {
            var teachingAssignments = db.TeachingAssignments.Include(t => t.Courses).Include(t => t.Instructors).Include(t => t.StudyTerms);
            return View(teachingAssignments.ToList());
        }

        // GET: TeachingAssignments/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeachingAssignments teachingAssignments = db.TeachingAssignments.Find(id);
            if (teachingAssignments == null)
            {
                return HttpNotFound();
            }
            return View(teachingAssignments);
        }

        // GET: TeachingAssignments/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "InstructorFirstName");
            ViewBag.TermID = new SelectList(db.StudyTerms, "TermID", "TermName");
            return View();
        }

        // POST: TeachingAssignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstructorID,CourseID,TermID")] TeachingAssignments teachingAssignments)
        {
            if (ModelState.IsValid)
            {
                db.TeachingAssignments.Add(teachingAssignments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", teachingAssignments.CourseID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "InstructorFirstName", teachingAssignments.InstructorID);
            ViewBag.TermID = new SelectList(db.StudyTerms, "TermID", "TermName", teachingAssignments.TermID);
            return View(teachingAssignments);
        }

        // GET: TeachingAssignments/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeachingAssignments teachingAssignments = db.TeachingAssignments.Find(id);
            if (teachingAssignments == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", teachingAssignments.CourseID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "InstructorFirstName", teachingAssignments.InstructorID);
            ViewBag.TermID = new SelectList(db.StudyTerms, "TermID", "TermName", teachingAssignments.TermID);
            return View(teachingAssignments);
        }

        // POST: TeachingAssignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstructorID,CourseID,TermID")] TeachingAssignments teachingAssignments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teachingAssignments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", teachingAssignments.CourseID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "InstructorFirstName", teachingAssignments.InstructorID);
            ViewBag.TermID = new SelectList(db.StudyTerms, "TermID", "TermName", teachingAssignments.TermID);
            return View(teachingAssignments);
        }

        // GET: TeachingAssignments/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeachingAssignments teachingAssignments = db.TeachingAssignments.Find(id);
            if (teachingAssignments == null)
            {
                return HttpNotFound();
            }
            return View(teachingAssignments);
        }

        // POST: TeachingAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TeachingAssignments teachingAssignments = db.TeachingAssignments.Find(id);
            db.TeachingAssignments.Remove(teachingAssignments);
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
