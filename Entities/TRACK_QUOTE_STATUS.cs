namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRACK_QUOTE_STATUS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRACK_QUOTE_STATUS()
        {
            TRACK_QUOTE = new HashSet<TRACK_QUOTE>();
            TRACK_QUOTE_STATUS_HISTORY = new HashSet<TRACK_QUOTE_STATUS_HISTORY>();
        }

        [Key]
        public int status_auto { get; set; }

        [Required]
        [StringLength(100)]
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACK_QUOTE> TRACK_QUOTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACK_QUOTE_STATUS_HISTORY> TRACK_QUOTE_STATUS_HISTORY { get; set; }
    }
}
