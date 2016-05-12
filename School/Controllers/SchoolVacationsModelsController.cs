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
    public class SchoolVacationsModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SchoolVacationsModels
        public ActionResult Index()
        {
            return View(db.BaseVacationsModels.ToList());
        }

        // GET: SchoolVacationsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseVacationsModel baseVacationsModel = db.BaseVacationsModels.Find(id);
            if (baseVacationsModel == null)
            {
                return HttpNotFound();
            }
            return View(baseVacationsModel);
        }

        // GET: SchoolVacationsModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolVacationsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,Date")] BaseVacationsModel baseVacationsModel)
        {
            if (ModelState.IsValid)
            {
                db.BaseVacationsModels.Add(baseVacationsModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baseVacationsModel);
        }

        // GET: SchoolVacationsModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseVacationsModel baseVacationsModel = db.BaseVacationsModels.Find(id);
            if (baseVacationsModel == null)
            {
                return HttpNotFound();
            }
            return View(baseVacationsModel);
        }

        // POST: SchoolVacationsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,Date")] BaseVacationsModel baseVacationsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baseVacationsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baseVacationsModel);
        }

        // GET: SchoolVacationsModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseVacationsModel baseVacationsModel = db.BaseVacationsModels.Find(id);
            if (baseVacationsModel == null)
            {
                return HttpNotFound();
            }
            return View(baseVacationsModel);
        }

        // POST: SchoolVacationsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaseVacationsModel baseVacationsModel = db.BaseVacationsModels.Find(id);
            db.BaseVacationsModels.Remove(baseVacationsModel);
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
