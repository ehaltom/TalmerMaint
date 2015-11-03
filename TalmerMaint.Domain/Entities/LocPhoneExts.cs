using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TalmerMaint.Domain.Entities
{
    public class LocPhoneExts
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "An extension name is required")]
        [MaxLength(50, ErrorMessage = "You have exceeded the maximum character limit (50)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "An extension number is required")]
        [MaxLength(50, ErrorMessage = "You have exceeded the maximum character limit (50)")]
        public string Number { get; set; }

        public int LocPhoneNumsId { get; set; }
    }
}
