using System;
using System.Web;
using System.Web.Mvc;
using Light.Framework.Service.Helpers;

namespace Light.Framework.Web.Base
{
    public class MvcApplication : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            AreaRegistration.RegisterAllAreas();
            InitData.Init();
        }
        
    }
}
