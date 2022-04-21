using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyATMProject.Controllers
{
    public abstract class MyATMProjectControllerBase: AbpController
    {
        protected MyATMProjectControllerBase()
        {
            LocalizationSourceName = MyATMProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
