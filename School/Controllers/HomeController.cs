using School.Models;
using School.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var model = new HomePageViewModel();
            model.History = db.HistoryModels.Select(x => new HistoryViewModel { Id = x.Id, Content = x.Content });
            model.MaterialBase = db.MaterialBaseModels.Select(x => new MaterialBaseViewModel { Id = x.Id, Content = x.Content });
            model.Patron = db.PatronModels.Select(x => new PatronViewModel { Id = x.Id, Content = x.Content });

            return View(model);
        }

        public IQueryable<PersonViewModel> GetAllPeople()
        {
            var data = db.BasePersonModels.Select(x => new PersonViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Position = x.Position
            });

            return data;
        }


        public ActionResult Team()
        {
            //var person = db.BasePersonModels.Select(x => new PersonViewModel { Id = x.Id, FullName = x.FullName, Position = x.Position });
            var person = GetAllPeople().OrderBy(o => o.Id);

            return View("Team", person);
        }

        public ActionResult ScheduleYearProba()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public object posts { get; set; }
    }
}