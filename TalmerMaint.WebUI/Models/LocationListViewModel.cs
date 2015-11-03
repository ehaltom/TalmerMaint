using System.Collections.Generic;
using TalmerMaint.Domain.Entities;

namespace TalmerMaint.WebUI.Models
{
    public class LocationListViewModel
    {
        public IEnumerable<Location> Locations { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentState { get; set; }
    }
}