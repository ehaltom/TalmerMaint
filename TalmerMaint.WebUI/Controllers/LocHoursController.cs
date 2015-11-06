using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TalmerMaint.Domain.Concrete;
using TalmerMaint.Domain.Entities;
using TalmerMaint.WebUI.Models;
using TalmerMaint.Domain.Abstract;

namespace TalmerMaint.WebUI.Controllers
{
    public class LocHoursController : Controller
    {
        private ILocationRepository context;
        EFDbContext db = new EFDbContext();

        public LocHoursController(ILocationRepository locationRepository)
        {
            this.context = locationRepository;
        }

        // GET: LocHours/Create
        public ActionResult Manage(int id)
        {
            LocHourCats cats = db.LocHourCats.Find(id);

            LocationHoursViewModel model = new LocationHoursViewModel
            {
                Location = db.Locations
                .Find(cats.LocationId),
                Cats = cats,

                LocHours = new LocHours()

            };
            return View(model);
        }

        // POST: LocHours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocHours locHours)
        {
            if (ModelState.IsValid)
            {
                db.LocHours.Add(locHours);
                db.SaveChanges();
                TempData["message"] = string.Format("{0} was saved", locHours.Days);
            }
            else
            {
                TempData["alert"] = string.Format("{0} was not saved", locHours.Days);
            }

            return RedirectToAction("Manage","LocHourCats", new { id =  locHours.LocHourCatsId});
        }

        // GET: LocHours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocHours locHours = db.LocHours.Find(id);
            LocationHoursViewModel model = new LocationHoursViewModel
            {
                Location = db.Locations.Find(locHours.LocHourCatsId),
                LocHours = locHours
            };
            if (locHours == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: LocHours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocHours locHours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locHours).State = EntityState.Modified;
                db.SaveChanges();
                TempData["message"] = string.Format("{0} has been saved", locHours.Days);
               
            }
            TempData["alert"] = string.Format("{0} has not been saved", locHours.Days);
            return RedirectToAction("Manage", new { id = locHours.LocHourCatsId });
        }

       

        // POST: LocHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int locId)
        {
            LocHours locHours = db.LocHours.Find(id);
            db.LocHours.Remove(locHours);
            db.SaveChanges();
            TempData["message"] = String.Format("That item was deleted");
            return RedirectToAction("Manage", new { id = locId });
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
