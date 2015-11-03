using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TalmerMaint.Domain.Entities
{
    public class LocHours
    {
        public int Id { get; set; }

        [Display(Name ="Title")]
        [Required(ErrorMessage = "A title is required")]
        [MaxLength(150, ErrorMessage = "You have exceeded the maximum character limit (150)")]
        public string HoursTitle { get; set; }

        [Required(ErrorMessage = "Hours is required")]
        [MaxLength(150, ErrorMessage = "You have exceeded the maximum character limit (150)")]
        public string Hours { get; set; }
        public int LocationId { get; set; }
    }
}
