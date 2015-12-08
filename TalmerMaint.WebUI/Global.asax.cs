using NLog.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TalmerMaint.Domain.Extensions;


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

            // Register custom NLog Layout renderers
            ConfigurationItemFactory.Default.LayoutRenderers.RegisterDefinition("utc_date", typeof(Domain.Services.Logging.NLog.UtcDateRenderer));
            ConfigurationItemFactory.Default.LayoutRenderers.RegisterDefinition("web_variables", typeof(Domain.Services.Logging.NLog.WebVariablesRenderer));
        }
    }
}
