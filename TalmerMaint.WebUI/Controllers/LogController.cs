using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TalmerMaint.WebUI.Controllers
{
    public class LogController : Controller
    {
        // GET: Log
        public ActionResult ErrorLog()
        {
            return View();
        }
    }
}