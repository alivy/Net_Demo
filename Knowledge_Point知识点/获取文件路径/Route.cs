using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Knowledge_Point知识点.获取文件路径
{
    public class Routes
    {
        public Routes() {
            string route = string.Empty;
            //取得控制台应用程序的根目录方法

            //方法1、
            string route1 = Environment.CurrentDirectory; //取得或设置当前工作目录的完整限定路径
                                                          //方法2、
            string route2 = AppDomain.CurrentDomain.BaseDirectory;// 获取基目录，它由程序集冲突解决程序用来探测程序集

            ////取得Web应用程序的根目录方法
            //方法1、
            string route3 = HttpRuntime.AppDomainAppPath.ToString();
            //获取承载在当前应用程序域中的应用程序的应用程序目录的物理驱动器路径。用于App_Data中获取 D:\wwwroot\DllTest\
            ////方法2、
            //string route4 = Series.MapPath("");
            //string route5 = Server.MapPath("~/");//返回与Web服务器上的指定的虚拟路径相对的物理文件路径 D:\wwwroot\DllTest
            //方法3、
            //string route6 = Request.ApplicationPath;//获取服务器上ASP.NET应用程序的虚拟应用程序根目录

            //取得WinForm应用程序的根目录方法


            string WinForm = Environment.CurrentDirectory.ToString();//获取或设置当前工作目录的完全限定路径
            //string WinForm1 = Application.StartupPath.ToString();//获取启动了应用程序的可执行文件的路径，不包括可执行文件的名称
            string WinForm2 = Directory.GetCurrentDirectory();//获取应用程序的当前工作目录
            string WinForm3 = AppDomain.CurrentDomain.BaseDirectory;//获取基目录，它由程序集冲突解决程序用来探测程序集
            string WinForm4 = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;//获取或设置包含该应用程序的目录的名称
                                                                                       //其中：以下两个方法可以获取执行文件名称
            route = Process.GetCurrentProcess().MainModule.FileName;//可获得当前执行的exe的文件名。
            /*route = Application.ExecutablePath;*///获取启动了应用程序的可执行文件的路径，包括可执行文件的名称

            //3、System.IO.Path类中有一些获取路径的方法，可以在控制台程序或者WinForm中根据相对路径来获取绝对路径

            //获取web物理路径的方法

            route =System.Web.HttpContext.Current.Server.MapPath("~/a/b.config");//获取指定虚拟路径下对应的实际物理路径
        }


    }
}
