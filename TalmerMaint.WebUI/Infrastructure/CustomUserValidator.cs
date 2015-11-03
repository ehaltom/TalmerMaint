using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNet.Identity;
using TalmerMaint.Domain.Entities;

namespace TalmerMaint.WebUI.Infrastructure
{
    public class CustomUserValidator : UserValidator<AppUser>
    {
        public CustomUserValidator(AppUserManager mgr) 
            : base(mgr){
        }
        public override async Task<IdentityResult> ValidateAsync(AppUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);

            if (!user.Email.ToLower().EndsWith("@talmerbank.com"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Only talmerbank.com email addresses are allowed");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}