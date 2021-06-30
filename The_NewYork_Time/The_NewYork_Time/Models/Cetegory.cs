namespace The_NewYork_Time.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cetegory")]
    public partial class Cetegory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cetegory()
        {
            Articles = new HashSet<Article>();
        }

        [Key]
        public int idcategory { get; set; }

        [Required]
        [StringLength(50)]
        public string categoryname { get; set; }

        public int idsection { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Articles { get; set; }

        public virtual Section Section { get; set; }
    }
}
