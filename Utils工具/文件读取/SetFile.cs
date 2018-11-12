using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utils工具.文件读取
{
    public class SetFile
    {
        /// <summary>
        /// 逐条读取文件
        /// </summary>
        /// <param name="path"></param>
        public string Reader(string path)
        {
            string txt = string.Empty;
            using (StreamReader sr = new StreamReader(path, new UTF8Encoding(false)))
            {
                while (!sr.EndOfStream)
                {
                    txt = sr.ReadLine();
                }
            }
            return txt;
        }


        /// <summary>
        /// 一次性读取文件
        /// </summary>
        /// <param name="path"></param>
        public void AllReader(string path)
        {
            var lines = File.ReadAllLines(path, Encoding.UTF8);
        }


        //读写锁，当资源处于写入模式时，其他线程写入需要等待本次写入结束之后才能继续写入
        private static ReaderWriterLockSlim LogWriteLock = new ReaderWriterLockSlim();
        static int WritedCount = 0;
        static int FailedCount = 0;
        /// <summary>
        /// 保存文本
        /// </summary>
        /// <param name="srt">写入文本</param>
        /// <param name="fileName">文件路径</param>
        public static void SaveTxt(string srt, string fileName)
        {
            try
            {
                // 设置读写锁为写入模式独占资源，其他写入请求需要等待本次写入结束之后才能继续写入
                //注意：长时间持有读线程锁或写线程锁会使其他线程发生饥饿 (starve)。 为了得到最好的性能，需要考虑重新构造应用程序以将写访问的持续时间减少到最小。
                //从性能方面考虑，请求进入写入模式应该紧跟文件操作之前，在此处进入写入模式仅是为了降低代码复杂度
                //因进入与退出写入模式应在同一个try finally语句块内，所以在请求进入写入模式之前不能触发异常，否则释放次数大于请求次数将会触发异常
                LogWriteLock.EnterWriteLock();
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, true))
                {
                    file.WriteLine(srt);// 直接追加文件末尾，换行 
                }
                WritedCount++;
            }
            catch (Exception)
            {
                FailedCount++;
            }
            finally
            {
                //退出写入模式，释放资源占用
                //注意：一次请求对应一次释放
                //      若释放次数大于请求次数将会触发异常[写入锁定未经保持即被释放]
                //      若请求处理完成后未释放将会触发异常[此模式不下允许以递归方式获取写入锁定]
                LogWriteLock.ExitWriteLock();
            }
            Console.WriteLine("保存数据条数{0}，数据保存异常次数{1}", WritedCount,FailedCount);

        }
    }
}
