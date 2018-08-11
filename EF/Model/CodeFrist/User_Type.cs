namespace EF.Model.CodeFrist
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Type
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserType_ID { get; set; }

        [StringLength(50)]
        public string UserType_Name { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }
    }
}
