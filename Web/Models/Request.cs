using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Utils工具;

namespace Web.Models
{
    public class Request_A 
    {
        
        public Request_A()
        {
            //var para = System.Web.HttpContext.Current.Request["参数名"];
            Stream s = System.Web.HttpContext.Current.Request.InputStream;
            byte[] b = new byte[s.Length];
            s.Read(b, 0, (int)s.Length);
            var postStr = Encoding.UTF8.GetString(b);
            Logger.WirteLocalMessageLog("接收异常消息为:"+postStr);
        }

    }
}