
using EF;
using EF.Linq;
using Knowledge_Point知识点.MEF;
using Knowledge_Point知识点.MySocket;
using Knowledge_Point知识点.Unity;
//using Microsoft.Practices.Unity.Configuration;
using Skill_Point.委托;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Type_Conver;
using Utils工具;
using Utils工具.网络操作;

namespace Miao_ToolCase
{
    /// <summary>
    /// 扩展类
    /// </summary>
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

    public class Response
    {
        public string Flag { get; set; }
        public string Code { get; set; }

        public string Message { get; set; }
        /// <summary>
        /// 仓储系统入库单编码
        /// </summary>
        public string EntryOrderId { get; set; }
    }

    public class Department
    {
        /// <summary>    
        /// 部门ID    
        /// </summary>    
        public int DepartmentId { get; set; }

        /// <summary>    
        /// 部门名称    
        /// </summary>    
        public string DepartmentName { get; set; }



        /// <summary>  
        /// 员工列表  
        /// </summary>  
        public List<Emplayee> EmplayeeList { get; set; }
    }

    /// <summary>    
    /// 员工信息类    
    /// </summary>    
    public class Emplayee
    {
        /// <summary>    
        /// 员工姓名    
        /// </summary>    
        public DateTime? EmplayeeName { get; set; }
        /// <summary>    
        /// 员工姓名    
        /// </summary>    
        public string Emplayee_Name { get; set; }

        /// <summary>    
        /// 部门ID    
        /// </summary>    
        public int DepartmentId { get; set; }
    }






    public class Program
    {
        static void Main(string[] args)
        {
            new LinqSelect().INNER_JOIN();

            //var join = string.Join(",", "1,3,5,7,9");
            ////
            //int[] selects = Array.ConvertAll<string, int>(join.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries), s => s.StringToInt32());  //string分割转int[] 
            //var ids = join.ToCharArray();


            ////var tcp = new Knowledge_Point知识点.MySocket.TcpClient();

            //Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 200)); // 绑定IP+端口
            //server.Listen(10); // 开始监听

            //Console.WriteLine("等待连接...");

            //AcceptHelper ca = new AcceptHelper() { Bytes = new byte[2048] };
            //IAsyncResult res = server.BeginAccept(new AsyncCallback(ca.AcceptTarget), server);

            //string str = string.Empty;
            //while (str != "exit")
            //{
            //    str = Console.ReadLine();
            //    Console.WriteLine("ME: " + DateTimeOffset.Now.ToString("G"));
            //    ClientManager.SendMsgToClientList(str);
            //}
            //ClientManager.Close();
            //server.Close();



            //try
            //{
            //    //注册 log4net
            //    log4net.Config.XmlConfigurator.Configure(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4config\\log.xml"));
            //    //var a = new Log();
            //    TaskFactory taskFactory = new TaskFactory();
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Action act = () => LoggerHelper.Error("当前循环为" + i.ToString());
            //        //taskFactory.StartNew(act);
            //        new Task(act).Start();
            //    }
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}




            //TaskFactory taskFactory = new TaskFactory();
            //for (int i = 0; i < 10; i++)
            //{
            //    Action act = () => LoggerHelper.Error("当前循环为"+i.ToString()); 
            //    //taskFactory.StartNew(act);
            //    new Task(act).Start();
            //}


            //var a = new Log();


            //var dao = UnitySingleton.GetInstanceDAL<DIExampleClass>();
            //dao.DoWork();
            //Console.ReadLine();

            //string ip = Net.Ip;
            //string Host = Net.Host;
            //string myip = "113.116.77.4";
            //string GetLocation = Net.GetLocation(myip);
            //string Browser = Net.Browser;


            //Console.WriteLine("主线程开始" );

            //new ActionEntrust().Test();
            //Console.WriteLine("主线程结束");
            //int type = GetEnumValue(typeof(Page), "page2");
            //var partialView = Enum.GetName(typeof(Page), type);
            //List<int> list = new List<int>() { 1,2,3,4};
            //List<int> slidt = new List<int>() { 1, 2, 3, 5 };
            //List<int> Result = list.Union(slidt).ToList();          //剔除重复项
            //Result = list.Concat(slidt).ToList();          //保留重复项
            //string json = string.Join(",", list);






            //response result = new response();
            //result.flag = "success";
            //result.code = "1";
            //result.message = "成功";
            //result.entryOrderId = "1";
            //string xml = XmlSerialize<response>(result);



            //using (MemoryStream ms = new MemoryStream())
            //{
            //    var setting = new XmlWriterSettings() { Encoding = new UTF8Encoding(false), Indent = true, };
            //    using (XmlWriter writer = XmlWriter.Create(ms, setting))
            //    {
            //        XmlSerializer xmlSearializer = new XmlSerializer(typeof(response));
            //        xmlSearializer.Serialize(writer, result);
            //        var OutputXmlString = Encoding.UTF8.GetString(ms.ToArray());
            //    }
            //}





            //List<IDCardNumber> ss = IDCardNumber.Radom(50);


            //var card = IDCardNumber.GenPinCode();
            //var OverdueDay =  DateTime.Now.CompareTo(DateTime.Now.AddDays(-5));
            //bool Is_sure = false;
            //do
            //{
            //    if (2 < 1) 
            //        Console.WriteLine("2<1");

