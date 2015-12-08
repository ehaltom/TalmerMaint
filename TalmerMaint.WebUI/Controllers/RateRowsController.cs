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
    [Authorize(Roles = "RatesAdmin")]
    public class RateRowsController : Controller
    {
        private EFDbContext db = new EFDbContext();





        // GET: RateRows/Create
        public ActionResult Create(int id)
        {
            List<RateTitle> titles = db.Rates.Find(id)
                .RateTitles.ToList();
            
            RatesRowsViewModel model = new RatesRowsViewModel
            {
                Titles = titles,
                RateRow = new RateRow()
            };
            return View(model);
        }

        // POST: RateRows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Priority,Value,RateTitleId,RatesId")] RateRow rateRow)
        {
            if (ModelState.IsValid)
            {
                db.RateRows.Add(rateRow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rateRow);
        }

        // GET: RateRows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["alert"] = "Sorry, I could not find the item you were looking for. Please try again.";
                return View("~/Locations");
            }
            RateRow rateRow = db.RateRows.Find(id);
            if (rateRow == null)
            {
                return HttpNotFound();
            }
            return View(rateRow);
        }

        // POST: RateRows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Priority,Value,RateTitleId,RatesId")] RateRow rateRow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rateRow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rateRow);
        }

        // GET: RateRows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["alert"] = "Sorry, I could not find the item you were looking for. Please try again.";
                return View("~/Locations");
            }
            RateRow rateRow = db.RateRows.Find(id);
            if (rateRow == null)
            {
                return HttpNotFound();
            }
            return View(rateRow);
        }

        // POST: RateRows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RateRow rateRow = db.RateRows.Find(id);
            db.RateRows.Remove(rateRow);
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
