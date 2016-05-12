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
    public class SchoolOffDaysModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SchoolOffDaysModels
        public ActionResult Index()
        {
            return View(db.BaseOffDaysModels.ToList());
        }

        // GET: SchoolOffDaysModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseOffDaysModel baseOffDaysModel = db.BaseOffDaysModels.Find(id);
            if (baseOffDaysModel == null)
            {
                return HttpNotFound();
            }
            return View(baseOffDaysModel);
        }

        // GET: SchoolOffDaysModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolOffDaysModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,Date")] BaseOffDaysModel baseOffDaysModel)
        {
            if (ModelState.IsValid)
            {
                db.BaseOffDaysModels.Add(baseOffDaysModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baseOffDaysModel);
        }

        // GET: SchoolOffDaysModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseOffDaysModel baseOffDaysModel = db.BaseOffDaysModels.Find(id);
            if (baseOffDaysModel == null)
            {
                return HttpNotFound();
            }
            return View(baseOffDaysModel);
        }

        // POST: SchoolOffDaysModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,Date")] BaseOffDaysModel baseOffDaysModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baseOffDaysModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baseOffDaysModel);
        }

        // GET: SchoolOffDaysModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseOffDaysModel baseOffDaysModel = db.BaseOffDaysModels.Find(id);
            if (baseOffDaysModel == null)
            {
                return HttpNotFound();
            }
            return View(baseOffDaysModel);
        }

        // POST: SchoolOffDaysModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaseOffDaysModel baseOffDaysModel = db.BaseOffDaysModels.Find(id);
            db.BaseOffDaysModels.Remove(baseOffDaysModel);
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
