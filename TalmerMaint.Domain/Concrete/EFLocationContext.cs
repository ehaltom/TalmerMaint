using TalmerMaint.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Data.SqlClient;

namespace TalmerMaint.Domain.Concrete
{
    public class EFLocationContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocHourCats> LocHourCats { get; set; }
        public DbSet<LocHours> LocHours { get; set; }
        public DbSet<LocPhoneNums> LocPhoneNums { get; set; }

        public DbSet<LocServices> LocServices { get; set; }

        public DbSet<LocPhoneExts> LocPhoneExts { get; set; }





    }
}
