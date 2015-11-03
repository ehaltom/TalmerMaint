using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalmerMaint.Domain.Entities;
using TalmerMaint.Domain.Abstract;
using TalmerMaint.WebUI.Models;

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
            if (ModelState.IsValid)
            {
                // without addImg the image is deleted when a location
                // is updated unless you are replacing the image.
                // addImg when false runs through adding a new image
                // which will delete the current image.
                bool addImg = false;
                if (image != null)
                {
                    loc.ImageMimeType = image.ContentType;
                    loc.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(loc.ImageData, 0, image.ContentLength);
                    addImg = true;
                }
                else if(loc.ImageMimeType == "deleted")
                {
                    addImg = true;

                }
                repo.SaveLocation(loc, addImg);
                
                TempData["message"] = string.Format("{0} has been saved", loc.Name);
                
            }
            else
            {
                TempData["alert"] = string.Format("{0} has not been saved", loc.Name);
                
            }
            return View(loc);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Location deletedLocation = repo.DeleteLocation(id);
            if(deletedLocation != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedLocation.Name);
            }
            else
            {
                TempData["alert"] = string.Format("Sorry, there was an error, {0} has not been deleted", deletedLocation.Name);
            }
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

        
    }
}