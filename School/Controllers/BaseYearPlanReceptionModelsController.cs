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
    public class BaseYearPlanReceptionModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BaseYearPlanReceptionModels
        public ActionResult Index()
        {
            return View(db.BaseYearPlanReceptionModels.ToList());
        }

        // GET: BaseYearPlanReceptionModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseYearPlanReceptionModel baseYearPlanReceptionModel = db.BaseYearPlanReceptionModels.Find(id);
            if (baseYearPlanReceptionModel == null)
            {
                return HttpNotFound();
            }
            return View(baseYearPlanReceptionModel);
        }

        // GET: BaseYearPlanReceptionModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BaseYearPlanReceptionModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,YearPlanReception")] BaseYearPlanReceptionModel baseYearPlanReceptionModel)
        {
            if (ModelState.IsValid)
            {
                if (db.BaseYearPlanReceptionModels.FirstOrDefault() == null && baseYearPlanReceptionModel.YearPlanReception != null)
                {
                    if (ModelState.IsValid)
                    {
                        db.BaseYearPlanReceptionModels.Add(baseYearPlanReceptionModel);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    if (db.BaseYearPlanReceptionModels.FirstOrDefault() != null)
                    {
                        ViewBag.Message = "Не може да добавяте повече от една учебна година";
                    }
                    else
                    {
                        ViewBag.Message = "Не може да добавяте празно поле.";
                    }
                    return View("ErrorYear");
                }
                return View(baseYearPlanReceptionModel);
            }

            return View(baseYearPlanReceptionModel);
        }

        // GET: BaseYearPlanReceptionModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseYearPlanReceptionModel baseYearPlanReceptionModel = db.BaseYearPlanReceptionModels.Find(id);
            if (baseYearPlanReceptionModel == null)
            {
                return HttpNotFound();
            }
            return View(baseYearPlanReceptionModel);
        }

        // POST: BaseYearPlanReceptionModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,YearPlanReception")] BaseYearPlanReceptionModel baseYearPlanReceptionModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baseYearPlanReceptionModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baseYearPlanReceptionModel);
        }

        // GET: BaseYearPlanReceptionModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseYearPlanReceptionModel baseYearPlanReceptionModel = db.BaseYearPlanReceptionModels.Find(id);
            if (baseYearPlanReceptionModel == null)
            {
                return HttpNotFound();
            }
            return View(baseYearPlanReceptionModel);
        }

        // POST: BaseYearPlanReceptionModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaseYearPlanReceptionModel baseYearPlanReceptionModel = db.BaseYearPlanReceptionModels.Find(id);
            db.BaseYearPlanReceptionModels.Remove(baseYearPlanReceptionModel);
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
