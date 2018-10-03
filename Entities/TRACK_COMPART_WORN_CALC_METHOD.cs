namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRACK_COMPART_WORN_CALC_METHOD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRACK_COMPART_WORN_CALC_METHOD()
        {
            TRACK_COMPART_EXT = new HashSet<TRACK_COMPART_EXT>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int track_compart_worn_calc_method_auto { get; set; }

        [Required]
        public string track_compart_worn_calc_method_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACK_COMPART_EXT> TRACK_COMPART_EXT { get; set; }
    }
}
