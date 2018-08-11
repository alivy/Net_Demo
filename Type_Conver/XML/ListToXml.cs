using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Type_Conver
{
    public class ListToXml
    {
        /// <summary>
        /// 模拟list转xml格式
        /// </summary>
        public static void ListOrXml()
        {
            try
            {
                List<UserModel> list = new List<UserModel>();
                list.Add(new UserModel());
                list.Add(new UserModel());
                list.Add(new UserModel());
                list.Add(new UserModel());
                list.Add(new UserModel());
                list.Add(new UserModel());
                list.Add(new UserModel());
                list.Add(new UserModel());
                list.Add(new UserModel());
                list.Add(new UserModel());

                string xml = Toxml.listToXml(list);

                Toxml.FileToXml(list);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("====================================");
                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine(ex.StackTrace);
            }
        }

    }
}
