using System;
using System.Linq;
using System.Web.Mvc;
using TalmerMaint.Domain.Entities;
using TalmerMaint.WebUI.Models;
using TalmerMaint.Domain.Abstract;

namespace TalmerMaint.WebUI.Controllers
{
    public class LocHoursController : Controller
    {
        private ILocationRepository context;

        public LocHoursController(ILocationRepository locationRepository)
        {
            this.context = locationRepository;
        }

        // GET: LocHours/Create
        public ActionResult Manage(int id)
        {
            LocHourCats cats = context.LocHourCats.FirstOrDefault(h => h.Id == id);

            LocationHoursViewModel model = new LocationHoursViewModel
            {
                Location = context.Locations
                .FirstOrDefault(h => h.Id == cats.LocationId),
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
                context.SaveLocHours(locHours);
                TempData["message"] = string.Format("{0} was saved", locHours.Days);
            }
            else
            {
                TempData["alert"] = string.Format("{0} was not saved", locHours.Days);
            }

            return RedirectToAction("Manage","LocHours", new { id =  locHours.LocHourCatsId});
        }

        // GET: LocHours/Edit/5
        public ActionResult Edit(int? id)
        {
            LocHours hours = context.LocHours
                .FirstOrDefault(h => h.Id == id);

            LocHourCats cats = context.LocHourCats.FirstOrDefault(h => h.Id == hours.LocHourCatsId);

            LocationHoursViewModel model = new LocationHoursViewModel
            {
                Location = context.Locations
                .FirstOrDefault(h => h.Id == cats.LocationId),
                Cats = cats,

                LocHours = hours

            };
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
                context.SaveLocHours(locHours);
                TempData["message"] = string.Format("{0} has been saved", locHours.Days);

            }else
            {
            TempData["alert"] = string.Format("{0} has not been saved", locHours.Days);

            }
            return RedirectToAction("Manage", new { id = locHours.LocHourCatsId });
        }

       

        // POST: LocHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int locId)
        {
            
            context.DeleteLocHour(id);
            
            TempData["message"] = String.Format("That item was deleted");
            return RedirectToAction("Edit","Locations", new { id = locId });
        }

        protected override void Dispose(bool disposing)
        {

            base.Dispose(disposing);
        }
    }
}
