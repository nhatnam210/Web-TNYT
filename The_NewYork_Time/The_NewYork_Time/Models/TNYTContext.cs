using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace The_NewYork_Time.Models
{
    public partial class TNYTContext : DbContext
    {
        public TNYTContext()
            : base("name=TNYTContext")
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Cetegories { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .HasMany(e => e.Storages)
                .WithRequired(e => e.Article)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Articles)
                .WithRequired(e => e.Cetegory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Section>()
                .HasMany(e => e.Cetegories)
                .WithRequired(e => e.Section)
                .WillCascadeOnDelete(false);
        }
    }
}
