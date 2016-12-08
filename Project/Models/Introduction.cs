
namespace Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Introduction")]
    public partial class Introduction
    {
        public int IntroductionId { get; set; }
        
        public string LocationName { get; set; }
        
        public string IntroductionContents { get; set; }

        [StringLength(20)]
        public string Lat { get; set; }

        [StringLength(20)]
        public string Lon { get; set; }

    }
}
