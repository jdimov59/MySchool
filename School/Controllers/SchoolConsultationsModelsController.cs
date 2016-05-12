using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using School.Models;

namespace School.Controllers
{
    public class SchoolConsultationsModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SchoolConsultationsModels
        public ActionResult Index()
        {
            return View(db.BaseConsultationsModels.ToList());
        }

        // GET: SchoolConsultationsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseConsultationsModel baseConsultationsModel = db.BaseConsultationsModels.Find(id);
            if (baseConsultationsModel == null)
            {
                return HttpNotFound();
            }
            return View(baseConsultationsModel);
        }

        // GET: SchoolConsultationsModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolConsultationsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeacherName,Subject,DayOfTheWeek,Classroom,StartTime")] BaseConsultationsModel baseConsultationsModel)
        {
            if (ModelState.IsValid)
            {
                db.BaseConsultationsModels.Add(baseConsultationsModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baseConsultationsModel);
        }

        // GET: SchoolConsultationsModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseConsultationsModel baseConsultationsModel = db.BaseConsultationsModels.Find(id);
            if (baseConsultationsModel == null)
            {
                return HttpNotFound();
            }
            return View(baseConsultationsModel);
        }

        // POST: SchoolConsultationsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeacherName,Subject,DayOfTheWeek,Classroom,StartTime")] BaseConsultationsModel baseConsultationsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baseConsultationsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baseConsultationsModel);
        }

        // GET: SchoolConsultationsModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseConsultationsModel baseConsultationsModel = db.BaseConsultationsModels.Find(id);
            if (baseConsultationsModel == null)
            {
                return HttpNotFound();
            }
            return View(baseConsultationsModel);
        }

        // POST: SchoolConsultationsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaseConsultationsModel baseConsultationsModel = db.BaseConsultationsModels.Find(id);
            db.BaseConsultationsModels.Remove(baseConsultationsModel);
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
