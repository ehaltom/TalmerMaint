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
    public class LocPhoneExtsController : Controller
    {
        private EFDbContext db = new EFDbContext();



        // GET: LocPhoneExts/Create
        public ActionResult Manage(int id)
        {
            LocPhoneNums phoneNums = db.LocPhoneNums.Find(id);
            LocationPhoneExtensionsViewModel model = new LocationPhoneExtensionsViewModel
            {
                PhoneNums = phoneNums,
                Location = db.Locations
                .Find(phoneNums.LocationId),

                LocPhoneExts = new LocPhoneExts()

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocPhoneExts LocPhoneExts)
        {
            if (ModelState.IsValid)
            {
                db.LocPhoneExts.Add(LocPhoneExts);
                db.SaveChanges();
                TempData["message"] = string.Format("{0} was saved", LocPhoneExts.Name);
            }
            else
            {
                TempData["alert"] = string.Format("{0} was not saved", LocPhoneExts.Name);
            }
            return RedirectToAction("Manage", new { id = LocPhoneExts.LocPhoneNumsId });
        }

        // GET: LocPhoneExts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocPhoneExts phoneExts = db.LocPhoneExts.Find(id);
            LocPhoneNums phones = db.LocPhoneNums.Find(phoneExts.LocPhoneNumsId);
            LocationPhoneExtensionsViewModel model = new LocationPhoneExtensionsViewModel
            {
                Location = db.Locations.Find(phones.LocationId),
                LocPhoneExts = phoneExts,
                PhoneNums = phones
            };
            if (phoneExts == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: LocPhoneExts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocPhoneExts LocPhoneExts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(LocPhoneExts).State = EntityState.Modified;
                db.SaveChanges();
                TempData["message"] = string.Format("{0} has been saved", LocPhoneExts.Name);
                return RedirectToAction("Manage", new { id = LocPhoneExts.LocPhoneNumsId });
            }
            TempData["alert"] = string.Format("{0} has not been saved", LocPhoneExts.Name);
            return View(LocPhoneExts);
        }


        // POST: LocPhoneExts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LocPhoneExts LocPhoneExts = await db.LocPhoneExts.FindAsync(id);
            db.LocPhoneExts.Remove(LocPhoneExts);
            await db.SaveChangesAsync();
            TempData["message"] = "That Number has been deleted";
            return RedirectToAction("Manage", new { id = LocPhoneExts.LocPhoneNumsId });
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
