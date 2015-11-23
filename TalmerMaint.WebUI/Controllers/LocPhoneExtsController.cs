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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocPhoneExts locPhoneExts)
        {
            if (ModelState.IsValid)
            {
                context.SaveLocPhoneExt(locPhoneExts);
                TempData["message"] = string.Format("{0} was saved", locPhoneExts.Name);
            }
            else
            {
                TempData["alert"] = string.Format("{0} was not saved", locPhoneExts.Name);
            }
            return RedirectToAction("Manage", new { id = locPhoneExts.LocPhoneNumsId });
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
            if (ModelState.IsValid)
            {
                context.SaveLocPhoneExt(locPhoneExts);
                TempData["message"] = string.Format("{0} was saved", locPhoneExts.Name);
            }
            else
            {
                TempData["alert"] = string.Format("{0} was not saved", locPhoneExts.Name);
            }
            return RedirectToAction("Manage", new { id = locPhoneExts.LocPhoneNumsId });
        }


        // POST: LocPhoneExts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int locId)
        {
            context.DeleteLocPhoneExt(id);
            TempData["message"] = "That Number has been deleted";
            return RedirectToAction("Edit", "Locations", new { id = locId });
        }

        protected override void Dispose(bool disposing)
        {
          
            base.Dispose(disposing);
        }
    }
}
