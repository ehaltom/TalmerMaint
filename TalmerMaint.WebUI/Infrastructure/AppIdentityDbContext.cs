using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TalmerMaint.Domain.Entities;
using Microsoft.AspNet.Identity;

namespace TalmerMaint.WebUI.Infrastructure
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext() : base("IdentityDb") { }

        static AppIdentityDbContext()
        {
            Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());
        }
        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
    }
    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
    {
    }
}
