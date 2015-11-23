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
                context.SaveLocPhoneNum(locPhoneNums);
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
                TempData["alert"] = "Sorry, I could not find the item you were looking for. Please try again.";
                return View("~/Locations");
            }
            LocPhoneNums locPhoneNums = context.LocPhoneNums.FirstOrDefault(p => p.Id == id);
            LocationPhonesViewModel model = new LocationPhonesViewModel
            {
                Location = context.Locations.FirstOrDefault(l => l.Id == locPhoneNums.LocationId),
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
                context.SaveLocPhoneNum(locPhoneNums);
                TempData["message"] = string.Format("{0} has been saved", locPhoneNums.Name);
                return RedirectToAction("Manage", new { id = locPhoneNums.LocationId });
            }
            TempData["alert"] = string.Format("{0} has not been saved", locPhoneNums.Name);
            return View(locPhoneNums);
        }


        // POST: LocPhoneNums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int LocationId)
        {
            context.DeleteLocPhoneNum(id);
            TempData["message"] = "That Number has been deleted";
            return RedirectToAction("Manage", new { id = LocationId });
        }

        protected override void Dispose(bool disposing)
        {
            
            base.Dispose(disposing);
        }
    }
}
