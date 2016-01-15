using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalmerMaint.Domain.Entities;
using TalmerMaint.Domain.Abstract;
using TalmerMaint.WebUI.Models;
using System.Collections;
using TalmerMaint.Domain.Services.Logging.NLog;
using System;

namespace TalmerMaint.WebUI.Controllers
{
    [Authorize(Roles ="LocationAdmin")]
    public class LocationsController : Controller
    {
        private ILocationRepository repo;
        public int PageSize = 12;

        public LocationsController(ILocationRepository locationRepository)
        {
            this.repo = locationRepository;
           
        }

        public ActionResult Autocomplete(string term)
        {
            var model = repo.Locations
                .Where(l => l.Name.Contains(term) || l.City.Contains(term) || l.Address1.Contains(term))
                .Take(10)
                .Select(l => new
                {
                    label = l.Name
                });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // GET: Location
        public ActionResult Index(string state, int page = 1, string search = null)
        {
            IEnumerable<Location> locs = repo.Locations
                .Where(l => state == null || l.State == state)
                .Where(l => search == null || l.Name.Contains(search) || l.City.Contains(search) || l.Address1.Contains(search))
                .OrderBy(l => l.Name)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);
            int count = locs.Count();
            LocationListViewModel model = new LocationListViewModel
            {
                Locations = locs,

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repo.Locations.Where(l => search == null || l.Name.Contains(search) || l.City.Contains(search) || l.Address1.Contains(search)).Where(e => e.State == state).Count()
                },
                CurrentState = state
            };
            if (Request.IsAjaxRequest())
            {
                return PartialView("LocationSummary", model);
            }
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View(new Location());
        }
        public ViewResult Edit(int id)
        {
            Location model = repo.Locations
                .FirstOrDefault(p => p.Id == id);
            model.LocImage = repo.ImageByLocationID(id);
            model.LocImage.LocationId = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Location loc)
        {
            /***** Logging initial settings *****/
            DbChangeLog log = new DbChangeLog();
            log.UserName = User.Identity.Name;
            log.Controller = "Locations";
            log.Action = (loc.Id != 0) ? "Edit" : "Create";

            if (log.Action == "Edit")
            {
                Location oldLoc = repo.Locations.FirstOrDefault(m => m.Id == loc.Id);
                log.BeforeChange = Domain.Extensions.DbLogExtensions.LocationToString(oldLoc);
            }
            /***** end Logging initial settings *****/


            if (ModelState.IsValid)
            {
                try { 
                    repo.SaveLocation(loc);
                    log.AfterChange = Domain.Extensions.DbLogExtensions.LocationToString(loc);
                    log.Success = true;
                    TempData["message"] = string.Format("{0} has been saved", loc.Name);
                }
                
                catch(Exception e)
                {
                    log.Error = e.ToString();
                    log.Success = false;
                    TempData["alert"] = string.Format("There has been an error. {0} has not been saved", loc.Name);
                }
                log.ItemId = loc.Id;
                

            }
            else
            {
                log.Error = "Errors: ";
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        log.Error += error + "<br />";

                    }
                }
                TempData["alert"] = string.Format("{0} has not been saved");
                
            }
            repo.SaveLog(log);
            Location retLoc = repo.Locations.FirstOrDefault(p => p.Id == loc.Id);
            return View(retLoc);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            DbChangeLog log = new DbChangeLog();
            Location deletedLocation = repo.DeleteLocation(id);
            log.UserName = User.Identity.Name;
            log.Controller = ControllerContext.RouteData.Values["controller"].ToString();
            log.Action = ControllerContext.RouteData.Values["action"].ToString();
            log.ItemId = id;
            
            log.BeforeChange = Domain.Extensions.DbLogExtensions.LocationToString(deletedLocation);
            if(deletedLocation != null)
            {
                log.Success = true;
                
                TempData["message"] = string.Format("{0} was deleted", deletedLocation.Name);
            }
            else
            {
                log.Success = false;
                log.Error = "Unable to delete location";
                TempData["alert"] = "Sorry, there was an error, that location has not been deleted";
            }
            repo.SaveLog(log);
            return RedirectToAction("Index");
        }

        


    }
}