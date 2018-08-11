using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Skill_Point
{

    /// <summary>  
    /// 反射处理类  
    /// </summary>  
    public class AssemblyHandler
    {
        //获取bin文件程序集元素
        string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

        /// <summary>  
        /// 获取程序集名称列表  
        /// </summary>  
        public AssemblyResult GetAssemblyName()
        {
            AssemblyResult result = new AssemblyResult();
            string[] dicFileName = Directory.GetFileSystemEntries(path);
            if (dicFileName != null)
            {
                List<string> assemblyList = new List<string>();
                foreach (string name in dicFileName)
                {
                    assemblyList.Add(name.Substring(name.LastIndexOf('/') + 1));
                }
                result.AssemblyName = assemblyList;
            }
            return result;
        }

        /// <summary>  
        /// 获取程序集中的类名称  
        /// </summary>  
        /// <param name="assemblyName">程序集</param>  
        public AssemblyResult GetClassName(string assemblyName)
        {
            AssemblyResult result = new AssemblyResult();
            if (!String.IsNullOrEmpty(assemblyName))
            {
                assemblyName = path + assemblyName;
                Assembly assembly = Assembly.LoadFrom(assemblyName);
                Type[] ts = assembly.GetTypes();
                List<string> classList = new List<string>();
                foreach (Type t in ts)
                {
                    //classList.Add(t.Name);  
                    classList.Add(t.FullName);
                }
                result.ClassName = classList;
            }
            return result;
        }

        /// <summary>  
        /// 获取类的属性、方法  
        /// </summary>  
        /// <param name="assemblyName">程序集</param>  
        /// <param name="className">类名</param>  
        public AssemblyResult GetClassInfo(string assemblyName, string className)
        {
            AssemblyResult result = new AssemblyResult();
            if (!String.IsNullOrEmpty(assemblyName) && !String.IsNullOrEmpty(className))
            {
                assemblyName = path + assemblyName;
                Assembly assembly = Assembly.LoadFrom(assemblyName);
                Type type = assembly.GetType(className, true, true);
                if (type != null)
                {
                    //类的属性  
                    List<string> propertieList = new List<string>();
                    PropertyInfo[] propertyinfo = type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    foreach (PropertyInfo p in propertyinfo)
                    {
                        propertieList.Add(p.ToString());
                    }
                    result.Properties = propertieList;

                    //类的方法  
                    List<string> methods = new List<string>();
                    MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    foreach (MethodInfo mi in methodInfos)
                    {
                        methods.Add(mi.Name);
                        //方法的参数  
                        //foreach (ParameterInfo p in mi.GetParameters())  
                        //{  

                        //}  
                        //方法的返回值  
                        //string returnParameter = mi.ReturnParameter.ToString();  
                    }
                    result.Methods = methods;
                }
            }
            return result;
        }

        /// <summary>
        /// 反射获取程序方法
        /// </summary>
        /// <param name="Method_Name">指定程序集</param>
        /// <param name="Assembly_Name">指定类</param>
        /// <param name="Class_Name">指定方法名</param>
        /// <param name="parameter">指定参数</param>
        public void AssemblyMethod(string Assembly_Name, string Class_Name, string Method_Name, object parameter)
        {
            Assembly_Name = "TestLibrary";
            Class_Name = "TestLibrary.Post";
            Method_Name = "demo";
            parameter = 123;
            Type tp = Activator.CreateInstance("", "").Unwrap().GetType(); //反射创建对象

            MethodInfo mi = tp.GetMethod(Method_Name);//得到方法函数的信息
            object ob = Activator.CreateInstance(tp);//对得到的tp实例化对象

            //设置Show_Str方法中的参数值；如有多个参数可以追加多个   
            Object[] params_obj = new Object[1];
            params_obj[0] = parameter;

            object res = mi.Invoke(ob, params_obj);//执行方法
            Console.WriteLine(res.ToString());
        }

    }
}
