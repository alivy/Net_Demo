using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Utils工具
{
    //public class Logger
    //{
    //    private static log4net.ILog log = log4net.LogManager.GetLogger("Error");
    //    /// <summary>
    //    /// 写异常日志
    //    /// </summary>
    //    /// <param name="ex">异常类对象</param>
    //    public static void WriteException(Exception ex)
    //    {
    //        log.Error("程序出现异常", ex);

    //    }
    //    /// <summary>
    //    /// 写入错误信息
    //    /// </summary>
    //    /// <param name="msg">要写入的信息</param>
    //    public static void WirteMessageLog(string msg)
    //    {
    //        log.Error(msg);
    //    }
    //}
    /// <summary>
    /// 日志类
    /// </summary>
    public class Logger
    {
        private static readonly object LogLock = new object();
        public static void WriteException(Exception ex)
        {
            // 写入日志
            StringBuilder sbError = new StringBuilder();
            if (HttpContext.Current != null)
            {
                HttpRequest request = HttpContext.Current.Request;
                if (request != null)
                {
                    sbError.AppendFormat("请求IP：{0}\r\n", request.UserHostAddress);
                    sbError.AppendFormat("浏览器：{0} {1}\r\n", request.Browser.Browser, request.Browser.Version);
                    sbError.AppendFormat("请求地址：{0}\r\n", request.RawUrl);
                }
            }
            Action<int, Exception> AddException = null;
            AddException = (level, exception) =>
            {
                sbError.AppendFormat("异常层级：{0}\r\n", level);
                sbError.AppendFormat("错误信息：{0}\r\n", ex.Message);
                sbError.AppendFormat("异常对象：{0}\r\n", ex.Source);
                sbError.AppendFormat("错误堆栈：{0}", ex.StackTrace);
                sbError.AppendFormat("异常方法：{0}\r\n", ex.TargetSite);
                if (ex.Data != null)
                {
                    sbError.AppendFormat("异常数据：{0}\r\n", JsonConvert.SerializeObject(ex.Data));
                }
                if (exception.InnerException != null)
                {
                    AddException(level + 1, exception.InnerException);
                }
            };
            AddException(0, ex);
            Logger.WirteMessageLog(sbError.ToString());
        }
        /// <summary>
        /// 写入异常日志
        /// </summary>
        /// <param name="ex"></param>
        public static void WirteMessageLog(string errorMsg)
        {
            lock (LogLock)
            {
                string logFile = String.Format("{0}Log\\{1}.txt", AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyy-MM-dd"));
                if (!Directory.Exists(Path.GetDirectoryName(logFile)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(logFile));
                }
                StreamWriter sw = new StreamWriter(logFile, true);
                try
                {
                    sw.WriteLine("-----------------------------------------------------------");
                    sw.WriteLine(string.Format("时间：{0}", DateTime.Now.ToString()));
                    sw.WriteLine(string.Format("{0}\r\n", errorMsg));
                    sw.Flush();
                }
                finally
                {
                    sw.Close();
                }
            }
        }

        public static void WirteLocalMessageLog(string info)
        {
            string logFile = String.Format(@"D:\Test1\{0}.txt", DateTime.Now.ToString("yyyy-MM-dd"));
            if (!Directory.Exists(Path.GetDirectoryName(logFile)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(logFile));
            }
            StreamWriter sw = new StreamWriter(logFile, true);
            try
            {
                sw.WriteLine("-----------------------------------------------------------");
                sw.WriteLine(string.Format("时间：{0}", DateTime.Now.ToString()));
                sw.WriteLine(string.Format("{0}\r\n", info));
                sw.Flush();
            }
            finally
            {
                sw.Close();
            }
        }



        public static void AddLog(string msg)
        {
            //string saveFolder="Models";
            string saveFolder = "C:\\Log";
            string tishiMsg = "";
            try
            {
                string fileName = DateTime.Now.ToString("yyyy-MM-dd");
                string filePath = AppDomain.CurrentDomain.BaseDirectory + saveFolder;
                if (Directory.Exists(filePath) == false)
                {
                    Directory.CreateDirectory(saveFolder);
                }
                string fileAbstractPath = saveFolder + "\\" + fileName + ".txt";
                FileStream fs = new FileStream(fileAbstractPath, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                //开始写入     
                string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                msg = time + "，" + msg + System.Environment.NewLine;

                sw.Write(msg);
                //清空缓冲区               
                sw.Flush();
                //关闭流               
                sw.Close();
                sw.Dispose();
                fs.Close();
                fs.Dispose();

                tishiMsg = "写入日志成功";
            }
            catch (Exception ex)
            {
                string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                tishiMsg = "[" + datetime + "]写入日志出错：" + ex.Message;
            }
        }


        public static void AddLine(int rows)
        {
            try
            {
                string saveFolder = "C:\\Log";
                string fileName = DateTime.Now.ToString("yyyy-MM-dd");
                string filePath = AppDomain.CurrentDomain.BaseDirectory + saveFolder;
                if (Directory.Exists(filePath) == false)
                {
                    Directory.CreateDirectory(saveFolder);
                }
                string fileAbstractPath = saveFolder + "\\" + fileName + ".txt";
                FileStream fs = new FileStream(fileAbstractPath, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                //开始写入    
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < rows; i++)
                {
                    sb.Append(System.Environment.NewLine);
                }
                string newline = sb.ToString();
                sw.Write(newline);
                //清空缓冲区               
                sw.Flush();
                //关闭流               
                sw.Close();
                sw.Dispose();
                fs.Close();
                fs.Dispose();
            }
            catch (Exception ex)
            {
                string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string tishiMsg = "[" + datetime + "]写入日志出错：" + ex.Message;
            }
        }
    }



}
