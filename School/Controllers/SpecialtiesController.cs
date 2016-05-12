using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using School.Models;
using School.ViewModels;

namespace School.Controllers
{
    public class SpecialtiesController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        // GET: Specialties
        public ActionResult Specialties()
        {
            var model = new ParentalSpecialtiesViewModel();

            model.ScheduleYear = db.BaseScheduleYearModels.Select(x => new School.ViewModels.ContentLearningProcessModes.ScheduleYearViewModel{Id = x.Id, Year = x.ScheduleYear});

            model.Specialties = db.BaseSpecialtiesModels.Select(x => new School.ViewModels.SpecialtiesViewModel { Id = x.Id, Profession = x.Profession, CodeProfession = x.CodeProfession, Specialty = x.Specialty, CodeSpecialty = x.CodeSpecialty, AdmissionEducationalLevel = x.AdmissionEducationalLevel, FormOfEducation = x.FormOfEducation, PeriodOfTraining = x.PeriodOfTraining, EducationalDegree = x.EducationalDegree, LevelOfQualification = x.LevelOfQualification });

            return View(model);
        }
    }
}