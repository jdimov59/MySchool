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
    public class SchoolScheduleYearModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SchoolScheduleYearModels
        public ActionResult Index()
        {
            return View(db.BaseScheduleYearModels.ToList());
        }

        // GET: SchoolScheduleYearModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseScheduleYearModel baseScheduleYearModel = db.BaseScheduleYearModels.Find(id);
            if (baseScheduleYearModel == null)
            {
                return HttpNotFound();
            }
            return View(baseScheduleYearModel);
        }

        // GET: SchoolScheduleYearModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolScheduleYearModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ScheduleYear")] BaseScheduleYearModel baseScheduleYearModel)
        {
            if (db.BaseScheduleYearModels.FirstOrDefault() == null && baseScheduleYearModel.ScheduleYear != null)
            {
                if (ModelState.IsValid)
                {
                    db.BaseScheduleYearModels.Add(baseScheduleYearModel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                if (db.BaseScheduleYearModels.FirstOrDefault() != null)
                {
                    ViewBag.Message = "Не може да добавяте повече от една учебна година";
                }
                else
                {
                    ViewBag.Message = "Не може да добавяте празно поле.";
                }
                return View("ErrorYear");
            }
            return View(baseScheduleYearModel);
        }

        // GET: SchoolScheduleYearModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseScheduleYearModel baseScheduleYearModel = db.BaseScheduleYearModels.Find(id);
            if (baseScheduleYearModel == null)
            {
                return HttpNotFound();
            }
            return View(baseScheduleYearModel);
        }

        // POST: SchoolScheduleYearModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ScheduleYear")] BaseScheduleYearModel baseScheduleYearModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baseScheduleYearModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baseScheduleYearModel);
        }

        // GET: SchoolScheduleYearModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseScheduleYearModel baseScheduleYearModel = db.BaseScheduleYearModels.Find(id);
            if (baseScheduleYearModel == null)
            {
                return HttpNotFound();
            }
            return View(baseScheduleYearModel);
        }

        // POST: SchoolScheduleYearModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaseScheduleYearModel baseScheduleYearModel = db.BaseScheduleYearModels.Find(id);
            db.BaseScheduleYearModels.Remove(baseScheduleYearModel);
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
