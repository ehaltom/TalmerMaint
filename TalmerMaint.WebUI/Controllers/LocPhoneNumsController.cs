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
            /***** Logging initial settings *****/

            DbChangeLog log = new DbChangeLog();
            log.UserName = User.Identity.Name;
            log.Controller = "LocPhoneNums";
            log.Action = (locPhoneNums.Id != 0) ? "Edit" : "Create";
            log.ItemId = locPhoneNums.Id;
            // if this is an edit to an exhisting item, record the old item to the log
            if (log.Action == "Edit")
            {
                LocPhoneNums oldPhone = context.LocPhoneNums.FirstOrDefault(c => c.Id == locPhoneNums.Id);
                log.BeforeChange = Domain.Extensions.DbLogExtensions.LocPhoneToString(oldPhone);
            }

            // record the newly attempted change
            log.AfterChange = Domain.Extensions.DbLogExtensions.LocPhoneToString(locPhoneNums);

            /***** end Logging initial settings *****/

            if (ModelState.IsValid)
            {



                try
                {
                    context.SaveLocPhoneNum(locPhoneNums);

                    // need to record the id here, if this item has just been created it will not have an ID until it has been recorded to the DB
                    log.ItemId = locPhoneNums.Id;
                    log.Success = true;
                    TempData["message"] = string.Format("{0} has been saved", locPhoneNums.Name);
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

                TempData["alert"] = string.Format("{0} has not been saved", locPhoneNums.Name);

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
            return RedirectToAction("Edit", new { Id = locPhoneNums.Id });
        }



        // POST: LocPhoneNums/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            DbChangeLog log = new DbChangeLog();
            LocPhoneNums deletedPhone = context.DeleteLocPhoneNum(id);
            log.UserName = User.Identity.Name;
            log.Controller = ControllerContext.RouteData.Values["controller"].ToString();
            log.Action = ControllerContext.RouteData.Values["action"].ToString();
            log.ItemId = id;

            log.BeforeChange = Domain.Extensions.DbLogExtensions.LocPhoneToString(deletedPhone);
            if (deletedPhone != null)
            {
                log.Success = true;

                TempData["message"] = string.Format("{0} was deleted", deletedPhone.Name);
            }
            else
            {
                log.Success = false;
                log.Error = "Unable to delete location";
                TempData["alert"] = "Sorry, there was an error, that location has not been deleted";
            }
            context.SaveLog(log);
            return RedirectToAction("Edit", "Locations", new { id = deletedPhone.LocationId });
        }

        protected override void Dispose(bool disposing)
        {
            
            base.Dispose(disposing);
        }
    }
}
