using NLog.Config;
using TalmerMaint.WebUI.App_Start;
using System.Web.Mvc;
using System.Web.Routing;
using TalmerMaint.Domain.Extensions;
using System.Web.Optimization;

namespace TalmerMaint.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // ControllerBuilder.Current.SetControllerFactory(new ErrorHandlingControllerFactory());
            GlobalFilters.Filters.Add(new HandleErrorWithELMAHAttribute());
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Register custom NLog Layout renderers
            ConfigurationItemFactory.Default.LayoutRenderers.RegisterDefinition("utc_date", typeof(Domain.Services.Logging.NLog.UtcDateRenderer));
            ConfigurationItemFactory.Default.LayoutRenderers.RegisterDefinition("web_variables", typeof(Domain.Services.Logging.NLog.WebVariablesRenderer));
        }
    }
}
