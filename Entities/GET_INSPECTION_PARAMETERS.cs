namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_INSPECTION_PARAMETERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GET_INSPECTION_PARAMETERS()
        {
            GET_IMPLEMENT_INSPECTION_IMAGE = new HashSet<GET_IMPLEMENT_INSPECTION_IMAGE>();
            GET_INSPECTION_CONSTANTS = new HashSet<GET_INSPECTION_CONSTANTS>();
        }

        [Key]
        public int parameter_type { get; set; }

        [Required]
        [StringLength(64)]
        public string parameter_desc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GET_IMPLEMENT_INSPECTION_IMAGE> GET_IMPLEMENT_INSPECTION_IMAGE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GET_INSPECTION_CONSTANTS> GET_INSPECTION_CONSTANTS { get; set; }
    }
}
