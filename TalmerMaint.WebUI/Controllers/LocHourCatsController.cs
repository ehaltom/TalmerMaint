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
    public class LocHourCatsController : Controller
    {
        private ILocationRepository context;


        public LocHourCatsController(ILocationRepository locationRepository)
        {
            this.context = locationRepository;
        }

        // GET: LocHourCats
        public ActionResult Manage(int id)
        {
            LocationCatsViewModel model = new LocationCatsViewModel
            {
                Location = context.Locations
                .FirstOrDefault(p => p.Id == id),

                LocHourCats = new LocHourCats()

            };
            return View(model);
        }


        // POST: LocHourCats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocHourCats locHourCats)
        {
            if (ModelState.IsValid)
            {
                
                context.SaveLocHourCat(locHourCats);
                TempData["message"] = string.Format("{0} was saved", locHourCats.Name);
            }
            else
            {
                string values = "Id = " +locHourCats.Id + "<br />";
                values += "LocationId = " + locHourCats.LocationId + "<br />";
                values += "Name = " + locHourCats.Name + "<br />";

                TempData["alert"] = "There was an issue, The item was not saved<br />" + values;
            }
            
            return RedirectToAction("Manage", new { id = locHourCats.LocationId });
        }



        // GET: LocHourCats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["alert"] = "Sorry, I could not find the item you were looking for. Please try again.";
                return View("~/Locations");
            }
            LocHourCats locHours = context.LocHourCats.FirstOrDefault(p => p.Id == id);

            LocationCatsViewModel model = new LocationCatsViewModel
            {
                Location = context.Locations.FirstOrDefault(l => l.Id == locHours.LocationId),
                LocHourCats = locHours
            };
            if (locHours == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }


       

        // POST: LocHourCats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocHourCats locHourCats)
        {
            if (ModelState.IsValid)
            {
                
                context.SaveLocHourCat(locHourCats);
                TempData["message"] = string.Format("{0} has been saved", locHourCats.Name);
                return RedirectToAction("Manage", new { id = locHourCats.LocationId });
            }
            TempData["alert"] = string.Format("{0} has not been saved", locHourCats.Name);
            return View(locHourCats);
        }

        // GET: LocHourCats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["alert"] = "Sorry, I could not find the item you were looking for. Please try again.";
                return View("~/Locations");
            }

            LocHourCats locHourCats = context.LocHourCats.FirstOrDefault(l => l.Id == id);
            if (locHourCats == null)
            {
                return HttpNotFound();
            }
            return View(locHourCats);
        }

        // POST: LocHourCats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int locId)
        {
            context.DeleteLocHourCat(id);
            TempData["message"] = String.Format("That item was deleted");
            return RedirectToAction("Manage", new { id = locId });
        }

        protected override void Dispose(bool disposing)
        {
            
            base.Dispose(disposing);
        }
    }
}
