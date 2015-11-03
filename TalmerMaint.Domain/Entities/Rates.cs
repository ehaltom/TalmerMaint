using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TalmerMaint.Domain.Entities
{
    public class Rates
    {
        public int Id { get; set; }

        [Display(Name = "Page Name", Description = "This is an identifying name for a group of rates called on a single page")]
        [RegularExpression(@"^\S*$", ErrorMessage = "Please remove any spaces from the Page Name")]
        [MaxLength(50, ErrorMessage = "You have exceeded the character limit for the Page Name")]
        public string PageName { get; set; }

        [Display(Name ="Effective Date")]
        [Required(ErrorMessage ="The effective date field is required")]
        [MaxLength(50,ErrorMessage ="The maximum character limit for efffective date has been exceeded")]
        public string EffectiveDate { get; set; }

        [Display(Name = "Rate Titles")]
        public virtual ICollection<RateTitle> RateTitles { get; set; }
        public virtual ICollection<RateRow> RateRows { get; set; }
    }
}
