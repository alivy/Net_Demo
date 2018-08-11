namespace EF.Model.CodeFrist
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Organize
    {
        [Key]
        [StringLength(50)]
        public string OrganizeCode { get; set; }

        [StringLength(50)]
        public string OrganizeName { get; set; }

        [StringLength(50)]
        public string ParentCode { get; set; }
    }
}
