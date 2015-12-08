using System;
using System.Linq;
using System.Web.Mvc;
using TalmerMaint.Domain.Abstract;
using TalmerMaint.Domain.Entities;
using TalmerMaint.WebUI.Models;

namespace TalmerMaint.WebUI.Controllers
{
    public class LocServicesController : Controller
    {
        private ILocationRepository context;


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


        // GET: LocServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["alert"] = "Sorry, I could not find the item you were looking for. Please try again.";
                return View("~/Locations");
            }
            LocServices LocServices = context.LocServices.FirstOrDefault(s => s.Id == id);
            LocationServicesViewModel model = new LocationServicesViewModel
            {
                Location = context.Locations.FirstOrDefault(l => l.Id == LocServices.LocationId),
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
        public ActionResult Edit(LocServices locServices)
        {
            /***** Logging initial settings *****/

            DbChangeLog log = new DbChangeLog();
            log.UserName = User.Identity.Name;
            log.Controller = "LocServices";
            log.Action = (locServices.Id != 0) ? "Edit" : "Create";
            log.ItemId = locServices.Id;
            // if this is an edit to an exhisting item, record the old item to the log
            if (log.Action == "Edit")
            {
                LocServices oldService = context.LocServices.FirstOrDefault(c => c.Id == locServices.Id);
                log.BeforeChange = Domain.Extensions.DbLogExtensions.LocServiceToString(oldService);
            }

            // record the newly attempted change
            log.AfterChange = Domain.Extensions.DbLogExtensions.LocServiceToString(locServices);

            /***** end Logging initial settings *****/

            if (ModelState.IsValid)
            {



                try
                {
                    context.SaveLocService(locServices);

                    // need to record the id here, if this item has just been created it will not have an ID until it has been recorded to the DB
                    log.ItemId = locServices.Id;
                    log.Success = true;
                    TempData["message"] = string.Format("{0} has been saved", locServices.Name);
                }

                catch (Exception e)
                {
                    log.Error = e.ToString();
                    log.Success = false;
                    TempData["alert"] = "There has been an error. That item has not been saved";
                }

            }
            else
            {

                TempData["alert"] = string.Format("{0} has not been saved", locServices.Name);

                // record the errors and error status to the log
                log.Success = false;
                log.Error = "Errors: ";
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        log.Error += error + "<br />";

                    }
                }
            }

            context.SaveLog(log);
            return RedirectToAction("Edit", new { id = locServices.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            DbChangeLog log = new DbChangeLog();
            LocServices deletedService = context.DeleteLocService(id);
            log.UserName = User.Identity.Name;
            log.Controller = ControllerContext.RouteData.Values["controller"].ToString();
            log.Action = ControllerContext.RouteData.Values["action"].ToString();
            log.ItemId = id;

            log.BeforeChange = Domain.Extensions.DbLogExtensions.LocServiceToString(deletedService);
            if (deletedService != null)
            {
                log.Success = true;

                TempData["message"] = string.Format("{0} was deleted", deletedService.Name);
            }
            else
            {
                log.Success = false;
                log.Error = "Unable to delete location";
                TempData["alert"] = "Sorry, there was an error, that Service has not been deleted";
            }
            context.SaveLog(log);
            return RedirectToAction("Edit", "Locations", new { id = deletedService.LocationId });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
