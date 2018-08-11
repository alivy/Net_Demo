namespace EF.Model.CodeFrist
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_OrganizeMap
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }

        [StringLength(50)]
        public string OrganizeCode { get; set; }

        public virtual User_OrganizeMap User_OrganizeMap1 { get; set; }

        public virtual User_OrganizeMap User_OrganizeMap2 { get; set; }

        public virtual User_OrganizeMap User_OrganizeMap11 { get; set; }

        public virtual User_OrganizeMap User_OrganizeMap3 { get; set; }
    }
}
