using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Filters;
using Light.Framework.Core.Models;
using Newtonsoft.Json.Converters;

namespace Light.Framework.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new WebApiExceptionFilter());//Web Api错误处理

            //解决json循环问题
            //config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

            //删除xml
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //更改json时间格式
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss" });

        }
    }


    public class WebApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            base.OnException(context);

            //将错误信息记录下来
            string strException = context.Exception.ToString();
            //LogHelper.Error("API", strException);

            context.Response = new HttpResponseMessage { Content = new ObjectContent<StandardResult>(new StandardResult { Success = false, Message = "系统错误" }, new JsonMediaTypeFormatter()) };

        }
    }

}
