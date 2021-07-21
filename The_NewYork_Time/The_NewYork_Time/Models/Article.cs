namespace The_NewYork_Time.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Article")]
    public partial class Article
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Article()
        {
            Storages = new HashSet<Storage>();
        }

        [Key]
        public int idarticle { get; set; }

        [Required]
        [StringLength(255)]
        public string articlename { get; set; }

        [Required]
        [StringLength(500)]
        public string description { get; set; }

        [DisplayName("image")]
        public string image1 { get; set; }


        [DisplayName("content")]
        public string content1 { get; set; }

       

        [Required]
        [StringLength(255)]
        public string author { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        public int idcategory { get; set; }

        public virtual Category Cetegory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Storage> Storages { get; set; }
    }
}
