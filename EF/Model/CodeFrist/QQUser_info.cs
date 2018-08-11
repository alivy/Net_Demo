namespace EF.Model.CodeFrist
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[Table("QQUser_info")]
    public partial class QQUser_info
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string openId { get; set; }

        [StringLength(50)]
        public string nickname { get; set; }

        [StringLength(50)]
        public string gender { get; set; }

        [StringLength(50)]
        public string province { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        [StringLength(50)]
        public string year { get; set; }

        [StringLength(1024)]
        public string figureurl { get; set; }

        [StringLength(1024)]
        public string figureurl_2 { get; set; }

        [StringLength(1024)]
        public string figureurl_qq_2 { get; set; }
    }
}
