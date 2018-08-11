using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Model
{
    public  class User_Type
    {
         [Key]
        public int UserType_ID { get; set; }
        public string UserType_Name { get; set; }
        public string Remark { get; set; }
    }
}
