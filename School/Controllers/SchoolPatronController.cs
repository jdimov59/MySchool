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
    public class SchoolPatronController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SchoolPatron
        public ActionResult Index()
        {
            return View(db.PatronModels.ToList());
        }

        // GET: SchoolPatron/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatronModel patronModel = db.PatronModels.Find(id);
            if (patronModel == null)
            {
                return HttpNotFound();
            }
            return View(patronModel);
        }

        // GET: SchoolPatron/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolPatron/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content")] PatronModel patronModel)
        {
            if (ModelState.IsValid)
            {
                db.PatronModels.Add(patronModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patronModel);
        }

        // GET: SchoolPatron/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatronModel patronModel = db.PatronModels.Find(id);
            if (patronModel == null)
            {
                return HttpNotFound();
            }
            return View(patronModel);
        }

        // POST: SchoolPatron/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content")] PatronModel patronModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patronModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patronModel);
        }

        // GET: SchoolPatron/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatronModel patronModel = db.PatronModels.Find(id);
            if (patronModel == null)
            {
                return HttpNotFound();
            }
            return View(patronModel);
        }

        // POST: SchoolPatron/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatronModel patronModel = db.PatronModels.Find(id);
            db.PatronModels.Remove(patronModel);
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
