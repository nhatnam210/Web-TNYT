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

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string articlename { get; set; }

        [Required]
        [StringLength(500)]
        public string description { get; set; }

        public string image { get; set; }

        public string contentarticle { get; set; }

        public bool isLogin = false;
        public bool isShowSave = false;

        [Required]
        [StringLength(50)]
        public string author { get; set; }

        public DateTime date { get; set; }

        public int idcategory { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Storage> Storages { get; set; }
    }
}
