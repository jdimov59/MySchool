using School.Models;
using School.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class PlanReceptionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlanReception
        public ActionResult PlanReception()
        {
            var model = new PlanReceptionViewModel();

            model.YearPlan = db.BaseYearPlanReceptionModels.Select(x => new YearPlanReceptionModel { Id = x.Id, YearPlanReception = x.YearPlanReception });
            model.Reception = db.BaseReceptionModels.Select(x => new ReceptionViewModel { Id = x.Id, Profession = x.Profession, CodeProfession = x.CodeProfession, Specialty = x.Specialty, CodeSpecialty = x.CodeSpecialty, AdmissionEducationalLevel = x.AdmissionEducationalLevel, FormOfEducation = x.FormOfEducation, PeriodOfTraining = x.PeriodOfTraining, EducationalDegree = x.EducationalDegree, LevelOfQualification = x.LevelOfQualification });
            //var model = db.BaseReceptionModels.Select(x => new ReceptionViewModel { Id = x.Id, Profession = x.Profession, CodeProfession = x.CodeProfession, Specialty = x.Specialty, CodeSpecialty = x.CodeSpecialty, AdmissionEducationalLevel = x.AdmissionEducationalLevel, FormOfEducation = x.FormOfEducation, PeriodOfTraining = x.PeriodOfTraining, EducationalDegree = x.EducationalDegree, LevelOfQualification = x.LevelOfQualification });

            return View(model);
        }
    }
}