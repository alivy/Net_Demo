using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils工具.断点续传
{
    public class BreakPoint
    {
        /// <summary>
        /// 获取文件的传输次数
        /// </summary>
        /// <param name="fileSize"></param>
        /// <param name="packageSize"></param>
        /// <returns></returns>
        private static int GetFilePackageCount(long fileSize, long packageSize)
        {
            int count = 0;
            if (fileSize % packageSize > 0)
                count = Convert.ToInt32(fileSize / packageSize) + 1;
            else
                count = Convert.ToInt32(fileSize / packageSize);
            return count;
        }
        /// <summary>
        /// 分块读取文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        private static byte[] FileRead(string path, int index, long size)
        {
            byte[] result = null;
            long length = (long)index * (long)size + size;
            using (FileStream stream = File.OpenRead(path))
            {
                if (length > stream.Length)
                    result = new byte[stream.Length - ((long)index * (long)size)];
                else
                    result = new byte[size];
                stream.Seek((long)index * (long)size, SeekOrigin.Begin);
                stream.Read(result, 0, result.Length);
            }
            return result;
        }

        /// <summary>
        /// 分块接受文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="index"></param>
        /// <param name="packageSize"></param>
        /// <param name="receiveSize"></param>
        /// <param name="data"></param>
        private static void FileWrite(string path, int index, long packageSize, int receiveSize, byte[] data)
        {
            using (System.IO.FileStream stream = System.IO.File.OpenWrite(path))
            {
                stream.Seek((long)index * (long)packageSize, System.IO.SeekOrigin.Begin);
                stream.Write(data, 0, receiveSize);
                stream.Flush();
            }
        }
    }
}
