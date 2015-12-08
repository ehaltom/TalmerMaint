using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TalmerMaint.Domain.Helpers;
using TalmerMaint.Domain.Concrete;
using TalmerMaint.Domain.Abstract;
using TalmerMaint.WebUI.Models;
using TalmerMaint.Domain.Entities;
using TalmerMaint.Domain.Services.Paging;

namespace MySampleApp.Controllers
{
    [Authorize]
    public class LoggingController : Controller
    {
        private readonly ILogReportingFacade loggingRepository;
        public LoggingController()
        {
            loggingRepository = new LogReportingFacade();
        }

        public LoggingController(ILogReportingFacade repository)
        {
            loggingRepository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Returns the Index view
        /// </summary>
        /// <param name="Period">Text representation of the date time period. eg: Today, Yesterday, Last Week etc.</param>
        /// <param name="LoggerProviderName">Elmah, Log4Net, NLog, Health Monitoring etc</param>
        /// <param name="LogLevel">Debug, Info, Warning, Error, Fatal</param>
        /// <param name="page">The current page index (0 based)</param>
        /// <param name="PageSize">The number of records per page</param>
        /// <returns></returns>
        public ActionResult List(string Period, string LoggerProviderName, string LogLevel, int PageSize = 20, int page = 1)
        {
            
            // Set up our default values
            string defaultPeriod = Session["Period"] == null ? "Today" : Session["Period"].ToString();
            TimePeriod timePeriod = TimePeriodHelper.GetUtcTimePeriod(Period);
            string defaultLogType = Session["LoggerProviderName"] == null ? "All" : Session["LoggerProviderName"].ToString();
            string defaultLogLevel = Session["LogLevel"] == null ? "Error" : Session["LogLevel"].ToString();
            
            // Set up our view model
            LoggingIndexModel model = new LoggingIndexModel();

            model.LogLevel = (LogLevel == null) ? defaultLogLevel : LogLevel;
            model.LoggerProviderName = (LoggerProviderName == null) ? defaultLogType : LoggerProviderName;
            IEnumerable<LogEvent> events = loggingRepository.GetByDateRangeAndType(timePeriod.Start, timePeriod.End, model.LoggerProviderName, model.LogLevel);

            model.Period = (Period == null) ? defaultPeriod : Period;
                
            model.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = events.Count()
            };
            model.LogEvents = events.Skip((page - 1) * PageSize)
                .Take(PageSize);
            // Grab the data from the database


            // Put this into the ViewModel so our Pager can get at these values
            ViewData["Period"] = model.Period;
            ViewData["LoggerProviderName"] = model.LoggerProviderName;
            ViewData["LogLevel"] = model.LogLevel;
            ViewData["PageSize"] = model.PagingInfo.ItemsPerPage;

            // Put the info into the Session so that when we browse away from the page and come back that the last settings are rememberd and used.
            Session["Period"] = model.Period;
            Session["LoggerProviderName"] = model.LoggerProviderName;
            Session["LogLevel"] = model.LogLevel;
            Session["PageSize"] = PageSize;
            return View(model);
        }

        public ActionResult Details(string loggerProviderName, string id)
        {
            LogEvent logEvent = loggingRepository.GetById(loggerProviderName, id);

            return View(logEvent);
        }
    }
}