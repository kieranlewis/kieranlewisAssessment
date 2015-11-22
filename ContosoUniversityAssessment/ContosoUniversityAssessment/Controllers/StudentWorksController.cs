using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContosoUniversityAssessment.DAL;
using ContosoUniversityAssessment.Models;

namespace ContosoUniversityAssessment.Controllers
{
    public class StudentWorksController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: StudentWorks
        public ActionResult Index()
        {
            return View(db.StudentWork.ToList());
        }

        // GET: StudentWorks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentWork studentWork = db.StudentWork.Find(id);
            if (studentWork == null)
            {
                return HttpNotFound();
            }
            return View(studentWork);
        }

        // GET: StudentWorks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentWorks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentWorkID,StudentID,LinkName")] StudentWork studentWork)
        {
            if (ModelState.IsValid)
            {
                db.StudentWork.Add(studentWork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentWork);
        }

        // GET: StudentWorks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentWork studentWork = db.StudentWork.Find(id);
            if (studentWork == null)
            {
                return HttpNotFound();
            }
            return View(studentWork);
        }

        // POST: StudentWorks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentWorkID,StudentID,LinkName")] StudentWork studentWork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentWork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentWork);
        }

        // GET: StudentWorks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentWork studentWork = db.StudentWork.Find(id);
            if (studentWork == null)
            {
                return HttpNotFound();
            }
            return View(studentWork);
        }

        // POST: StudentWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentWork studentWork = db.StudentWork.Find(id);
            db.StudentWork.Remove(studentWork);
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
