using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Model
{
    public class User_Organize
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] //不自动增长
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] //设置为主键
        public string OrganizeCode { get; set; }
        public string OrganizeName { get; set; }
        public string ParentCode { get; set; }
    }
}
