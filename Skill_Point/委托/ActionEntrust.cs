using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_Point.委托
{
    /// <summary>
    /// 委托执行方法
    /// </summary>
    public  class ActionEntrust
    {
        private int  One(int num) {
            Console.WriteLine("执行方法A" + num);
            return num;
        }
        private int Two(int num)
        {
            Console.WriteLine("执行方法B" + num);
            return num;
        }
        private int Three(int num)
        {
            Console.WriteLine("执行方法C" + num);
         
            return num;
        }



        public  void Test() {
            
            Task.Run(() => {
                One(1);
                Two(2);
                Three(3);
            });
        }
    }
}
