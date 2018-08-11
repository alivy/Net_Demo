using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Model
{
    public  class User_info
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public string User_Name { get; set; }
        public string User_Pwd { get; set; }
        public Nullable<int> User_Type { get; set; }
        public string Remark { get; set; }
    }
}
