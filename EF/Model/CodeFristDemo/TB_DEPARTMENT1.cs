namespace EF.Model.CodeFristDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_DEPARTMENT1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_DEPARTMENT1()
        {
            TB_USERS = new HashSet<TB_USERS>();
        }

        [Key]
        [StringLength(50)]
        public string DEPARTMENT_ID { get; set; }

        [StringLength(50)]
        public string DEPARTMENT_NAME { get; set; }

        [StringLength(50)]
        public string PARENT_ID { get; set; }

        [StringLength(10)]
        public string DEPARTMENT_LEVEL { get; set; }

        [StringLength(10)]
        public string STATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_USERS> TB_USERS { get; set; }
    }
}
