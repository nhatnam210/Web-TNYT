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
        public virtual DbSet<Category> Categories { get; set; }
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
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.idcategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Section>()
                .HasMany(e => e.Categories)
                .WithRequired(e => e.Section)
                .HasForeignKey(e => e.idsection)
                .WillCascadeOnDelete(false);
        }
        public System.Data.Entity.DbSet<TNYT.AspNetUser> AspNetUsers { get; set; }
    }
}
