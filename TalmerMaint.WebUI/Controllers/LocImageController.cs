using System;
using System.Linq;
using System.Web.Mvc;
using TalmerMaint.Domain.Abstract;
using TalmerMaint.Domain.Entities;
using TalmerMaint.WebUI.Models;
using System.Web;

namespace TalmerMaint.WebUI.Controllers
{
    public class LocImageController : Controller
    {
        private ILocationRepository context;


        public LocImageController(ILocationRepository locationRepository)
        {
            this.context = locationRepository;
        }



        // GET: LocImage/Create
        public ActionResult Manage(int id)
        {


            Location model = context.Locations
            .FirstOrDefault(p => p.Id == id);


            model.LocImage = context.ImageByLocationID(id);

            return View(model);
        }


        // GET: LocImage/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                TempData["alert"] = "Sorry, I could not find the item you were looking for. Please try again.";
                return View("~/Locations");
            }
            LocImage LocImage = context.ImageByLocationID(id);

            Location model = context.Locations.FirstOrDefault(l => l.Id == LocImage.LocationId);
                model.LocImage = LocImage;
            if (LocImage == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: LocImage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage([Bind(Include = "Id, LocationId, FeaturedImg")]LocImage LocImage, HttpPostedFileBase image)
        {
            /***** Logging initial settings *****/

            DbChangeLog log = new DbChangeLog();
            log.UserName = User.Identity.Name;
            log.Controller = "LocImage";
            Console.WriteLine("LocImage ID = " + LocImage.Id);
            log.Action = (LocImage.Id == 0) ? "Create" : "Edit";
            log.ItemId = LocImage.Id;
            // if this is an edit to an exhisting item, record the old item to the log
            if (log.Action == "Edit")
            {
                LocImage oldImage = context.ImageByLocationID(LocImage.LocationId);
                log.BeforeChange = Domain.Extensions.DbLogExtensions.LocImageToString(oldImage, "Image is being replaced");
            }
            if(image != null)
            {
                LocImage.ImageMimeType = image.ContentType;
                LocImage.ImageData = new byte[image.ContentLength];
                image.InputStream.Read(LocImage.ImageData, 0, image.ContentLength);
            }
            // record the newly attempted change
            


            
            /***** end Logging initial settings *****/

            if (ModelState.IsValid)
            {
                try
                {
                    context.SaveLocImage(LocImage);

                    // need to record the id here, if this item has just been created it will not have an ID until it has been recorded to the DB
                    log.ItemId = LocImage.Id;
                    log.Success = true;
                    log.AfterChange = Domain.Extensions.DbLogExtensions.LocImageToString(LocImage, "");
                    TempData["message"] = string.Format("The image has been saved");
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

                TempData["alert"] = string.Format("The image has not been saved. Please try again.");

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

            Location model = context.Locations
            .FirstOrDefault(p => p.Id == LocImage.LocationId);

            model.LocImage = LocImage;
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            DbChangeLog log = new DbChangeLog();
            LocImage deletedImage = context.DeleteLocImage(id);
            log.UserName = User.Identity.Name;
            log.Controller = ControllerContext.RouteData.Values["controller"].ToString();
            log.Action = ControllerContext.RouteData.Values["action"].ToString();
            log.ItemId = id;

            log.BeforeChange = Domain.Extensions.DbLogExtensions.LocImageToString(deletedImage, "The image is deleted");
            if (deletedImage != null)
            {
                log.Success = true;

                TempData["message"] = string.Format("The image was deleted");
            }
            else
            {
                log.Success = false;
                log.Error = "Unable to delete image";
                TempData["alert"] = "Sorry, there was an error, that Service has not been deleted";
            }
            context.SaveLog(log);
            return RedirectToAction("Edit", "Locations", new { id = deletedImage.LocationId });
        }
        public FileContentResult GetImage(int id)
        {
            LocImage loc = (from n in context.LocImages
                            where n.Id == id
                            where n.FeaturedImg == true
                            select n).FirstOrDefault();

            if (loc != null)
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
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}