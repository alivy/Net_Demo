using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miao_ToolCase.Action
{
   
    /// <summary>
    /// list操作类
    /// </summary>
    public class ListShow : ShowInterface
    {
        public void Show()
        {
            // ListToJoin();
            ListForeach();
        }

        public void ListForeach()
        {
            List<Department> departments = new List<Department>();
            for (int i = 0; i < 5; i++)
            {
                Department department = new Department();
                department.DepartmentId = i;
                for (int j = 0; i < 3; j++)
                {
                    department.DepartmentName = "张三"+j;
                    departments.Add(department);
                }
            }
            var list = departments;
        }




        private void ListToJoin()
        {
            List<test> tests = new List<test>();
            string a = "1,2,3,4,5";
            var ss = string.Join(",", a).ToList();
            Console.WriteLine(ss[0] + "dasdas" + ss.Count);
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
