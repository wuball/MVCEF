using System.Security.Principal;

namespace Light.Framework.Web.Base.Extensions
{
    public static class PrincipalExtensions
    {
        public static bool IsSuperAdmin(this IPrincipal principal)
        {
            return principal.IsInRole("Role.Names.SuperAdmin");
        }
    }
}
