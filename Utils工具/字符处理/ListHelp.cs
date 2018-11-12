using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils工具.字符处理
{
    class ListHelp
    {
        public ListHelp() {
            List<int> list = new List<int>() { 1, 2, 3, 4 };
            List<int> slidt = new List<int>() { 1, 2, 3, 5 };
            List<int> Result = list.Union(slidt).ToList();          //剔除重复项
            Result = list.Concat(slidt).ToList();          //保留重复项
            string json = string.Join(",", list);
        }
    }
}
