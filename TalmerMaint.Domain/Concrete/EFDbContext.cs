using TalmerMaint.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Data.SqlClient;

namespace TalmerMaint.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocHourCats> LocHourCats { get; set; }
        public DbSet<LocHours> LocHours { get; set; }
        public DbSet<LocPhoneNums> LocPhoneNums { get; set; }

        public DbSet<LocServices> LocServices { get; set; }

        public DbSet<LocPhoneExts> LocPhoneExts { get; set; }

        public DbSet<Rates> Rates { get; set; }
        public DbSet<RateTitle> RateTitles { get; set; }
        public DbSet<RateRow> RateRows { get; set; }


        public override int SaveChanges()
            {
                try
                {
                    return base.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
            
            }

        

    }
}
