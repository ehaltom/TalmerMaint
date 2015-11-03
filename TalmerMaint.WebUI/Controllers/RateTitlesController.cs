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
        public async Task<ActionResult> Index()
        {
            return View(await db.RateTitles.ToListAsync());
        }

        // GET: RateTitles/Details/5
        public async Task<ActionResult> Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RateTitle rateTitle = await db.RateTitles.FindAsync(id);
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
        public async Task<ActionResult> Create(RateTitle rateTitle)
        {
            if (ModelState.IsValid)
            {
                db.RateTitles.Add(rateTitle);
                await db.SaveChangesAsync();
                return RedirectToAction("Create", new { id = rateTitle.RatesId }); ;
            }

            return View(rateTitle);
        }

        // GET: RateTitles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RateTitle rateTitle = await db.RateTitles.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Priority,RatesId")] RateTitle rateTitle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rateTitle).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Create", new { id = rateTitle.RatesId });
            }
            return View(rateTitle);
        }

        // GET: RateTitles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RateTitle rateTitle = await db.RateTitles.FindAsync(id);
            if (rateTitle == null)
            {
                return HttpNotFound();
            }
            return View(rateTitle);
        }

        // POST: RateTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RateTitle rateTitle = await db.RateTitles.FindAsync(id);
            db.RateTitles.Remove(rateTitle);
            await db.SaveChangesAsync();
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
