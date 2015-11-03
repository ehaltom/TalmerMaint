using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TalmerMaint.Domain.Entities
{
    public class LocPhoneNums
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A phone name is required")]
        [MaxLength(100, ErrorMessage = "You have exceeded the maximum character limit (100)")]
        public string Name { get; set; }
        [Required(ErrorMessage = "A phone number is required")]
        [MaxLength(50, ErrorMessage = "You have exceeded the maximum character limit (50)")]
        public string Number { get; set; }
        public int LocationId { get; set; }

        public virtual ICollection<LocPhoneExts> LocPhoneExts { get; set; }
    }
}
