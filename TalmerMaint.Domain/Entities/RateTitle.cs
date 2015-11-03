using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TalmerMaint.Domain.Entities
{
    public class RateTitle
    {
        public int Id { get; set; }

        
        [Required(ErrorMessage = "The property title field is required")]
        [Display(Name ="Table Title")]
        [MaxLength(150, ErrorMessage = "You have exceeded the character limit for the Property Title")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The priority field is required")]
        [Range(0, 1000)]
        [Display(Name = "Order", Description = "Enter a number from 0 - 1000 to arange the titles in the proper order. Suggestion: use numbers in increments of 10 so if future additions are needed, there will be room to properly order them.")]
        public int Priority { get; set; }

        public int RatesId { get; set; }

    }
}
