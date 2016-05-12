using School.Models;
using School.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class ConsultationsController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        // GET: Consultations
        public ActionResult Consultations()
        {
            var model = new ConsultationsViewModel();

            model.ScheduleYear = db.BaseScheduleYearModels.Select(x => new ContentLearningProcessModes.ScheduleYearViewModel { Id = x.Id, Year = x.ScheduleYear });

            model.ConsultationTable = db.BaseConsultationsModels.Select(x => new ConsultationsTableViewModel { Id = x.Id, TeacherName = x.TeacherName, Subject = x.Subject, DayOfTheWeek = x.DayOfTheWeek, Classroom = x.Classroom, StartTime = x.StartTime });

            //var model = db.BaseConsultationsModels.Select(x => new ConsultationsTableViewModel { Id = x.Id, TeacherName = x.TeacherName, Subject = x.Subject, DayOfTheWeek = x.DayOfTheWeek, Classroom = x.Classroom, StartTime = x.StartTime });

            return View(model);
        }
    }
}