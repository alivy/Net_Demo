using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils工具;
using Utils工具.ASPOSE;

namespace Miao_ToolCase.Action
{
    /// <summary>
    /// Log4net
    /// </summary>
    public class Log4netShow :ShowInterface
    {
        public void Show()
        {
            //注册 log4net
            log4net.Config.XmlConfigurator.Configure(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4config\\log.xml"));
            LoggerHelper.Info("1");
        }
    }
}
