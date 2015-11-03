namespace TalmerMaint.WebUI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TalmerMaint.WebUI.Infrastructure;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TalmerMaint.Domain.Entities;
    using Microsoft.AspNet.Identity;
    internal sealed class Configuration : DbMigrationsConfiguration<TalmerMaint.WebUI.Infrastructure.AppIdentityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TalmerMaint.WebUI.Infrastructure.AppIdentityDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            AppUserManager userMgr = new AppUserManager(new UserStore<AppUser>(context));
            AppRoleManager roleMgr = new AppRoleManager(new RoleStore<AppRole>(context));

            string roleName = "UserAdmin";
            string userName = "webservices";
            string password = "P@ssw0rd";
            string email = "webservices@talmerbank.com";

            if (!roleMgr.RoleExists(roleName))
            {
                roleMgr.Create(new AppRole(roleName));
            }
            AppUser user = userMgr.FindByName(userName);
            if (user == null)
            {
                userMgr.Create(new AppUser { UserName = userName, Email = email }, password);
                user = userMgr.FindByName(userName);
            }
            if (!userMgr.IsInRole(user.Id, roleName))
            {
                userMgr.AddToRole(user.Id, roleName);
            }
            context.SaveChanges();
        }
    }
}