            //    else 
            //         Console.WriteLine("2>1");
            //    if (3 > 1) 
            //        Console.WriteLine("3>1");

            //} while (Is_sure);



            //MEF_Base MEF = new MEF_Realize();
            //MEF = new MEF_Realize_B();
            //MEF = new MEF_Realize_C();
            //int OverdueDay = (DateTime.Now - DateTime.Now.AddDays(-5)).Days;

            //new LinqSelect().INNER_JOIN();

            //Copy copy = new Copy();
            //new BatchExtensions().ss();
            //List<Emplayee> emplayeeList = GetEmplayeeList();

            //获取员工信息列表    
            //string empNames = ""; //员工名称字段  
            //emplayeeList.ForEach(a => a.Emplayee_Name += a.EmplayeeName.ToString());

            //使用ForEach输入结果  
            //emplayeeList.ForEach(a => Console.WriteLine(String.Format("员工名称：{0} and {1}", a.Emplayee_Name,a.EmplayeeName)));

            //empNames = empNames.TrimEnd(',');
            //Console.WriteLine(empNames);      

        }


      
        public static int GetEnumValue(Type enumType, string enumName)
        {
            try
            {
                if (!enumType.IsEnum)
                    throw new ArgumentException("enumType必须是枚举类型");
                var values = Enum.GetValues(enumType);
                var ht = new Hashtable();
                foreach (var val in values)
                {
                    ht.Add(Enum.GetName(enumType, val), val);
                }
                return (int)ht[enumName];
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        enum Page
        {
            page1 = 99,
            page2 = 2,
            page3 = 1,
            page4 = 98,
            page5 = 4,
            page6 = -1,
            page7 = -2,
            page9 = 2,
            page8 = -3,
        }

        public static string XmlSerialize<T>(T obj)
        {

            string OutputXmlString = string.Empty;
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    var setting = new XmlWriterSettings() { Encoding = new UTF8Encoding(false), Indent = true, };
            //    using (XmlWriter writer = XmlWriter.Create(ms, setting))
            //    {
            //        XmlSerializer xmlSearializer = new XmlSerializer(typeof(T));
            //        xmlSearializer.Serialize(writer, obj);
            //        OutputXmlString = Encoding.UTF8.GetString(ms.ToArray());
            //    }
            //}
            //return OutputXmlString;
            var setting = new XmlWriterSettings() { Encoding = new UTF8Encoding(false), Indent = true, };
            using (StringWriter sw = new StringWriter())
            {
                Type t = obj.GetType();
                XmlSerializer serializer = new XmlSerializer(obj.GetType())
                 ;
                XmlDocument myXmlDoc = new XmlDocument();

                serializer.Serialize(sw, obj);

                sw.Close();
                OutputXmlString = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(sw.ToString())); ;
                return OutputXmlString;
            }
        }

        /// <summary>    
        /// 使用ForEach将部门列表与员工列表关联   
        /// </summary>     
        public static void JoinDepartmentList()
        {
            List<Department> departmentList = GetDepartmentList();   //获取部门信息列表    
            List<Emplayee> emplayeeList = GetEmplayeeList();         //获取员工信息列表    
            departmentList.ForEach(a => a.EmplayeeList = emplayeeList.Where(e => e.DepartmentId == a.DepartmentId).ToList());

            //使用ForEach输入结果  
            departmentList.ForEach(a => Console.WriteLine(String.Format("{0}:员工数量：{1}", a.DepartmentName, a.EmplayeeList.Count)));
        }

        /// <summary>    
        /// 获取员工信息列表    
        /// </summary>    
        /// <returns></returns>    
        public static List<Emplayee> GetEmplayeeList()
        {
            List<Emplayee> emplayeeList = new List<Emplayee>();
            Emplayee emplayee1 = new Emplayee() { EmplayeeName = DateTime.Now, DepartmentId = 1, };
            Emplayee emplayee2 = new Emplayee() { EmplayeeName = DateTime.Now.AddDays(1), DepartmentId = 2, };
            Emplayee emplayee3 = new Emplayee() { EmplayeeName = DateTime.Now.AddDays(-1), DepartmentId = 2, };
            emplayeeList.Add(new Emplayee() { EmplayeeName = DateTime.Now, DepartmentId = 1, });
            emplayeeList.Add(new Emplayee() { EmplayeeName = DateTime.Now.AddDays(1), DepartmentId = 2, });
            emplayeeList.Add(new Emplayee() { EmplayeeName = DateTime.Now.AddDays(-1), DepartmentId = 2, });
            return emplayeeList;
        }

        /// <summary>    
        /// 获取部门信息列表    
        /// </summary>    
        /// <returns></returns>    
        public static List<Department> GetDepartmentList()
        {
            List<Department> departmentList = new List<Department>();
            Department department1 = new Department() { DepartmentId = 1, DepartmentName = "研发部" };
            Department department2 = new Department() { DepartmentId = 2, DepartmentName = "人事部" };
            Department department3 = new Department() { DepartmentId = 3, DepartmentName = "财务部" };
            departmentList.Add(department1);
            departmentList.Add(department2);
            departmentList.Add(department3);
            return departmentList;
        }
    }
}
