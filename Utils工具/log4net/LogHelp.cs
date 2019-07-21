using log4net;
using System;
using System.Reflection;
//注意下面的语句一定要加上，指定log4net使用.config文件来读取配置信息
//如果是WinForm（假定程序为LogDemo.exe，则需要一个LogDemo.exe.config文件）
//如果是WebForm，则从web.config中读取相关信息
//[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Utils工具
{
    public class LoggerHelper
    {
        static readonly ILog loginfo =LogManager.GetLogger("loginfo");
        static readonly ILog logerror =LogManager.GetLogger("logerror");
        static readonly ILog logmonitor = LogManager.GetLogger("logmonitor");
        static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Error(string ErrorMsg, Exception ex = null)
        {
            if (ex != null)
            {
                logerror.Error(ErrorMsg, ex);
            }
            else
            {
                logerror.Error(ErrorMsg);
            }
        }

        public static void Info(string Msg)
        {
            loginfo.Info(Msg);
        }

        public static void Monitor(string Msg)
        {
            logmonitor.Info(Msg);
        }
    }
}
