using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TalmerMaint.Domain.Entities
{
    public class RateRow
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The priority field is required")]
        [Range(0,1000)]
        [Display(Name = "Order", Description ="Enter a number from 0 - 1000 to arange your rates in the proper order. Suggestion: use numbers in increments of 10 so if future additions are needed, there will be room to properly order them.")]
        public int Priority { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [MaxLength(300, ErrorMessage = "You have exceeded the max length of 300 for this field")]
        public string Value { get; set; }
        public int RateTitleId { get; set; }
        public int RatesId { get; set; }


    }
}
