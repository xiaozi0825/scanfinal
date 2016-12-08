namespace Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Local")]
    public partial class Local
    {
        public int LocalId { get; set; }

        [StringLength(255)]
        public string LocalName { get; set; }

        [StringLength(255)]
        public string LocalAdd { get; set; }

        [StringLength(255)]
        public string LocalOpenTime { get; set; }

        [StringLength(255)]
        public string LocalTicketinfo { get; set; }

        public int? LocalLat { get; set; }

        public int? LocalLng { get; set; }

        public int? LocalImgid { get; set; }
        
    }
}
