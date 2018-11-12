using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Utils工具;

namespace Web
{
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
#pragma warning disable IDE0019 // 使用模式匹配
            var ex = filterContext.Exception as Exception;
#pragma warning restore IDE0019 // 使用模式匹配k
            if (ex != null)
            {
                filterContext.Controller.ViewBag.UrlRefer = filterContext.HttpContext.Request.UrlReferrer;
                StringBuilder str = new StringBuilder();
                str.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                str.AppendLine("Filter捕获到未处理异常：" + ex.GetType().ToString());
                str.AppendLine("异常信息：" + ex.Message);
                str.AppendLine("异常堆栈：" + ex.StackTrace);
                str.AppendLine();
                LoggerHelper.Error(str.ToString(), ex);
                filterContext.HttpContext.Response.Write(string.Format("捕捉到未处理的异常：{0}<br/>", ex.GetType().ToString()));
                filterContext.HttpContext.Response.Write("Filter已进行错误处理。");
            }

            filterContext.ExceptionHandled = true;//设置异常已经处理
        }
    }
}