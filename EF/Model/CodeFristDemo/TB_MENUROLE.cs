namespace EF.Model.CodeFristDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_MENUROLE
    {
        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(50)]
        public string ROLE_ID { get; set; }

        [StringLength(50)]
        public string MENU_ID { get; set; }

        [StringLength(10)]
        public string ROLE_TYPE { get; set; }

        [StringLength(50)]
        public string BUTTON_ID { get; set; }

        public virtual TB_MENU TB_MENU { get; set; }

        public virtual TB_ROLE TB_ROLE { get; set; }
    }
}
