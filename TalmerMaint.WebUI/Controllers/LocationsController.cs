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

        // GET: Location
        public ViewResult Index(string state, int page = 1, string search = null)
        {
            
            LocationListViewModel model = new LocationListViewModel
            {
                Locations = repo.Locations
                .Where(l => state == null || l.State == state)
                .Where(l => search == null || l.Name.Contains(search))
                .OrderBy(l => l.Name)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = state == null ?
                    repo.Locations.Count() :
                    repo.Locations.Where(e => e.State == state).Count()
                },
                CurrentState = state
            };
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View(new Location());
        }
        public ViewResult Edit(int id)
        {
            Location loc = repo.Locations
                .FirstOrDefault(p => p.Id == id);
            return View(loc);
        }

        [HttpPost]
        public ActionResult Edit(Location loc, HttpPostedFileBase image = null)
        {
            /***** Logging initial settings *****/
            DbChangeLog log = new DbChangeLog();
            log.UserName = User.Identity.Name;
            log.Controller = "Locations";
            log.Action = (loc.Id != 0) ? "Edit" : "Create";

            if (log.Action == "Edit")
            {
                Location oldLoc = repo.Locations.FirstOrDefault(m => m.Id == loc.Id);
                log.BeforeChange = Domain.Extensions.DbLogExtensions.LocationToString(oldLoc, "");
            }
            /***** end Logging initial settings *****/


            if (ModelState.IsValid)
            {
                
                
                
                
                // without addImg the image is deleted when a location
                // is updated unless you are replacing the image.
                // addImg when false runs through adding a new image
                // which will delete the current image.
                bool addImg = false;
                string imgText = "";
                if (image != null)
                {
                    imgText = "An image has been uploaded.";
                    loc.ImageMimeType = image.ContentType;
                    loc.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(loc.ImageData, 0, image.ContentLength);
                    addImg = true;
                    
                }
                else if(loc.ImageMimeType == "deleted")
                {
                    imgText = "An image has been deleted";
                    addImg = true;

                }
                else
                {
                    imgText = "No image actions were taken on this transaction.";
                }
                
                
                

                try { 
                    repo.SaveLocation(loc, addImg);
                    log.AfterChange = Domain.Extensions.DbLogExtensions.LocationToString(loc, imgText);
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
            
            log.BeforeChange = Domain.Extensions.DbLogExtensions.LocationToString(deletedLocation, "");
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

        public FileContentResult GetImage(int id)
        {
            Location loc = repo.Locations
                .FirstOrDefault(l => l.Id == id);
            if(loc != null)
            {
                return File(loc.ImageData, loc.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
        public FileContentResult ParseImage(byte[] image, string mime)
        {
                return File(image, mime);
        }


    }
}