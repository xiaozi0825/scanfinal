namespace Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserDetail")]
    public partial class UserDetail
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(255)]
        public string UserAccount { get; set; }

        [StringLength(255)]
        public string UserPassword { get; set; }

        [StringLength(255)]
        public string UserName { get; set; }

        public int? UserSex { get; set; }

        [StringLength(255)]
        public string UserEmail { get; set; }
    }
}
