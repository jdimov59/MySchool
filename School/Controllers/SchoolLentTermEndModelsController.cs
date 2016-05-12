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
    public class SchoolLentTermEndModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SchoolLentTermEndModels
        public ActionResult Index()
        {
            return View(db.BaseLentTermEndModels.ToList());
        }

        // GET: SchoolLentTermEndModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseLentTermEndModel baseLentTermEndModel = db.BaseLentTermEndModels.Find(id);
            if (baseLentTermEndModel == null)
            {
                return HttpNotFound();
            }
            return View(baseLentTermEndModel);
        }

        // GET: SchoolLentTermEndModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolLentTermEndModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,Date")] BaseLentTermEndModel baseLentTermEndModel)
        {
            if (ModelState.IsValid)
            {
                db.BaseLentTermEndModels.Add(baseLentTermEndModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baseLentTermEndModel);
        }

        // GET: SchoolLentTermEndModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseLentTermEndModel baseLentTermEndModel = db.BaseLentTermEndModels.Find(id);
            if (baseLentTermEndModel == null)
            {
                return HttpNotFound();
            }
            return View(baseLentTermEndModel);
        }

        // POST: SchoolLentTermEndModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,Date")] BaseLentTermEndModel baseLentTermEndModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baseLentTermEndModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baseLentTermEndModel);
        }

        // GET: SchoolLentTermEndModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseLentTermEndModel baseLentTermEndModel = db.BaseLentTermEndModels.Find(id);
            if (baseLentTermEndModel == null)
            {
                return HttpNotFound();
            }
            return View(baseLentTermEndModel);
        }

        // POST: SchoolLentTermEndModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaseLentTermEndModel baseLentTermEndModel = db.BaseLentTermEndModels.Find(id);
            db.BaseLentTermEndModels.Remove(baseLentTermEndModel);
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
