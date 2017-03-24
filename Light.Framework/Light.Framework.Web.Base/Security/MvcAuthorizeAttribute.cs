using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var actionAttrs = filterContext.ActionDescriptor.GetCustomAttributes(true);
            if (actionAttrs.Any(x => x is AllowAnonymousAttribute))
            {
                return;
            }
            var actionAttr = actionAttrs.FirstOrDefault(x => x is MvcAuthorizeAttribute);
            if (actionAttr != null)
            {
                ((MvcAuthorizeAttribute)actionAttr).Authenticate(filterContext);
                return;
            }
            var controllerAttrs = filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(true);
            if (controllerAttrs.Any(x => x is AllowAnonymousAttribute))
            {
                return;
            }
            var controllerAttr = controllerAttrs.FirstOrDefault(x => x is MvcAuthorizeAttribute);
            if (controllerAttr != null)
            {
                ((MvcAuthorizeAttribute)controllerAttr).Authenticate(filterContext);
                return;
            }
            this.Authenticate(filterContext);
        }

        public void Authenticate(AuthorizationContext filterContext)
        {
            var context = filterContext.RequestContext.HttpContext;
            var isAuthenticated1 = context.Request.IsAuthenticated;
            var isAuthenticated2 = context.User.Identity.IsAuthenticated;
            var isAuthenticated = HttpContext.Current.User.Identity.IsAuthenticated;
            if (!string.IsNullOrEmpty(this.Roles))
            {
                isAuthenticated = isAuthenticated && this.Roles.Split(',').Any(r => context.User.IsInRole(r));
            }
            if (isAuthenticated)
            {
                return;
            }

            if (HttpContext.Current.Request["ajax"] == "true")
            {
                filterContext.Result = new StandardJsonResult()
                {
                    Message = context.Request.IsAuthenticated ? "Please login" : "You don't have sufficient permission"
                };
            }
            else
            {
                filterContext.Result = new RedirectResult("/admin/home/login?returnUrl=" + HttpContext.Current.Request.RawUrl);
            }
        }
    }
}
