namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MAKE")]
    public partial class MAKE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MAKE()
        {
            EQUIPMENTs = new HashSet<EQUIPMENT>();
            LU_MMTA = new HashSet<LU_MMTA>();
            TRACK_COMPART_EXT = new HashSet<TRACK_COMPART_EXT>();
        }

        [Key]
        public int make_auto { get; set; }

        [Required]
        [StringLength(50)]
        public string makeid { get; set; }

        [Required]
        [StringLength(50)]
        public string makedesc { get; set; }

        [StringLength(50)]
        public string dbs_id { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(50)]
        public string created_user { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(50)]
        public string modified_user { get; set; }

        public int? cs_make_auto { get; set; }

        public bool cat { get; set; }

        public bool? Oil { get; set; }

        public bool? Components { get; set; }

        public bool? Undercarriage { get; set; }

        public bool? Tyre { get; set; }

        public bool? Rim { get; set; }

        public bool? Hydraulic { get; set; }

        public bool? Body { get; set; }
        public bool OEM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EQUIPMENT> EQUIPMENTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LU_MMTA> LU_MMTA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACK_COMPART_EXT> TRACK_COMPART_EXT { get; set; }
    }
}
