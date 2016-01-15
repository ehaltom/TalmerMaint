using TalmerMaint.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TalmerMaint.WebUI.Models
{
    public class DbLoggingPagingViewModel
    {
        public string Username { get; set; }
        public List<SelectListItem> Usernames { get; set; }
        public string Controller { get; set; }
        public List<SelectListItem> Controllers { get; set; }
        public string Action { get; set; }
        public List<SelectListItem> Actions { get; set; }
        public int ItemId { get; set; }
        public IEnumerable<DbChangeLog> Logs { get; set; }
        public PagingInfo PagingInfo { get; set; }

    }
}