using System;
using System.Web;
using System.Web.Security;
using Light.Framework.Core;
using Light.Framework.Web.Base.Security;

namespace Light.Framework.Web.Base.Extensions
{
    public static class HttpRequestResponseExtensions
    {
        public static Guid GetUserId(this HttpRequestBase request)
        {
            if (request.IsAuthenticated)
            {
                return HttpContext.Current.Session.GetMvcSession().User.Id;
            }
            return Guid.Empty;
        }

        public static Guid GetUserId(this HttpRequest request)
        {
            return request.RequestContext.HttpContext.Request.GetUserId();
        }

        public static void SetAuthCookie(this HttpResponseBase response, string username, string roles,
            bool isRemember = true)
        {
            var expire = DateTime.Now.AddDays(AppContext.LoginExpireDays);
            var ticket = new FormsAuthenticationTicket(3, username, DateTime.Now, expire, isRemember, roles);

            var cookie = response.Cookies[FormsAuthentication.FormsCookieName] ??
                         new HttpCookie(FormsAuthentication.FormsCookieName)
                         {
                             Domain = FormsAuthentication.CookieDomain,
                             Path = FormsAuthentication.FormsCookiePath,
                             Value = FormsAuthentication.Encrypt(ticket)
                         };

            if (isRemember)
            {
                cookie.Expires = expire;
            }
            response.Cookies.Add(cookie);

            //var guestCookie = new HttpCookie("GUESTID", Guid.Empty.ToString()) { Expires = DateTime.Now.AddYears(-1) };
            //response.Cookies.Add(guestCookie);
        }

        public static bool IsAjax(this HttpRequest request)
        {
            return request["ajax"] == "true";
        }

        public static void ToExcel(this HttpResponseBase response, string filename)
        {
            response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
            response.Charset = "UTF-8";
            response.ContentEncoding = System.Text.Encoding.Default;
            response.ContentType = "application/ms-excel";
        }
    }
}