using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //注册 log4net
            log4net.Config.XmlConfigurator.Configure(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Configs\\log4.config"));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /// <summary>
        /// 捕获异常事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            //获取到HttpUnhandledException异常，这个异常包含一个实际出现的异常
            Exception ex = Server.GetLastError();
            //实际发生的异常
            Exception innerException = ex.InnerException;
            if (innerException != null) ex = innerException;

            StringBuilder str = new StringBuilder();
            str.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            str.AppendLine("Filter捕获到未处理异常：" + ex.GetType().ToString());
            str.AppendLine("异常信息：" + ex.Message);
            str.AppendLine("异常堆栈：" + ex.StackTrace);
            str.AppendLine();
            Utils工具.LoggerHelper.Error(str.ToString(), ex);
            HttpContext.Current.Response.Write(string.Format("捕捉到未处理的异常：{0}<br/>", ex.GetType().ToString()));
            HttpContext.Current.Response.Write("Global已进行错误处理。");
            Server.ClearError();
        }
    }
}
