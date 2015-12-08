using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Elmah;
using TalmerMaint.Domain.Entities;


namespace TalmerMaint.Domain.Extensions
{
    
    public class CentralLibrary
    {

        public static string GetStateName(string stateInitials)
        {
            switch (stateInitials)
            {
                case "AL":
                    return "Alabama";
                case "AK":
                    return "Alaska";
                case "AR":
                    return "Arkansas";
                case "AZ":
                    return "Arizona";
                case "CA":
                    return "California";
                case "CO":
                    return "Colorado";
                case "CT":
                    return "Connecticut";
                case "DE":
                    return "Delaware";
                case "FL":
                    return "Florida";
                case "GA":
                    return "Georgia";
                case "HI":
                    return "Hawaii";
                case "ID":
                    return "Idaho";
                case "IL":
                    return "Illinois";
                case "IN":
                    return "Indiana";
                case "IA":
                    return "Iowa";
                case "KS":
                    return "Kansas";
                case "KY":
                    return "Kentucky";
                case "LA":
                    return "Louisiana";
                case "ME":
                    return "Maine";
                case "MD":
                    return "Maryland";
                case "MA":
                    return "Massachusetts";
                case "MI":
                    return "Michigan";
                case "MN":
                    return "Minnesota";
                case "MS":
                    return "Mississippi";
                case "MO":
                    return "Missouri";
                case "MT":
                    return "Montana";
                case "NE":
                    return "Nebraska";
                case "NV":
                    return "Nevada";
                case "NH":
                    return "New Hampshire";
                case "NJ":
                    return "New Jersey";
                case "NM":
                    return "New Mexico";
                case "NY":
                    return "New York";
                case "NC":
                    return "North Carolina";
                case "ND":
                    return "North Dakota";
                case "OH":
                    return "Ohio";
                case "OK":
                    return "Oklahoma";
                case "OR":
                    return "Oregon";
                case "PA":
                    return "Pennsylvania";
                case "RI":
                    return "Rhode Island";
                case "SC":
                    return "South Carolina";
                case "SD":
                    return "South Dakota";
                case "TN":
                    return "Tennessee";
                case "TX":
                    return "Texas";
                case "UT":
                    return "Utah";
                case "VT":
                    return "Vermont";
                case "VA":
                    return "Virginia";
                case "WA":
                    return "Washington";
                case "WV":
                    return "West Virginia";
                case "WI":
                    return "Wisconsin";
                case "WY":
                    return "Wyoming";
                default:
                    return stateInitials;
            }
        }

        public static List<SelectListItem> StatesDropdown = new List<SelectListItem>()
        {
            new SelectListItem() {Text="Select a State"},
            new SelectListItem() {Text="Alabama", Value="AL"},
            new SelectListItem() { Text="Alaska", Value="AK"},
            new SelectListItem() { Text="Arizona", Value="AZ"},
            new SelectListItem() { Text="Arkansas", Value="AR"},
            new SelectListItem() { Text="California", Value="CA"},
            new SelectListItem() { Text="Colorado", Value="CO"},
            new SelectListItem() { Text="Connecticut", Value="CT"},
            new SelectListItem() { Text="District of Columbia", Value="DC"},
            new SelectListItem() { Text="Delaware", Value="DE"},
            new SelectListItem() { Text="Florida", Value="FL"},
            new SelectListItem() { Text="Georgia", Value="GA"},
            new SelectListItem() { Text="Hawaii", Value="HI"},
            new SelectListItem() { Text="Idaho", Value="ID"},
            new SelectListItem() { Text="Illinois", Value="IL"},
            new SelectListItem() { Text="Indiana", Value="IN"},
            new SelectListItem() { Text="Iowa", Value="IA"},
            new SelectListItem() { Text="Kansas", Value="KS"},
            new SelectListItem() { Text="Kentucky", Value="KY"},
            new SelectListItem() { Text="Louisiana", Value="LA"},
            new SelectListItem() { Text="Maine", Value="ME"},
            new SelectListItem() { Text="Maryland", Value="MD"},
            new SelectListItem() { Text="Massachusetts", Value="MA"},
            new SelectListItem() { Text="Michigan", Value="MI"},
            new SelectListItem() { Text="Minnesota", Value="MN"},
            new SelectListItem() { Text="Mississippi", Value="MS"},
            new SelectListItem() { Text="Missouri", Value="MO"},
            new SelectListItem() { Text="Montana", Value="MT"},
            new SelectListItem() { Text="Nebraska", Value="NE"},
            new SelectListItem() { Text="Nevada", Value="NV"},
            new SelectListItem() { Text="New Hampshire", Value="NH"},
            new SelectListItem() { Text="New Jersey", Value="NJ"},
            new SelectListItem() { Text="New Mexico", Value="NM"},
            new SelectListItem() { Text="New York", Value="NY"},
            new SelectListItem() { Text="North Carolina", Value="NC"},
            new SelectListItem() { Text="North Dakota", Value="ND"},
            new SelectListItem() { Text="Ohio", Value="OH"},
            new SelectListItem() { Text="Oklahoma", Value="OK"},
            new SelectListItem() { Text="Oregon", Value="OR"},
            new SelectListItem() { Text="Pennsylvania", Value="PA"},
            new SelectListItem() { Text="Rhode Island", Value="RI"},
            new SelectListItem() { Text="South Carolina", Value="SC"},
            new SelectListItem() { Text="South Dakota", Value="SD"},
            new SelectListItem() { Text="Tennessee", Value="TN"},
            new SelectListItem() { Text="Texas", Value="TX"},
            new SelectListItem() { Text="Utah", Value="UT"},
            new SelectListItem() { Text="Vermont", Value="VT"},
            new SelectListItem() { Text="Virginia", Value="VA"},
            new SelectListItem() { Text="Washington", Value="WA"},
            new SelectListItem() { Text="West Virginia", Value="WV"},
            new SelectListItem() { Text="Wisconsin", Value="WI"},
            new SelectListItem() { Text="Wyoming", Value="WY"}

        };

    }

    public class HandleErrorWithELMAHAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var e = context.Exception;
            if (!context.ExceptionHandled   // if unhandled, will be logged anyhow
                    || RaiseErrorSignal(e)      // prefer signaling, if possible
                    || IsFiltered(context))     // filtered?
                return;

            LogException(e);
        }

        private static bool RaiseErrorSignal(Exception e)
        {
            var context = HttpContext.Current;
            if (context == null)
                return false;
            var signal = ErrorSignal.FromContext(context);
            if (signal == null)
                return false;
            signal.Raise(e, context);
            return true;
        }

        private static bool IsFiltered(ExceptionContext context)
        {
            var config = context.HttpContext.GetSection("elmah/errorFilter")
                                     as ErrorFilterConfiguration;

            if (config == null)
                return false;

            var testContext = new ErrorFilterModule.AssertionHelperContext(
                                                                context.Exception, HttpContext.Current);

            return config.Assertion.Test(testContext);
        }

        private static void LogException(Exception e)
        {
            var context = HttpContext.Current;
            ErrorLog.GetDefault(context).Log(new Error(e, context));
        }
    }
    public class ErrorHandlingActionInvoker : ControllerActionInvoker
    {
        private readonly IExceptionFilter filter;

        public ErrorHandlingActionInvoker(IExceptionFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("filter");
            }

            this.filter = filter;
        }

        protected override FilterInfo GetFilters(
        ControllerContext controllerContext,
        ActionDescriptor actionDescriptor)
        {
            var filterInfo =
            base.GetFilters(controllerContext,
            actionDescriptor);

            filterInfo.ExceptionFilters.Add(this.filter);

            return filterInfo;
        }
    }

    public class ErrorHandlingControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(
        RequestContext requestContext,
        string controllerName)
        {
            var controller =
            base.CreateController(requestContext,
            controllerName);

            var c = controller as Controller;

            if (c != null)
            {
                c.ActionInvoker = new ErrorHandlingActionInvoker(new HandleErrorWithELMAHAttribute());
            }

            return controller;
        }
    }

    public class DbLogExtensions{
        public static string LocationToString(Location loc, string img)
        {
            string locString = "<table class='table table-striped'><tr><th>ID:</th><td>" + loc.Id.ToString() + "</td></tr>";
            locString += "<tr><th>Name:</th><td>" + loc.Name + "</td></tr>";
            locString += "<tr><th>Subtitle:</th><td>" + loc.Subtitle + "</td></tr>";
            locString += "<tr><th>Manager Name:</th><td>" + loc.ManagerName + "</td></tr>";
            locString += "<tr><th>Address Line 1:</th><td>" + loc.Address1 + "</td></tr>";
            locString += "<tr><th>Address Line 2:</th><td>" + loc.Address2 + "</td></tr>";
            locString += "<tr><th>City:</th><td>" + loc.City + "</td></tr>";
            locString += "<tr><th>State:</th><td>" + loc.State + "</td></tr>";
            locString += "<tr><th>Zip:</th><td>" + loc.Zip + "</td></tr>";
            locString += "<tr><th>AtmOnly:</th><td>" + loc.AtmOnly.ToString() + "</td></tr>";
            locString += "<tr><th>NoAtm:</th><td>" + loc.NoAtm.ToString() + "</td></tr>";
            locString += "<tr><th>Description:</th><td>" + loc.Description + "</td></tr>";
            locString += "<tr><th>Latitude:</th><td>" + loc.Latitude + "</td></tr>";
            locString += "<tr><th>Longitude:</th><td>" + loc.Longitude + "</td></tr>";
            locString += "<tr><th>Image Mime Type:</th><td>" + loc.ImageMimeType + "</td></tr>";
            locString += "<tr><th>Image Data:</th><td>";
            if (img == "") {
                if(loc.ImageMimeType != null && loc.ImageMimeType != "deleted")
                {
                    locString += "Existing Image";
                }
                else
                {
                    locString += "No Existing Image";
                }
            }
            else
            {
                locString += img;
            }
            locString += "</td></tr>";
            locString += "</table>";
            return locString;
        }

        public static string LocCatToString(LocHourCats cat)
        {

            string locString = "<table class='table table-striped'>";
            locString += "<tr><th>ID:</th><td>" + cat.Id.ToString() + "</td></tr>";
            locString += "<tr><th>Name:</th><td>" + cat.Name + "</td></tr>";
            locString += "<tr><th>Location ID:</th><td>" + cat.LocationId + "</td></tr>";
            locString += "</table>";
            return locString;
        }

        public static string LocHoursToString(LocHours hours)
        {

            string locString = "<table class='table table-striped'>";
            locString += "<tr><th>ID:</th><td>" + hours.Id.ToString() + "</td></tr>";
            locString += "<tr><th>Days:</th><td>" + hours.Days + "</td></tr>";
            locString += "<tr><th>Hours:</th><td>" + hours.Hours + "</td></tr>";
            locString += "<tr><th>Priority:</th><td>" + hours.Priority.ToString() + "</td></tr>";
            locString += "<tr><th>Parent Category ID:</th><td>" + hours.LocHourCatsId.ToString() + "</td></tr>";
            locString += "</table>";
            return locString;
        }

        public static string LocPhoneToString(LocPhoneNums phone)
        {

            string locString = "<table class='table table-striped'>";
            locString += "<tr><th>ID:</th><td>" + phone.Id.ToString() + "</td></tr>";
            locString += "<tr><th>Name:</th><td>" + phone.Name + "</td></tr>";
            locString += "<tr><th>Number:</th><td>" + phone.Number + "</td></tr>";
            locString += "<tr><th>Location ID:</th><td>" + phone.LocationId + "</td></tr>";
            locString += "</table>";
            return locString;
        }

        public static string LocPhoneExtToString(LocPhoneExts ext)
        {

            string locString = "<table class='table table-striped'>";
            locString += "<tr><th>ID:</th><td>" + ext.Id.ToString() + "</td></tr>";
            locString += "<tr><th>Name:</th><td>" + ext.Name + "</td></tr>";
            locString += "<tr><th>Extension:</th><td>" + ext.Number + "</td></tr>";
            locString += "<tr><th>Parent Phone ID:</th><td>" + ext.LocPhoneNumsId.ToString() + "</td></tr>";
            locString += "</table>";
            return locString;
        }

        public static string LocServiceToString(LocServices serv)
        {

            string locString = "<table class='table table-striped'>";
            locString += "<tr><th>ID:</th><td>" + serv.Id.ToString() + "</td></tr>";
            locString += "<tr><th>Name:</th><td>" + serv.Name + "</td></tr>";
            locString += "<tr><th>Icon Class Name:</th><td>" + serv.IconClassName + "</td></tr>";
            locString += "<tr><th>Featured?:</th><td>" + serv.Featured.ToString() + "</td></tr>";
            locString += "<tr><th>Location ID:</th><td>" + serv.LocationId + "</td></tr>";
            locString += "</table>";
            return locString;
        }

    }
}
