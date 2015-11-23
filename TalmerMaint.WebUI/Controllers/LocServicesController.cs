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
        public ActionResult Manage([Bind(Include = "Featured,Name,Description,IconClassName,LocationId")]LocServices LocServices)
        {
            if (ModelState.IsValid)
            {
                context.SaveLocService(LocServices);
                TempData["message"] = string.Format("{0} was saved", LocServices.Name);
                return RedirectToAction("Manage", new { id = LocServices.LocationId });
            }
            else
            {
                string values = "";
                foreach(ModelState val in ViewData.ModelState.Values)
                {
                    foreach(ModelError err in val.Errors)
                    {
                        values += " --- " + err.ErrorMessage + " --- ";
                    }
                }
                TempData["alert"] = "There was an issue, The item was not saved<br />" + values;
                return RedirectToAction("Index", "Locations");
            }
            
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
        public ActionResult Edit(LocServices LocServices)
        {
            if (ModelState.IsValid)
            {
                context.SaveLocService(LocServices);
                TempData["message"] = string.Format("{0} has been saved", LocServices.Name);
                return RedirectToAction("Manage", new { id = LocServices.LocationId });
            }
            else {
                TempData["alert"] = string.Format("{0} has not been saved", LocServices.Name);
                return RedirectToAction("Index", "Locations");
            }
            
            
            
        }


        // POST: LocServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int locId)
        {
            context.DeleteLocService(id);
            TempData["message"] = "That service has been deleted";
            return RedirectToAction("Manage", new { id = locId });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
