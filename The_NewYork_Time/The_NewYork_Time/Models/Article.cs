namespace The_NewYork_Time.Models
{
    using System;
    using System.Collections.Generic;
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

        public string image1 { get; set; }

        public string image2 { get; set; }

        public string image3 { get; set; }

        public string image4a { get; set; }

        public string image4b { get; set; }

        public string image5 { get; set; }

        public string content1 { get; set; }

        public string content2 { get; set; }

        public string content3 { get; set; }

        public string content4 { get; set; }

        public string content5 { get; set; }

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
