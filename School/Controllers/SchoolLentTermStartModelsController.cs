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
    public class SchoolLentTermStartModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SchoolLentTermStartModels
        public ActionResult Index()
        {
            return View(db.BaseLentTermStartModels.ToList());
        }

        // GET: SchoolLentTermStartModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseLentTermStartModel baseLentTermStartModel = db.BaseLentTermStartModels.Find(id);
            if (baseLentTermStartModel == null)
            {
                return HttpNotFound();
            }
            return View(baseLentTermStartModel);
        }

        // GET: SchoolLentTermStartModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolLentTermStartModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,Date")] BaseLentTermStartModel baseLentTermStartModel)
        {
            if (ModelState.IsValid)
            {
                db.BaseLentTermStartModels.Add(baseLentTermStartModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baseLentTermStartModel);
        }

        // GET: SchoolLentTermStartModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseLentTermStartModel baseLentTermStartModel = db.BaseLentTermStartModels.Find(id);
            if (baseLentTermStartModel == null)
            {
                return HttpNotFound();
            }
            return View(baseLentTermStartModel);
        }

        // POST: SchoolLentTermStartModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,Date")] BaseLentTermStartModel baseLentTermStartModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baseLentTermStartModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baseLentTermStartModel);
        }

        // GET: SchoolLentTermStartModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseLentTermStartModel baseLentTermStartModel = db.BaseLentTermStartModels.Find(id);
            if (baseLentTermStartModel == null)
            {
                return HttpNotFound();
            }
            return View(baseLentTermStartModel);
        }

        // POST: SchoolLentTermStartModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaseLentTermStartModel baseLentTermStartModel = db.BaseLentTermStartModels.Find(id);
            db.BaseLentTermStartModels.Remove(baseLentTermStartModel);
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
