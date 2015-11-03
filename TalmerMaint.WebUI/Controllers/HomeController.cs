using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;

namespace TalmerMaint.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        
        public ActionResult Index()
        {
            return View(GetData("Index"));
        }
        private Dictionary<string, object> GetData(string actionName)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("UserName", HttpContext.User.Identity.Name);
            dict.Add("LocationAdmin", HttpContext.User.IsInRole("LocationAdmin"));
            dict.Add("UserAdmin", HttpContext.User.IsInRole("UserAdmin"));
            dict.Add("PropertyAdmin", HttpContext.User.IsInRole("PropertyAdmin"));
            return dict;
        }

    }
}