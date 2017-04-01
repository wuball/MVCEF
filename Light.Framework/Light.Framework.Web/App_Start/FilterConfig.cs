using System.Web.Mvc;

namespace Light.Framework.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {

            filters.Add(new ExceptionLogAttribute());

            //GZIP压缩
            //filters.Add(new CompressAttribute());
        }
    }
    public class ExceptionLogAttribute : HandleErrorAttribute
    {
        /// <summary>
        /// 触发异常时调用的方法
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            //将错误信息记录下来
            string strException = filterContext.Exception.ToString();
            //LogHelper.Error("CON", strException);
        }
    }
}