using System.Collections.Generic;
using System.Linq;
using TalmerMaint.Domain.Abstract;
using System.Web.Mvc;

namespace TalmerMaint.WebUI.Controllers
{
    public class NavController : Controller
    {
        private ILocationRepository repository;

        public NavController(ILocationRepository repo)
        {
            repository = repo;
        }
        // GET: Nav
        public PartialViewResult Menu(string state = null)
        {
            ViewBag.SelectedState = state;
            IEnumerable<string> stateInitials = repository.Locations
                .Select(x => x.State)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(stateInitials);
        }
    }
}