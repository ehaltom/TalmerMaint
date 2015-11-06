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
using TalmerMaint.Domain.Abstract;

namespace TalmerMaint.WebUI.Controllers
{
    public class LocPhoneNumsController : Controller
    {
        private ILocationRepository context;
        EFDbContext db = new EFDbContext();

        public LocPhoneNumsController(ILocationRepository locationRepository)
        {
            this.context = locationRepository;
        }

        // GET: LocPhoneNums/Create
        public ActionResult Manage(int id)
        {
            LocationPhonesViewModel model = new LocationPhonesViewModel
            {
                Location = context.Locations
                .FirstOrDefault(p => p.Id == id),

                LocPhoneNums = new LocPhoneNums()

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocPhoneNums locPhoneNums)
        {
            if (ModelState.IsValid)
            {
                db.LocPhoneNums.Add(locPhoneNums);
                db.SaveChanges();
                TempData["message"] = string.Format("{0} was saved", locPhoneNums.Name);
            }
            else {
            TempData["alert"] = string.Format("{0} was not saved", locPhoneNums.Name);
            }
            return RedirectToAction("Manage", new { id = locPhoneNums.LocationId });
        }

        // GET: LocPhoneNums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocPhoneNums locPhoneNums = db.LocPhoneNums.Find(id);
            LocationPhonesViewModel model = new LocationPhonesViewModel
            {
                Location = db.Locations.Find(locPhoneNums.LocationId),
                LocPhoneNums = locPhoneNums
            };
            if (locPhoneNums == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: LocPhoneNums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocPhoneNums locPhoneNums)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locPhoneNums).State = EntityState.Modified;
                db.SaveChanges();
                TempData["message"] = string.Format("{0} has been saved", locPhoneNums.Name);
                return RedirectToAction("Manage", new { id = locPhoneNums.LocationId });
            }
            TempData["alert"] = string.Format("{0} has not been saved", locPhoneNums.Name);
            return View(locPhoneNums);
        }


        // POST: LocPhoneNums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id, int LocationId)
        {
            LocPhoneNums locPhoneNums = await db.LocPhoneNums.FindAsync(id);
            db.LocPhoneNums.Remove(locPhoneNums);
            await db.SaveChangesAsync();
            TempData["message"] = "That Number has been deleted";
            return RedirectToAction("Manage", new { id = LocationId });
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
