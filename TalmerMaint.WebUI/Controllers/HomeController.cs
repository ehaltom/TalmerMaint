using System;
using System.Collections.Generic;
using System.Linq;
using TalmerMaint.Domain.Concrete;
using System.Web.Mvc;

namespace TalmerMaint.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        
        public ActionResult Index()
        {
            return View();
        }
       

    }
}