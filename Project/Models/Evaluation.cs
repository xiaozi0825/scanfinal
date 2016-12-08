namespace Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Evaluation")]
    public partial class Evaluation
    {
        public int EvaluationId { get; set; }

        public bool Like { get; set; }

        public int? UserId { get; set; }

        public int? IntroId { get; set; }
    }
}
