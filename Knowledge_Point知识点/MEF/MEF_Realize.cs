using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Point知识点.MEF
{
     public class MEF_Base 
     {
         /// <summary>
         /// 实现注入
         /// </summary>
         public void Compose<T>(T t)
         {
             //获取当前执行的程序集中所有的标有特性标签的代码段  
             var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
             //将所有Export特性标签存放进组件容器中（其实是一个数组里面）  
             CompositionContainer container = new CompositionContainer(catalog);
             //找到所传入对象中所有拥有Import特性标签的属性，并在组件容器的数组中找到与这些属性匹配的Export特性标签所标注的类，然后进行实例化并给这些属性赋值。  
             //简而言之，就是找到与Import对应的Export所标注的类，并用这个类的实例来给Import所标注的属性赋值，用于解耦。  
             container.ComposeParts(t);
         }
     }

    /// <summary>
    /// 无契约名的单个对象注入匹配
    /// </summary>
     public class MEF_Realize : MEF_Base
    {
        [Import]
        public IBookService Service { get; set; }

        /// <summary>
        /// 无契约名的单个对象注入匹配
        /// </summary>
        public MEF_Realize()
        {
            Compose(this);
            if (Service != null)
            {
                Console.WriteLine("***********无契约名的单个对象注入匹配***********");
                Console.WriteLine(Service.GetBookName());
                Console.WriteLine("***********无契约名的单个对象注入匹配***********");
            }
        }
       
    }
    /// <summary>
    /// 有契约名的单个对象注入匹配
    /// </summary>
     public class MEF_Realize_B : MEF_Base
    {
        [Import("GreenBook")]
        public IBookService ServiceB { get; set; }

        /// <summary>
        /// 有契约名的单个对象注入匹配
        /// (接收为单个对象，匹配多个对象则无法通过)
        /// </summary>
        public MEF_Realize_B()
        {
           Compose(this);
            if (ServiceB != null)
            {
                Console.WriteLine("***********有契约名的单个对象注入匹配***********");
                Console.WriteLine(ServiceB.GetBookName());
                Console.WriteLine("***********有契约名的单个对象注入匹配***********");
            }
        }
    }

    /// <summary>
    /// 有契约名的多个对象注入匹配
    /// </summary>
     public class MEF_Realize_C : MEF_Base
    {
        [ImportMany("MusicBook")]
        public IEnumerable<IBookService> ServiceC { get; set; }
        /// <summary>
        /// 有契约名的多个对象注入匹配
        /// </summary>
        public MEF_Realize_C()
        {
            Compose(this);
            if (ServiceC != null)
            {
                Console.WriteLine("***********有契约名的多个对象注入匹配***********");
                foreach (var s in ServiceC)
                {
                    //针对指定了契约名但没指定对象信息
                    Console.WriteLine(s.GetBookName());
                }
                Console.WriteLine("***********有契约名的多个对象注入匹配***********");
            }
        }
    }
}
