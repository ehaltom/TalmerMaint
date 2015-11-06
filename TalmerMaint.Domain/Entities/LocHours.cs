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



        [Required(ErrorMessage = "The days field is required")]
        [MaxLength(150, ErrorMessage = "You have exceeded the maximum character limit (150)")]
        public string Days { get; set; }

        [Required(ErrorMessage = "The hours filed is required")]
        [MaxLength(150, ErrorMessage = "You have exceeded the maximum character limit (150)")]
        public string Hours { get; set; }

        [Required(ErrorMessage = "The priority field is required")]
        [Range(0, 1000)]
        [Display(Name = "Order", Description = "Enter a number from 0 - 1000 to arrange these items in the proper order. Suggestion: use numbers in increments of 10 so if future additions are needed, there will be room to properly order them.")]
        public int Priority { get; set; }

        public int LocHourCatsId { get; set; }
    }
}
