using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace The_NewYork_Time.Models
{
    public partial class TNYTModel : DbContext
    {
        public TNYTModel()
            : base("name=TNYT")
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Cetegory> Cetegories { get; set; }
        public virtual DbSet<Section> Sections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Section>()
                .HasMany(e => e.Articles)
                .WithRequired(e => e.Section)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Section>()
                .HasMany(e => e.Cetegories)
                .WithRequired(e => e.Section)
                .WillCascadeOnDelete(false);
        }
    }
}
