using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Utils工具.log4net
{
    class LogStrat
    {

        public LogStrat()
        {
            try
            {
                //注册 log4net
                //log4net.Config.XmlConfigurator.Configure(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4config\\log.xml"));
                //var a = new Log();
                TaskFactory taskFactory = new TaskFactory();
                for (int i = 0; i < 10; i++)
                {
                    Action act = () => LoggerHelper.Error("当前循环为" + i.ToString());
                    //taskFactory.StartNew(act);
                    new Task(act).Start();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
