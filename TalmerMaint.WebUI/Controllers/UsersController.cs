using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using TalmerMaint.WebUI.Infrastructure;
using TalmerMaint.WebUI.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using TalmerMaint.Domain.Entities;

namespace TalmerMaint.WebUI.Controllers
{
    [Authorize(Roles ="UserAdmin")]
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View(UserManager.Users);
        }

        private AppUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { UserName = model.Name, Email = model.Email };
                IdentityResult result = UserManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            AppUser user = UserManager.FindById(id);
            if(user != null)
            {
                IdentityResult result = UserManager.Delete(user);
                if (result.Succeeded)
                {
                    TempData["message"] = string.Format("{0} was deleted", user.UserName);
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["message"] = string.Format("{0} was not deleted", user.UserName);
                    return View("Index", result.Errors);
                }
                
            }else
                {
                TempData["message"] = string.Format("{0} was not found", user.UserName);
                return View("Index", new string[] { "User Not Found" });
                }
        }

        public ActionResult Edit(string id)
        {
            AppUser user = UserManager.FindById(id);
            if(user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach(string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }

    
}