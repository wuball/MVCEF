using System;
using System.Web;
using Light.Framework.Core.Core;
using Light.Framework.Core.Extensions;
using Light.Framework.Web.Base.Extensions;
using Light.Framework.Web.Base.Security;

namespace Light.Framework.Web.Base.ViewModels
{
    public class LayoutViewModel
    {
        public string Title { get; set; }
        public string Error { get; set; }

        public MvcSession GetSession()
        {
            return HttpContext.Current.Session.GetMvcSession();
        }

        public bool HasError => !string.IsNullOrEmpty(this.Error);

        protected Guid GetUserId()
        {
            return HttpContext.Current.Request.GetUserId();
        }

        public void Try(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                this.Error = (ex is KnownException) ? ex.Message : ex.GetAllMessages();
            }
        }
    }

    public class LayoutViewModel<T> : LayoutViewModel
    {
        public T Model { get; set; }
    }
}