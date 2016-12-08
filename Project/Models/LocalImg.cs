namespace Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LocalImg")]
    public partial class LocalImg
    {
        public int LocalImgId { get; set; }

        [StringLength(255)]
        public string ImgName { get; set; }

        [StringLength(255)]
        public string ImgType { get; set; }

        public int? InfoId { get; set; }
    }
}
