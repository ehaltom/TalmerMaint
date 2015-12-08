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
            /***** Logging initial settings *****/

                DbChangeLog log = new DbChangeLog();
                log.UserName = User.Identity.Name;
                log.Controller = "LocHourCats";
                log.Action = (locHourCats.Id != 0) ? "Edit" : "Create";
                log.ItemId = locHourCats.Id;
                // if this is an edit to an exhisting item, record the old item to the log
                if (log.Action == "Edit")
                {
                    LocHourCats oldCat = context.LocHourCats.FirstOrDefault(c => c.Id == locHourCats.Id);
                    log.BeforeChange = Domain.Extensions.DbLogExtensions.LocCatToString(oldCat);
                }

                // record the newly attempted change
                log.AfterChange = Domain.Extensions.DbLogExtensions.LocCatToString(locHourCats);

            /***** end Logging initial settings *****/

            if (ModelState.IsValid)
            {
                


                try
                {
                    context.SaveLocHourCat(locHourCats);

                    // need to record the id here, if this item has just been created it will not have an ID until it has been recorded to the DB
                    log.ItemId = locHourCats.Id;
                    log.Success = true;
                    TempData["message"] = string.Format("{0} has been saved", locHourCats.Name);
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
                
                TempData["alert"] = string.Format("{0} has not been saved", locHourCats.Name);

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
            return RedirectToAction("Edit",new { Id = locHourCats.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            DbChangeLog log = new DbChangeLog();
            LocHourCats deletedCat = context.DeleteLocHourCat(id);
            log.UserName = User.Identity.Name;
            log.Controller = ControllerContext.RouteData.Values["controller"].ToString();
            log.Action = ControllerContext.RouteData.Values["action"].ToString();
            log.ItemId = id;

            log.BeforeChange = Domain.Extensions.DbLogExtensions.LocCatToString(deletedCat);
            if (deletedCat != null)
            {
                log.Success = true;

                TempData["message"] = string.Format("{0} was deleted", deletedCat.Name);
            }
            else
            {
                log.Success = false;
                log.Error = "Unable to delete location";
                TempData["alert"] = "Sorry, there was an error, that location has not been deleted";
            }
            context.SaveLog(log);
            return RedirectToAction("Edit","Locations", new { id = deletedCat.LocationId });
        }

        
        
        protected override void Dispose(bool disposing)
        {
            
            base.Dispose(disposing);
        }
    }
}
