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
        public async Task<ActionResult> Index()
        {
            return View(await db.Rates.ToListAsync());
        }

        // GET: Rates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rates rates = await db.Rates.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "Id,PageName,EffectiveDate")] Rates rates)
        {
            if (ModelState.IsValid)
            {
                db.Rates.Add(rates);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(rates);
        }

        // GET: Rates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rates rates = await db.Rates.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,PageName,EffectiveDate")] Rates rates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rates).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rates);
        }

        // GET: Rates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rates rates = await db.Rates.FindAsync(id);
            if (rates == null)
            {
                return HttpNotFound();
            }
            return View(rates);
        }

        // POST: Rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Rates rates = await db.Rates.FindAsync(id);
            db.Rates.Remove(rates);
            await db.SaveChangesAsync();
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
