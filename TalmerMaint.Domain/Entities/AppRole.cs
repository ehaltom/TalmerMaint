using Microsoft.AspNet.Identity.EntityFramework;

namespace TalmerMaint.Domain.Entities
{
    public class AppRole : IdentityRole
    {
        public AppRole() : base() { }

        public AppRole(string name) : base(name) { }
    }
}
