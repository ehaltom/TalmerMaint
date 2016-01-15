using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TalmerMaint.Domain.Entities
{
    public class Location
    {


        [HiddenInput(DisplayValue= false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "A Title is required")]
        [MaxLength(300, ErrorMessage ="You have exceeded the maximum character limit for the Title")]
        public string Name { get; set; }

        [MaxLength(300, ErrorMessage = "You have exceeded the maximum character limit for the Sub Title")]
        [Display(Name ="Sub Title")]
        public string Subtitle { get; set; }

        [MaxLength(300, ErrorMessage = "You have exceeded the maximum character limit for Address Line 1")]
        [Required(ErrorMessage = "Address Line 1 is required")]
        [Display(Name = "Address Line 1")]
        public string Address1 { get; set; }

        [MaxLength(300, ErrorMessage = "You have exceeded the maximum character limit for Address Line 2")]
        [Display(Name = "Address Line 2")]
        public string Address2 { get; set; }

        [MaxLength(150, ErrorMessage = "You have exceeded the maximum character limit for City")]
        [Required(ErrorMessage = "A City is required")]
        public string City { get; set; }

        [Display(Name ="State")]
        [Required(ErrorMessage = "A State is required")]
        [MaxLength(2, ErrorMessage = "You have exceeded the maximum character limit for State, Please enter state initials only")]
        public string State { get; set; }

        [Required(ErrorMessage = "A Zip Code is required")]
        [MaxLength(15, ErrorMessage = "You have exceeded the maximum character limit for the Zip code")]
        public string Zip { get; set; }
        public bool AtmOnly { get; set; }
        public bool NoAtm { get; set; }


        /******
        Update-Needed
        Need to come up with a better validation regex for latitude and longitude
        something like:
        ^(\-?\d+(\.\d+)?),\s*(\-?\d+(\.\d+)?)$
        ********/
        [Range(-90, 90, ErrorMessage ="Please enter a valid Latitude")]
        public double Latitude { get; set; }

        [Range(-180, 180, ErrorMessage = "Please enter a valid Latitude")]
        public double Longitude { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name="Manager Name")]
        [MaxLength(200, ErrorMessage = "You have exceeded the maximum character limit (200)")]
        public string ManagerName { get; set; }

        public ICollection<LocHourCats> LocHourCats { get; set; }
        public ICollection<LocPhoneNums> LocPhoneNums { get; set; }
        public ICollection<LocServices> LocServices { get; set; }

        public LocImage LocImage { get; set; }
    }
}
