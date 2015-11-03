using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TalmerMaint.Domain.Entities;

namespace TalmerMaint.WebUI.Models
{
    public class LocationHoursViewModel
    {
        public Location Location { get; set; }
        public LocHours LocHours { get; set; }
    }
}