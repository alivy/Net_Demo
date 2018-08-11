
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_Point
{
    public class Entrust
    {
        #region 匿名委托

        //声明委托
        public delegate void MyDelegate(string name);

        //基于MyDelegate委托定义事件
        public event MyDelegate MyEvent;


        static void Anonymous()
        {
            Entrust personManager = new Entrust();
            //使用匿名方法绑定事件的处理
            personManager.MyEvent += delegate(string name)
            {
                Console.WriteLine("My name is " + name);
            };
            personManager.Execute("Leslie");
        }

        //执行事件
        public void Execute(string name)
        {
            if (MyEvent != null)
                //执行事件
                MyEvent(name);
        }
        #endregion

        #region   泛型委托 Predicate<T>

        /// <summary>
        /// 泛型委托 Predicate<T>
        /// </summary>
        public static void Predicate()
        {
            List<Person> list = GetList();
            //绑定查询条件
            Predicate<Person> predicate = new Predicate<Person>(Match);
            List<Person> result = list.FindAll(predicate);
            Console.WriteLine("Person count is :" + result[0].Name.ToString());
        }



        //模拟源数据
        static List<Person> GetList()
        {
            var personList = new List<Person>();
            var person1 = new Person(1, "Leslie", 29);
            personList.Add(person1);
            return personList;
        }
        //查询条件
        static bool Match(Person person)
        {

            return person.Age <= 30;
        }
        #endregion

        #region 泛型委托  Action
        /// <summary>
        /// 泛型委托 Action( Action是无返回值的泛型委托)
        /// </summary>
        public static void Action()
        {
            Action<string> action = ShowMessage;
            action("Hello World");
        }

        static void ShowMessage(string message)
        {
            Console.WriteLine("Action委托结果：" + message);
        }

        #endregion

        #region 泛型委托  Func
        /// <summary>
        /// 泛型委托 Func (Func 必须具有返回值)
        /// </summary>
        public static double Func(int num)
        {

            Func<double, bool, double> func = Account;
            return func(num, true);
        }

        /// <summary>
        /// 泛型委托 Func方法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static double Account(double a, bool condition)
        {
            if (condition)
                return a * 1.5;
            else
                return a * 2;
        }
        #endregion
    }
}
