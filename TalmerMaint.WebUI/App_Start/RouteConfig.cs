using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TalmerMaint.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,"Locations",
                 new { Controller = "Locations", action = "Index", state = (string)null, page = 1}
                );
            routes.MapRoute(null,
                "Locatons/Page{page}",
                new { controller = "Locations", action = "Index", state = (string)null },
                new { page = @"\d+" });
            routes.MapRoute(null,
                "Locations/List{state}",
                new { controller = "Locations", action = "Index", page = 1 });
            routes.MapRoute(null,
                "Locations/List{state}/Page{page}",
                new { controller = "Locations", action = "Index" },
                new { page = @"\d+" });
           
            

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
