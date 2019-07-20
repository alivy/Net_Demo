using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils工具.ASPOSE;

namespace Miao_ToolCase.Action
{
    public class FileStreamShow : ShowInterface
    {
        public void Show()
        {
            setText();
        }



        public static void getText()
        {
            string strTest = string.Format("{0}\t{1}", 1, "a");

            //System.IO.File.WriteAllText(@"C:\testDir\test1.txt", strTest, Encoding.UTF8);
            string strTest1 = string.Format("{0}\t{1}", 2, "b");
            //BB(strTest);
            //BB(strTest1);
            //System.IO.File.WriteAllText(@"C:\testDir\test1.txt", strTest1, Encoding.UTF8);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"F:\\test2.txt", true))
            {
                file.WriteLine(strTest);// 直接追加文件末尾，换行 
            }

        }

        public static void BB(string str)
        {
            FileStream fs = new FileStream(@"F:\\test2.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.Write(str);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }

        //读取数据
        public static void setText()
        {
            string file = "F:\\openQuestion.txt";
            var lines = File.ReadAllLines(file, Encoding.UTF8);
            foreach (var line in lines)
            {
                var ss = line.Split('\t');
                Console.WriteLine("{0},{1},{2},{3}", ss[0], ss[1], ss[2], ss[3]);
            }
        }
    }
}
