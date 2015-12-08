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
using TalmerMaint.WebUI.Models;

namespace TalmerMaint.WebUI.Controllers
{
    [Authorize(Roles ="RatesAdmin")]
    public class RateTitlesController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: RateTitles
        public ActionResult Index()
        {
            return View(db.RateTitles.ToList());
        }

        // GET: RateTitles/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                TempData["alert"] = "Sorry, I could not find the item you were looking for. Please try again.";
                return View("~/Locations");
            }
            RateTitle rateTitle = db.RateTitles.Find(id);
            if (rateTitle == null)
            {
                return HttpNotFound();
            }
            return View(rateTitle);
        }

        // GET: RateTitles/Create
        public ActionResult Create(int id)
        {
            Rates rates = db.Rates.Find(id);

            rates.RateTitles = rates.RateTitles.OrderBy(t => t.Priority).ToList();
            RatesTitlesViewModel model = new RatesTitlesViewModel
            {
                RateTitle = new RateTitle(),
                Rates = rates
            };
            if (model.Rates != null)
            {
                return View(model);
            }
            else
            {
                TempData["alert"] = "No Rates info was found";
                return View(model);
            }
        }

        // POST: RateTitles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RateTitle rateTitle)
        {
            if (ModelState.IsValid)
            {
                db.RateTitles.Add(rateTitle);
                db.SaveChanges();
                return RedirectToAction("Create", new { id = rateTitle.RatesId }); ;
            }

            return View(rateTitle);
        }

        // GET: RateTitles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["alert"] = "Sorry, I could not find the item you were looking for. Please try again.";
                return View("~/Locations");
            }
            RateTitle rateTitle = db.RateTitles.Find(id);
            if (rateTitle == null)
            {
                return HttpNotFound();
            }
            return View(rateTitle);
        }

        // POST: RateTitles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Priority,RatesId")] RateTitle rateTitle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rateTitle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create", new { id = rateTitle.RatesId });
            }
            return View(rateTitle);
        }

        // GET: RateTitles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["alert"] = "Sorry, I could not find the item you were looking for. Please try again.";
                return View("~/Locations");
            }
            RateTitle rateTitle = db.RateTitles.Find(id);
            if (rateTitle == null)
            {
                return HttpNotFound();
            }
            return View(rateTitle);
        }

        // POST: RateTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RateTitle rateTitle =  db.RateTitles.Find(id);
            db.RateTitles.Remove(rateTitle);
            db.SaveChanges();
            return RedirectToAction("Details", "Rates", new { id = rateTitle.RatesId });
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
