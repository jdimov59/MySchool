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
    public class SchoolSpecialtiesModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SchoolSpecialtiesModels
        public ActionResult Index()
        {
            return View(db.BaseSpecialtiesModels.ToList());
        }

        // GET: SchoolSpecialtiesModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseSpecialtiesModel baseSpecialtiesModel = db.BaseSpecialtiesModels.Find(id);
            if (baseSpecialtiesModel == null)
            {
                return HttpNotFound();
            }
            return View(baseSpecialtiesModel);
        }

        // GET: SchoolSpecialtiesModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolSpecialtiesModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Profession,CodeProfession,Specialty,CodeSpecialty,AdmissionEducationalLevel,FormOfEducation,PeriodOfTraining,EducationalDegree,LevelOfQualification")] BaseSpecialtiesModel baseSpecialtiesModel)
        {
            if (ModelState.IsValid)
            {
                db.BaseSpecialtiesModels.Add(baseSpecialtiesModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baseSpecialtiesModel);
        }

        // GET: SchoolSpecialtiesModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseSpecialtiesModel baseSpecialtiesModel = db.BaseSpecialtiesModels.Find(id);
            if (baseSpecialtiesModel == null)
            {
                return HttpNotFound();
            }
            return View(baseSpecialtiesModel);
        }

        // POST: SchoolSpecialtiesModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Profession,CodeProfession,Specialty,CodeSpecialty,AdmissionEducationalLevel,FormOfEducation,PeriodOfTraining,EducationalDegree,LevelOfQualification")] BaseSpecialtiesModel baseSpecialtiesModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baseSpecialtiesModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baseSpecialtiesModel);
        }

        // GET: SchoolSpecialtiesModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseSpecialtiesModel baseSpecialtiesModel = db.BaseSpecialtiesModels.Find(id);
            if (baseSpecialtiesModel == null)
            {
                return HttpNotFound();
            }
            return View(baseSpecialtiesModel);
        }

        // POST: SchoolSpecialtiesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaseSpecialtiesModel baseSpecialtiesModel = db.BaseSpecialtiesModels.Find(id);
            db.BaseSpecialtiesModels.Remove(baseSpecialtiesModel);
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
