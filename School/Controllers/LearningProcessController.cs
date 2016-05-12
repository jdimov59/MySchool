using School.Models;
using School.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class LearningProcessController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        // GET: LearningProcess
        public ActionResult LearningProcess()
        {
            var model = new LearningProcessViewModels();
            model.ScheduleYear = db.BaseScheduleYearModels.Select(x => new ContentLearningProcessModes.ScheduleYearViewModel { Id = x.Id, Year = x.ScheduleYear });
            model.Vacations = db.BaseVacationsModels.Select(x => new ContentLearningProcessModes.VacationsViewModel { Id = x.Id, Text = x.Text, Date = x.Date});
            model.OffDays = db.BaseOffDaysModels.Select(x => new ContentLearningProcessModes.OffDaysViewModel { Id = x.Id, Text =x.Text, Date = x.Date });
            model.LentTermStart = db.BaseLentTermStartModels.Select(x => new ContentLearningProcessModes.LentTermStartViewModel { Id = x.Id, Text = x.Text, Date = x.Date });
            model.LentTermEnd = db.BaseLentTermEndModels.Select(x => new ContentLearningProcessModes.LentTermEndViewModel { Id = x.Id, Text = x.Text, Date = x.Date });

            return View(model);
        }

        public ActionResult Hours()
        {
            var model = new HoursViewModel();
            model.ScheduleYear = db.BaseScheduleYearModels.Select(x => new ContentLearningProcessModes.ScheduleYearViewModel { Id = x.Id, Year = x.ScheduleYear });
            model.HoursTable = db.BaseHoursModels.Select(x => new HoursTableViewModel { Id = x.Id, Hours = x.Hours, Start = x.Start, End = x.End});
            return View(model);
        }
    }
}