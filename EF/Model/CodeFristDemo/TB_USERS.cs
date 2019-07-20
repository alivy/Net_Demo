namespace EF.Model.CodeFristDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_USERS
    {
        [Key]
        [StringLength(50)]
        public string USER_ID { get; set; }

        [StringLength(50)]
        public string USER_NAME { get; set; }

        [StringLength(50)]
        public string USER_PASSWORD { get; set; }

        [StringLength(50)]
        public string FULLNAME { get; set; }

        [StringLength(50)]
        public string DEPARTMENT_ID { get; set; }

        [StringLength(10)]
        public string STATUS { get; set; }

        public DateTime? CREATETIME { get; set; }

        public DateTime? MODIFYTIME { get; set; }

        [StringLength(1000)]
        public string REMARK { get; set; }

        public virtual TB_DEPARTMENT1 TB_DEPARTMENT1 { get; set; }
    }
}
