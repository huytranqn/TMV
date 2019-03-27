namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;

    public partial class OnlineTMV : DbContext
    {
        public OnlineTMV()
            : base("name=OnlineTMV2")
        {
        }

        public virtual DbSet<HT_NHANVIEN> HT_NHANVIEN { get; set; }
        public virtual DbSet<INTRODUCE> INTRODUCE { get; set; }
        public virtual DbSet<Promotion> PROMOTION { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
