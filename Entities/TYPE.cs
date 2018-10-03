namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TYPE")]
    public partial class TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TYPE()
        {
            LU_MMTA = new HashSet<LU_MMTA>();
        }

        [Key]
        public int type_auto { get; set; }

        [Required]
        [StringLength(50)]
        public string typeid { get; set; }

        [Required]
        [StringLength(50)]
        public string typedesc { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(50)]
        public string created_user { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(50)]
        public string modified_user { get; set; }

        public int? cs_type_auto { get; set; }

        public int? blob_auto { get; set; }

        public int? blob_large_auto { get; set; }

        public long? default_smu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LU_MMTA> LU_MMTA { get; set; }
    }
}
