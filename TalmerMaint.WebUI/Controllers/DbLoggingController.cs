using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalmerMaint.Domain.Abstract;
using TalmerMaint.Domain.Entities;
using TalmerMaint.WebUI.Models;

namespace TalmerMaint.WebUI.Controllers
{
    public class DbLoggingController : Controller
    {
        private IDbChangeLog repo;
        public int PageSize = 12;

        public DbLoggingController(IDbChangeLog logRepository)
        {
            this.repo = logRepository;

        }
        // GET: DbLogging
        public ActionResult Index(string username = "All", string cont = "All", string act = "All", int itemId = 0, int PageSize = 20, int page = 1)
        {
            DbLoggingPagingViewModel model = new DbLoggingPagingViewModel();

            model.Username = (username != "") ? username : "";
            model.Controller = (cont != "") ? cont : "";
            model.Action = (act != "") ? act : "";
            model.ItemId = itemId;
            IDictionary<string, string> dict = new Dictionary<string, string>();
            IEnumerable<string> uns = repo.ChangeLogs.OrderBy(m => m.UserName).Select(m => m.UserName).Distinct().ToList();
            dict.Add("All", "All");
            foreach (string item in uns) { dict.Add(item, item); }
            
            model.Usernames = dict.Select(o => new SelectListItem { Text = o.Value, Value = o.Key }).ToList();


            dict = new Dictionary<string, string>();
            IEnumerable<string> cons = repo.ChangeLogs.OrderBy(m => m.Controller).Select(m => m.Controller).Distinct().ToList();
            dict.Add("All", "All");
            foreach (string item in cons) { dict.Add(item, item); }

            model.Controllers = dict.Select(o => new SelectListItem { Text = o.Value, Value = o.Key }).ToList();

            model.Logs = repo.ChangeLogs
                .Where(l => username == "All" || l.UserName == username)
                .Where(l => cont == "All" || l.Controller == cont)
                .Where(l => act == "All" || l.Action == act)
                .Where(l => itemId == 0 || l.ItemId == itemId)
                .OrderByDescending(l => l.DateTime)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);
            model.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = repo.ChangeLogs
                .Where(l => username == "All" || l.UserName == username)
                .Where(l => cont == "All" || l.Controller == cont)
                .Where(l => act == "All" || l.Action == act)
                .Where(l => itemId == 0 || l.ItemId == itemId).Count()
            };
            return View(model);
        }

        public ActionResult Details(int id)
        {
            DbChangeLog log = repo.ChangeLogs.FirstOrDefault(l => l.Id == id);
            return View(log);
        }
    }
}