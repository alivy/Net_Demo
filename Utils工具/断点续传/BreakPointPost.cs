using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils工具.断点续传
{
    /// <summary>
    /// 参考下面网站编写
    /// https://blog.csdn.net/shi0090/article/details/46855097
    /// </summary>
    public class BreakPointPost
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public long FileSize { get; set; }
        /// <summary>
        /// 数据包的大小
        /// </summary>
        public long PackageSize { get; set; }

        /// <summary>
        /// 传输总次数
        /// </summary>
        public int PackageCount { get; set; }
        /// <summary>
        /// 当前传输位置
        /// </summary>
        public int Index { get; set; }
    }
}
