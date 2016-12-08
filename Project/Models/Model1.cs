namespace Project.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Evaluation> Evaluation { get; set; }
        public virtual DbSet<Local> Local { get; set; }
        public virtual DbSet<LocalImg> LocalImg { get; set; }
        public virtual DbSet<LocalIntroduce> LocalIntroduce { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UserDetail> UserDetail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
