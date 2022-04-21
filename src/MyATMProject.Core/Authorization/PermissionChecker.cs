using Abp.Authorization;
using MyATMProject.Authorization.Roles;
using MyATMProject.Authorization.Users;

namespace MyATMProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
