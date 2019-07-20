namespace EF.Model.CodeFristDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_USERROLE
    {
        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(50)]
        public string ROLE_ID { get; set; }

        [StringLength(50)]
        public string USER_ID { get; set; }

        public virtual TB_ROLE TB_ROLE { get; set; }
    }
}
