using System;
using System.Linq;
using System.Web.Mvc;
using TalmerMaint.Domain.Entities;
using TalmerMaint.WebUI.Models;
using TalmerMaint.Domain.Abstract;
using TalmerMaint.Domain.Services.Logging.NLog;

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



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocHours locHours)
        {
            /***** Logging initial settings *****/
            DbChangeLog log = new DbChangeLog();
            log.UserName = User.Identity.Name;
            log.Controller = "LocHours";
            log.Action = (locHours.Id != 0) ? "Edit" : "Create";
            
            if (log.Action == "Edit")
            {
                LocHours oldHours = context.LocHours.FirstOrDefault(m => m.Id == locHours.Id);
                log.BeforeChange = Domain.Extensions.DbLogExtensions.LocHoursToString(oldHours);
            }
            log.AfterChange = Domain.Extensions.DbLogExtensions.LocHoursToString(locHours);
            /***** end Logging initial settings *****/


            if (ModelState.IsValid)
            {
                try
                {
                    context.SaveLocHours(locHours);
                    log.ItemId = locHours.Id;

                    log.Success = true;
                    TempData["message"] = string.Format("{0} : {1} has been saved", locHours.Days, locHours.Hours);
                }
                catch (Exception e)
                {
                    log.Error = e.ToString();
                    log.Success = false;
                    TempData["alert"] = string.Format("There has been an error. {0} : {1} has not been saved", locHours.Days, locHours.Hours);
                }
                


            }
            else
            {
                

                log.Error = "Errors: ";
                NLogLogger logger = new NLogLogger();
                logger.Info("There has been a validation error, this record has not been saved");
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        log.Error += error + "<br />";

                    }
                }
                TempData["alert"] = "There has been a validation error, this record has not been saved";

            }
            log.AfterChange = Domain.Extensions.DbLogExtensions.LocHoursToString(locHours);
            context.SaveLog(log);
            return RedirectToAction("Edit",new { id = locHours.Id });
        }

        // POST: LocHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int locId)
        {

            DbChangeLog log = new DbChangeLog();
            LocHours deletedLocHours = context.DeleteLocHour(id);
            log.UserName = User.Identity.Name;
            log.Controller = ControllerContext.RouteData.Values["controller"].ToString();
            log.Action = ControllerContext.RouteData.Values["action"].ToString();
            log.ItemId = id;

            log.BeforeChange = Domain.Extensions.DbLogExtensions.LocHoursToString(deletedLocHours);
            if (deletedLocHours != null)
            {
                log.Success = true;

                TempData["message"] = string.Format("{0} : {1} was deleted", deletedLocHours.Days, deletedLocHours.Hours);
            }
            else
            {
                log.Success = false;
                log.Error = "Unable to delete location";
                TempData["alert"] = "Sorry, there was an error, that location has not been deleted";
            }
            context.SaveLog(log);
            return RedirectToAction("Edit", "Locations", new { id = locId });
        }

        protected override void Dispose(bool disposing)
        {

            base.Dispose(disposing);
        }
    }
}
