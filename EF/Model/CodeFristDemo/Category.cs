using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Model.CodeFristDemo
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string CategoryName { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<TB_USERS> Blogs { get; set; }

        //public Category()
        //{
        //    Blogs = new HashSet<TB_USERS>();
        //}
    }
}
