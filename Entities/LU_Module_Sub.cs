namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LU_Module_Sub
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LU_Module_Sub()
        {
            TRACK_INSPECTION_DETAIL = new HashSet<TRACK_INSPECTION_DETAIL>();
            Life = new HashSet<SystemLife>();
        }

        [Key]
        public long Module_sub_auto { get; set; }

        [Required]
        [StringLength(50)]
        public string Serialno { get; set; }

        public int? Module_progid { get; set; }

        public long? SMU { get; set; }

        public long? CMU { get; set; }

        public long? SMU_at_install { get; set; }

        public long? LTD_at_install { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? Status { get; set; }

        public DateTime? StatusDate { get; set; }

        public long? LTD { get; set; }

        public long? equipmentid_auto { get; set; }

        [ForeignKey("Jobsite")]
        public long? crsf_auto { get; set; }

        [ForeignKey("Make")]
        public int? make_auto { get; set; }

        [ForeignKey("Model")]
        public int? model_auto { get; set; }

        public long? type_auto { get; set; }

        public DateTime? modifiedDate { get; set; }

        public int? modifiedBy { get; set; }

        [StringLength(100)]
        public string reason { get; set; }

        [StringLength(200)]
        public string notes { get; set; }

        public long? system_LTD_on_removal { get; set; }

        public long? equipment_LTD_at_attachment { get; set; }

        public int? installation_status { get; set; }

        public int systemTypeEnumIndex { get; set; }

        public virtual EQUIPMENT EQUIPMENT { get; set; }
        public virtual CRSF Jobsite { get; set; }
        public virtual MAKE Make { get; set; }
        public virtual MODEL Model { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACK_INSPECTION_DETAIL> TRACK_INSPECTION_DETAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SystemLife> Life { get; set; }
    }
}
