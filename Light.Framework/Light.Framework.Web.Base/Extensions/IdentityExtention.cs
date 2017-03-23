using System.Security.Claims;
using System.Security.Principal;

namespace Light.Framework.Web.Base.Extensions
{
    /// <summary>
    /// IIdentity扩展
    /// </summary>
    public static class IdentityExtention
    {
        /// <summary>
        /// 获取登录的用户ID
        /// </summary>
        /// <param name="identity">IIdentity</param>
        /// <returns></returns>
        public static string GetLoginUserId(this IIdentity identity)
        {
            var claim = (identity as ClaimsIdentity)?.FindFirst("LoginUserId");
            if (claim != null)
                return claim.Value;
            return string.Empty;
        }
        /// <summary>
        /// 获取登录是否超级管理员
        /// </summary>
        /// <param name="identity">IIdentity</param>
        /// <returns></returns>
        public static bool GetLoginIsSuperMan(this IIdentity identity)
        {
            var claim = (identity as ClaimsIdentity)?.FindFirst("IsSuperMan");
            if (claim != null)
                return claim.Value == "True";
            return false;
        }
    }
}