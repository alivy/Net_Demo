using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miao_ToolCase
{


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



    public class test
    {
        public int id { get; set; }

        public string num { get; set; }
    }
}

