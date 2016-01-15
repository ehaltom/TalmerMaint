using System;
using System.Web.Optimization;

namespace TalmerMaint.WebUI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/modernizr")
                .Include(
                    "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/scripts/base")
                .Include(
                    "~/Scripts/jquery-1.10.2.min.js",
                    "~/Scripts/jquery.validate.min.js",
                    "~/Scripts/jquery.validate.unobtrusive.min.js",
                    "~/Scripts/jquery.unobtrusive-ajax.min.js",
                    "~/Scripts/bootstrap.min.js",
                    "~/Scripts/siteScripts.js"

                ));


            bundles.Add(new StyleBundle("~/bundles/syles")
                .Include(
                    "~/Content/fontawesome.css",
                    "~/Content/bootstrap.css",
                    "~/Content/Site.css"
                )
                );
        }
    }
}