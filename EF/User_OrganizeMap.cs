//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class User_OrganizeMap
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string OrganizeCode { get; set; }
    
        public virtual User_OrganizeMap User_OrganizeMap1 { get; set; }
        public virtual User_OrganizeMap User_OrganizeMap2 { get; set; }
        public virtual User_OrganizeMap User_OrganizeMap11 { get; set; }
        public virtual User_OrganizeMap User_OrganizeMap3 { get; set; }
    }
}
