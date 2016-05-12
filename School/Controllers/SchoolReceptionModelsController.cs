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
    public class SchoolReceptionModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SchoolReceptionModels
        public ActionResult Index()
        {
            return View(db.BaseReceptionModels.ToList());
        }

        // GET: SchoolReceptionModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseReceptionModel baseReceptionModel = db.BaseReceptionModels.Find(id);
            if (baseReceptionModel == null)
            {
                return HttpNotFound();
            }
            return View(baseReceptionModel);
        }

        // GET: SchoolReceptionModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolReceptionModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Profession,CodeProfession,Specialty,CodeSpecialty,AdmissionEducationalLevel,FormOfEducation,PeriodOfTraining,EducationalDegree,LevelOfQualification")] BaseReceptionModel baseReceptionModel)
        {
            if (ModelState.IsValid)
            {
                db.BaseReceptionModels.Add(baseReceptionModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baseReceptionModel);
        }

        // GET: SchoolReceptionModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseReceptionModel baseReceptionModel = db.BaseReceptionModels.Find(id);
            if (baseReceptionModel == null)
            {
                return HttpNotFound();
            }
            return View(baseReceptionModel);
        }

        // POST: SchoolReceptionModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Profession,CodeProfession,Specialty,CodeSpecialty,AdmissionEducationalLevel,FormOfEducation,PeriodOfTraining,EducationalDegree,LevelOfQualification")] BaseReceptionModel baseReceptionModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baseReceptionModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baseReceptionModel);
        }

        // GET: SchoolReceptionModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseReceptionModel baseReceptionModel = db.BaseReceptionModels.Find(id);
            if (baseReceptionModel == null)
            {
                return HttpNotFound();
            }
            return View(baseReceptionModel);
        }

        // POST: SchoolReceptionModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaseReceptionModel baseReceptionModel = db.BaseReceptionModels.Find(id);
            db.BaseReceptionModels.Remove(baseReceptionModel);
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
