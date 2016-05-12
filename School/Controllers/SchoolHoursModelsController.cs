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
    public class SchoolHoursModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SchoolHoursModels
        public ActionResult Index()
        {
            return View(db.BaseHoursModels.ToList());
        }

        // GET: SchoolHoursModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseHoursModel baseHoursModel = db.BaseHoursModels.Find(id);
            if (baseHoursModel == null)
            {
                return HttpNotFound();
            }
            return View(baseHoursModel);
        }

        // GET: SchoolHoursModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolHoursModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Hours,Start,End")] BaseHoursModel baseHoursModel)
        {
            if (ModelState.IsValid)
            {
                db.BaseHoursModels.Add(baseHoursModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baseHoursModel);
        }

        // GET: SchoolHoursModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseHoursModel baseHoursModel = db.BaseHoursModels.Find(id);
            if (baseHoursModel == null)
            {
                return HttpNotFound();
            }
            return View(baseHoursModel);
        }

        // POST: SchoolHoursModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Hours,Start,End")] BaseHoursModel baseHoursModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baseHoursModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baseHoursModel);
        }

        // GET: SchoolHoursModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseHoursModel baseHoursModel = db.BaseHoursModels.Find(id);
            if (baseHoursModel == null)
            {
                return HttpNotFound();
            }
            return View(baseHoursModel);
        }

        // POST: SchoolHoursModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaseHoursModel baseHoursModel = db.BaseHoursModels.Find(id);
            db.BaseHoursModels.Remove(baseHoursModel);
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
