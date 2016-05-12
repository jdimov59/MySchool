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
    public class SchoolMaterialBaseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SchoolMaterialBase
        public ActionResult Index()
        {
            return View(db.MaterialBaseModels.ToList());
        }

        // GET: SchoolMaterialBase/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialBaseModel materialBaseModel = db.MaterialBaseModels.Find(id);
            if (materialBaseModel == null)
            {
                return HttpNotFound();
            }
            return View(materialBaseModel);
        }

        // GET: SchoolMaterialBase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolMaterialBase/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content")] MaterialBaseModel materialBaseModel)
        {
            if (ModelState.IsValid)
            {
                db.MaterialBaseModels.Add(materialBaseModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materialBaseModel);
        }

        // GET: SchoolMaterialBase/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialBaseModel materialBaseModel = db.MaterialBaseModels.Find(id);
            if (materialBaseModel == null)
            {
                return HttpNotFound();
            }
            return View(materialBaseModel);
        }

        // POST: SchoolMaterialBase/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content")] MaterialBaseModel materialBaseModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materialBaseModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materialBaseModel);
        }

        // GET: SchoolMaterialBase/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialBaseModel materialBaseModel = db.MaterialBaseModels.Find(id);
            if (materialBaseModel == null)
            {
                return HttpNotFound();
            }
            return View(materialBaseModel);
        }

        // POST: SchoolMaterialBase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaterialBaseModel materialBaseModel = db.MaterialBaseModels.Find(id);
            db.MaterialBaseModels.Remove(materialBaseModel);
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
