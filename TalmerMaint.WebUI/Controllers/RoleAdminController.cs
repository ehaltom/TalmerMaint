using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TalmerMaint.Domain.Entities;
using TalmerMaint.WebUI.Infrastructure;
using System.Collections.Generic;
using TalmerMaint.WebUI.Models;

namespace TalmerMaint.WebUI.Controllers
{
    [Authorize(Roles = "UserAdmin")]
    public class RoleAdminController : Controller
    {
        // GET: RoleAdmin
        public ActionResult Index()
        {
            return View(RoleManager.Roles);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Required]string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = RoleManager.Create(new AppRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(name);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            AppRole role = RoleManager.FindById(id);
            if(role != null)
            {
                IdentityResult result = RoleManager.Delete(role);
                if (result.Succeeded)
                {
                    TempData["message"] = string.Format("{0} role was deleted", role.Name);
                }
                else
                {
                    TempData["message"] = string.Format("{0} role was not deleted", role.Name);
                }
                
            }
            else
            {
                TempData["message"] = string.Format("{0} role was not deleted", role.Name);
            }
            return View("Index", RoleManager.Roles);
        }

        public ActionResult Edit(string id)
        {
            AppRole role = RoleManager.FindById(id);
            string[] memberIds = role.Users.Select(x => x.UserId).ToArray();
            IEnumerable<AppUser> members = UserManager.Users.Where(x => memberIds.Any(y => y == x.Id));
            IEnumerable<AppUser> nonMembers = UserManager.Users.Except(members);
            return View(new RoleEditModel
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpPost]
        public ActionResult Edit(RoleModificationModel model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach(string userId in model.IdsToAdd ?? new string[] { })
                {
                    result = UserManager.AddToRole(userId, model.RoleName);
                    if (!result.Succeeded)
                    {

                        return View("Error", result.Errors);
                    }
                }
                foreach(string userId in model.IdsToDelete ?? new string[] { })
                {
                    result = UserManager.RemoveFromRole(userId, model.RoleName);
                    if (!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }
                return RedirectToAction("Index");
            }
            return View("Error", new string[] { "Role not found." });
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach(string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private AppUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); }
        }

        private AppRoleManager RoleManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<AppRoleManager>(); }
        }
        protected override void Dispose(bool disposing)
        {

            base.Dispose(disposing);
        }
    }
}