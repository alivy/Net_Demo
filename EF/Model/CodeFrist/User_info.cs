namespace EF.Model.CodeFrist
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_info
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string UserID { get; set; }

        [StringLength(50)]
        public string User_Name { get; set; }

        [StringLength(50)]
        public string User_Pwd { get; set; }

        public int? User_Type { get; set; }

        [StringLength(100)]
        public string Remark { get; set; }
    }
}
