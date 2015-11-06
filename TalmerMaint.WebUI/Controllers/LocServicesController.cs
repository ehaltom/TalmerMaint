using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TalmerMaint.Domain.Abstract;
using TalmerMaint.Domain.Entities;
using TalmerMaint.WebUI.Models;
using TalmerMaint.Domain.Concrete;

namespace TalmerMaint.WebUI.Controllers
{
    public class LocServicesController : Controller
    {
        private ILocationRepository context;
        EFDbContext db = new EFDbContext();

        public LocServicesController(ILocationRepository locationRepository)
        {
            this.context = locationRepository;
        }



        // GET: LocServices/Create
        public ActionResult Manage(int id)
        {
            LocationServicesViewModel model = new LocationServicesViewModel
            {
                Location = context.Locations
                .FirstOrDefault(p => p.Id == id),

            LocServices = new LocServices()

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocServices LocServices)
        {
            if (ModelState.IsValid)
            {
                db.LocServices.Add(LocServices);
                db.SaveChanges();
                TempData["message"] = string.Format("{0} was saved", LocServices.Name);
            }
            else
            {
                TempData["alert"] = string.Format("{0} was not saved", LocServices.Name);
            }
            return RedirectToAction("Manage", new { id = LocServices.LocationId });
        }

        // GET: LocServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocServices LocServices = db.LocServices.Find(id);
            LocationServicesViewModel model = new LocationServicesViewModel
            {
                Location = db.Locations.Find(LocServices.LocationId),
                LocServices = LocServices
            };
            if (LocServices == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: LocServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocServices LocServices)
        {
            if (ModelState.IsValid)
            {
                db.Entry(LocServices).State = EntityState.Modified;
                db.SaveChanges();
                TempData["message"] = string.Format("{0} has been saved", LocServices.Name);
                return RedirectToAction("Manage", new { id = LocServices.LocationId });
            }
            TempData["alert"] = string.Format("{0} has not been saved", LocServices.Name);
            return View(LocServices);
        }


        // POST: LocServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id, int locId)
        {
            LocServices LocServices = await db.LocServices.FindAsync(id);
            db.LocServices.Remove(LocServices);
            await db.SaveChangesAsync();
            TempData["message"] = "That service has been deleted";
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
