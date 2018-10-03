namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRACK_TOOL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRACK_TOOL()
        {
            COMP_Inventory_Inspec_Details = new HashSet<COMP_Inventory_Inspec_Details>();
            COMPART_TOOL_IMAGE = new HashSet<COMPART_TOOL_IMAGE>();
            TRACK_COMPART_EXT = new HashSet<TRACK_COMPART_EXT>();
            TRACK_COMPART_WORN_LIMIT_CAT = new HashSet<TRACK_COMPART_WORN_LIMIT_CAT>();
            TRACK_COMPART_WORN_LIMIT_ITM = new HashSet<TRACK_COMPART_WORN_LIMIT_ITM>();
            TRACK_INSPECTION_DETAIL = new HashSet<TRACK_INSPECTION_DETAIL>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int tool_auto { get; set; }

        [Required]
        [StringLength(50)]
        public string tool_name { get; set; }

        [StringLength(10)]
        public string tool_code { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMP_Inventory_Inspec_Details> COMP_Inventory_Inspec_Details { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMPART_TOOL_IMAGE> COMPART_TOOL_IMAGE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACK_COMPART_EXT> TRACK_COMPART_EXT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACK_COMPART_WORN_LIMIT_CAT> TRACK_COMPART_WORN_LIMIT_CAT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACK_COMPART_WORN_LIMIT_ITM> TRACK_COMPART_WORN_LIMIT_ITM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACK_INSPECTION_DETAIL> TRACK_INSPECTION_DETAIL { get; set; }
    }
}
