using School.Models;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using System.Linq;

namespace School.Controllers
{
    public class SchoolHistoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SchoolHistory
        public ActionResult Index()
        {
            return View(db.HistoryModels.ToList());
        }

        // GET: SchoolHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryModel historyModel = db.HistoryModels.Find(id);
            if (historyModel == null)
            {
                return HttpNotFound();
            }
            return View(historyModel);
        }

        // GET: SchoolHistory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolHistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content")] HistoryModel historyModel)
        {
            if (ModelState.IsValid)
            {
                db.HistoryModels.Add(historyModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(historyModel);
        }

        // GET: SchoolHistory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryModel historyModel = db.HistoryModels.Find(id);
            if (historyModel == null)
            {
                return HttpNotFound();
            }
            return View(historyModel);
        }

        // POST: SchoolHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content")] HistoryModel historyModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historyModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(historyModel);
        }

        // GET: SchoolHistory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryModel historyModel = db.HistoryModels.Find(id);
            if (historyModel == null)
            {
                return HttpNotFound();
            }
            return View(historyModel);
        }

        // POST: SchoolHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistoryModel historyModel = db.HistoryModels.Find(id);
            db.HistoryModels.Remove(historyModel);
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
