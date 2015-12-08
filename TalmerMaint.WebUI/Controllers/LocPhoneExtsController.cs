using System;
using System.Linq;
using System.Web.Mvc;
using TalmerMaint.Domain.Entities;
using TalmerMaint.WebUI.Models;
using TalmerMaint.Domain.Abstract;
using TalmerMaint.Domain.Services.Logging.NLog;

namespace TalmerMaint.WebUI.Controllers
{
    public class LocPhoneExtsController : Controller
    {
        private ILocationRepository context;


        public LocPhoneExtsController(ILocationRepository locationRepository)
        {
            this.context = locationRepository;
        }


        // GET: LocPhoneExts/Create
        public ActionResult Manage(int id)
        {
            LocPhoneNums phoneNums = context.LocPhoneNums.FirstOrDefault(p => p.Id == id);
            LocationPhoneExtensionsViewModel model = new LocationPhoneExtensionsViewModel
            {
                PhoneNums = phoneNums,
                Location = context.Locations
                .FirstOrDefault(l => l.Id == phoneNums.LocationId),

                LocPhoneExts = new LocPhoneExts()

            };
            return View(model);
        }



        // GET: LocPhoneExts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["alert"] = "Sorry, I could not find the item you were looking for. Please try again.";
                return View("~/Locations");
            }
            LocPhoneExts phoneExts = context.LocPhoneExts.FirstOrDefault(e => e.Id == id);
            LocPhoneNums phones = context.LocPhoneNums.FirstOrDefault(p => p.Id == phoneExts.LocPhoneNumsId);
            LocationPhoneExtensionsViewModel model = new LocationPhoneExtensionsViewModel
            {
                Location = context.Locations.FirstOrDefault(p => p.Id == phones.LocationId),
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
        public ActionResult Edit(LocPhoneExts locPhoneExts)
        {
            /***** Logging initial settings *****/
            DbChangeLog log = new DbChangeLog();
            log.UserName = User.Identity.Name;
            log.Controller = "LocPhoneExts";
            log.Action = (locPhoneExts.Id != 0) ? "Edit" : "Create";

            if (log.Action == "Edit")
            {
                LocPhoneExts oldExt = context.LocPhoneExts.FirstOrDefault(m => m.Id == locPhoneExts.Id);
                log.BeforeChange = Domain.Extensions.DbLogExtensions.LocPhoneExtToString(oldExt);
            }
            log.AfterChange = Domain.Extensions.DbLogExtensions.LocPhoneExtToString(locPhoneExts);
            /***** end Logging initial settings *****/


            if (ModelState.IsValid)
            {
                try
                {
                    context.SaveLocPhoneExt(locPhoneExts);
                    log.ItemId = locPhoneExts.Id;

                    log.Success = true;
                    TempData["message"] = string.Format("{0} has been saved", locPhoneExts.Name);
                }
                catch (Exception e)
                {
                    log.Error = e.ToString();
                    log.Success = false;
                    TempData["alert"] = string.Format("There has been an error. {0} has not been saved", locPhoneExts.Name);
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
            log.AfterChange = Domain.Extensions.DbLogExtensions.LocPhoneExtToString(locPhoneExts);
            context.SaveLog(log);
            return RedirectToAction("Edit", new { id = locPhoneExts.Id });
        }

        // POST: LocPhoneExts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int locId)
        {

            DbChangeLog log = new DbChangeLog();
            LocPhoneExts deletedLocPhoneExts = context.DeleteLocPhoneExt(id);
            log.UserName = User.Identity.Name;
            log.Controller = ControllerContext.RouteData.Values["controller"].ToString();
            log.Action = ControllerContext.RouteData.Values["action"].ToString();
            log.ItemId = id;

            log.BeforeChange = Domain.Extensions.DbLogExtensions.LocPhoneExtToString(deletedLocPhoneExts);
            if (deletedLocPhoneExts != null)
            {
                log.Success = true;

                TempData["message"] = string.Format("{0} was deleted", deletedLocPhoneExts.Name);
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
