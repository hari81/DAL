namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("APPLICATION")]
    public partial class APPLICATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public APPLICATION()
        {
            LU_MMTA = new HashSet<LU_MMTA>();
        }

        [Key]
        public short app_auto { get; set; }

        [Required]
        [StringLength(50)]
        public string appid { get; set; }

        [Required]
        [StringLength(255)]
        public string appdesc { get; set; }

        public int? cs_app_auto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LU_MMTA> LU_MMTA { get; set; }
    }
}
