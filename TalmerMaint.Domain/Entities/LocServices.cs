
using System.ComponentModel.DataAnnotations;

namespace TalmerMaint.Domain.Entities
{
    public class LocServices
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A name is required")]
        [MaxLength(200, ErrorMessage = "You have exceeded the maximum character limit (100)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A description is required")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name="Icon Class Name")]
        [MaxLength(50, ErrorMessage = "You have exceeded the maximum character limit (50)")]
        public string IconClassName { get; set; }

        [Display(Name="Featured?")]
        public bool Featured { get; set; }

        public int LocationId { get; set; }
    }
}
