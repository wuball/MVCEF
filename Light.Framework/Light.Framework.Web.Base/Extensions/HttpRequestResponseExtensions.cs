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


        public static void SetAuthCookie(this HttpContextBase httpContext, string username, string data,
            bool isRemember = true)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        1,
                        username,
                        DateTime.Now,
                        DateTime.Now.Add(FormsAuthentication.Timeout),
                        isRemember,
                        data
                        );
            string encTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                cookie = new HttpCookie(FormsAuthentication.FormsCookieName);
            }

            cookie.Value = encTicket;

            if (isRemember)
                cookie.Expires = DateTime.Now.AddDays(AppContext.LoginExpireDays);

            httpContext.Response.Cookies.Add(cookie);
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