namespace EF.Model.CodeFristDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_MENU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_MENU()
        {
            TB_MENUROLE = new HashSet<TB_MENUROLE>();
        }

        [Key]
        [StringLength(50)]
        public string MENU_ID { get; set; }

        [StringLength(50)]
        public string MENU_NAME { get; set; }

        [StringLength(50)]
        public string MENU_URL { get; set; }

        [StringLength(50)]
        public string PARENT_ID { get; set; }

        [StringLength(10)]
        public string MENU_LEVEL { get; set; }

        [StringLength(50)]
        public string SORT_ORDER { get; set; }

        [StringLength(10)]
        public string STATUS { get; set; }

        [StringLength(1000)]
        public string REMARK { get; set; }

        [StringLength(50)]
        public string MENU_ICO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_MENUROLE> TB_MENUROLE { get; set; }
    }
}
