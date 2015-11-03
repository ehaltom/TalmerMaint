using TalmerMaint.Domain.Entities;

namespace TalmerMaint.WebUI.Models
{
    public class LocationPhoneExtensionsViewModel
    {
        public Location Location { get; set; }
        public LocPhoneNums PhoneNums { get; set; }
        public LocPhoneExts LocPhoneExts { get; set; }
    }
}