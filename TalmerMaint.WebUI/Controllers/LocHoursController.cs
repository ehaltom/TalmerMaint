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

namespace TalmerMaint.WebUI.Controllers
{
    public class LocHoursController : Controller
    {
        private EFDbContext db = new EFDbContext();

      
        // GET: LocHours/Create
        public ActionResult Manage(int id)
        {
            LocationHoursViewModel model = new LocationHoursViewModel
            {
                Location = db.Locations
                .Find(id),

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
                TempData["message"] = string.Format("{0} was saved", locHours.HoursTitle);
            }
            else
            {
                TempData["alert"] = string.Format("{0} was not saved", locHours.HoursTitle);
            }
            return RedirectToAction("Manage", new { id = locHours.LocationId });
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
                Location = db.Locations.Find(locHours.LocationId),
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
        public ActionResult Edit([Bind(Include = "Id,HoursTitle,Hours,LocationId")] LocHours locHours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locHours).State = EntityState.Modified;
                db.SaveChanges();
                TempData["message"] = string.Format("{0} has been saved", locHours.HoursTitle);
                return RedirectToAction("Manage", new { id = locHours.LocationId });
            }
            TempData["alert"] = string.Format("{0} has not been saved", locHours.HoursTitle);
            return View(locHours);
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
