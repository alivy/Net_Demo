namespace EF.Model.CodeFristDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_ROLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_ROLE()
        {
            TB_MENUROLE = new HashSet<TB_MENUROLE>();
            TB_USERROLE = new HashSet<TB_USERROLE>();
        }

        [Key]
        [StringLength(50)]
        public string ROLE_ID { get; set; }

        [StringLength(50)]
        public string ROLE_NAME { get; set; }

        [StringLength(500)]
        public string DESCRIPTION { get; set; }

        public DateTime? CREATETIME { get; set; }

        public DateTime? MODIFYTIME { get; set; }

        [StringLength(100)]
        public string ROLE_DEFAULTURL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_MENUROLE> TB_MENUROLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_USERROLE> TB_USERROLE { get; set; }
    }
}
