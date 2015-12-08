using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TalmerMaint.Domain.Concrete;
using TalmerMaint.Domain.Entities;

namespace TalmerMaint.WebUI.Controllers
{
    [Authorize(Roles = "RatesAdmin")]
    public class RatesController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: Rates
        public ActionResult Index()
        {
            return View(db.Rates.ToList());
        }

        // GET: Rates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                TempData["alert"] = "Sorry, I could not find the item you were looking for. Please try again.";
                return View("~/Locations");
            }
            Rates rates = db.Rates.Find(id);
            if (rates == null)
            {
                return HttpNotFound();
            }
            rates.RateTitles = rates.RateTitles.OrderBy(t => t.Priority).ToList();
            return View(rates);
        }

        // GET: Rates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PageName,EffectiveDate")] Rates rates)
        {
            if (ModelState.IsValid)
            {
                db.Rates.Add(rates);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rates);
        }

        // GET: Rates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["alert"] = "Sorry, I could not find the item you were looking for. Please try again.";
                return View("~/Locations");
            }
            Rates rates = db.Rates.Find(id);
            if (rates == null)
            {
                return HttpNotFound();
            }
            return View(rates);
        }

        // POST: Rates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PageName,EffectiveDate")] Rates rates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rates).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rates);
        }

        // GET: Rates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["alert"] = "Sorry, I could not find the item you were looking for. Please try again.";
                return View("~/Locations");
            }
            Rates rates = db.Rates.Find(id);
            if (rates == null)
            {
                return HttpNotFound();
            }
            return View(rates);
        }

        // POST: Rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rates rates = db.Rates.Find(id);
            db.Rates.Remove(rates);
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
