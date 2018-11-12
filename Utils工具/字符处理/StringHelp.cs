using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils工具.字符处理
{
    class StringHelp
    {
        public void symbol()
        {
            string test = "";
            string[] array = test.Split(',');
            string str = "";
            foreach (string item in array)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    str += item + ",";
                }
            }
            if (!string.IsNullOrEmpty(str))
            {
                str = str.Remove(str.LastIndexOf(","), 1);
            }
            Console.WriteLine(str);
        }

        public void ss() {

            var join = string.Join(",", "1,,3,5,7,9");
            int[] selects = Array.ConvertAll<string, int>(join.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries), s => s.StringToInt32());  //string分割转int[] 
            var ids = join.ToCharArray();
        }
        /// <summary>
        /// 扩展类
        /// </summary>
        
    }

    public static class Extension
    {
        public static int StringToInt32(this string str)
        {
            int num = -1;
            if (int.TryParse(str, out num))
            {
                return num;
            }
            else
            {
                return -1;
            }
        }
    }
}
