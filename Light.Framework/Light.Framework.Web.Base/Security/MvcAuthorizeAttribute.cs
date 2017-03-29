using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Light.Framework.Service.Admin.Implementations;
using Light.Framework.Web.Base.Mvc;

namespace Light.Framework.Web.Base.Security
{
    public class MvcAuthorizeAttribute : AuthorizeAttribute
    {
        public MvcAuthorizeAttribute()
        {

        }

        public MvcAuthorizeAttribute(string roles)
        {
            this.Roles = roles;
        }

        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var acctionDesc = filterContext.ActionDescriptor;

            var actionAttrs = acctionDesc.GetCustomAttributes(true);
            if (actionAttrs.Any(x => x is AllowAnonymousAttribute))
            {
                return;
            }
            //var actionAttr = actionAttrs.FirstOrDefault(x => x is MvcAuthorizeAttribute);
            //if (actionAttr != null)
            //{
            //    ((MvcAuthorizeAttribute)actionAttr).Authenticate(filterContext);
            //    return;
            //}
            var controllerAttrs = acctionDesc.ControllerDescriptor.GetCustomAttributes(true);
            if (controllerAttrs.Any(x => x is AllowAnonymousAttribute))
            {
                return;
            }
            //var controllerAttr = controllerAttrs.FirstOrDefault(x => x is MvcAuthorizeAttribute);
            //if (controllerAttr != null)
            //{
            //    ((MvcAuthorizeAttribute)controllerAttr).Authenticate(filterContext);
            //    return;
            //}

            ControllerName = acctionDesc.ControllerDescriptor.ControllerName;
            ActionName = acctionDesc.ActionName;
            base.OnAuthorization(filterContext);
        }


        /// <summary>
        /// 根据role判断用户
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        var url = "/" + ControllerName + "/" + ActionName;
                        //if (url == "/System/_Menu")
                        //{
                        //    return true;
                        //}
                        //Roles = new MenuService().GetRolesString(url);
                        //HttpContext.Current.User.IsInRole();

                        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = id.Ticket;
                        string userData = ticket.UserData.Split('|')[1];
                        var userRole = userData;
                        //MenuService ms = new MenuService();
                        Roles = new MenuService().GetRolesString(url);
                        var roles = Roles.Split(',').ToList();

                        if (userRole == "admin" || roles.Contains(userRole))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

    }
}
