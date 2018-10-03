namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRACK_INSPECTION_DETAIL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRACK_INSPECTION_DETAIL()
        {
            Images = new HashSet<TRACK_INSPECTION_IMAGES>();
        }

        [Key]
        public int inspection_detail_auto { get; set; }

        public int inspection_auto { get; set; }

        public long track_unit_auto { get; set; }

        public int? tool_auto { get; set; }

        public decimal reading { get; set; }

        public decimal worn_percentage { get; set; }

        [StringLength(1)]
        public string eval_code { get; set; }

        public int? hours_on_surface { get; set; }

        public int? projected_hours { get; set; }

        public int? ext_projected_hours { get; set; }

        public int? remaining_hours { get; set; }

        public int? ext_remaining_hours { get; set; }

        [StringLength(400)]
        public string comments { get; set; }

        public decimal? worn_percentage_120 { get; set; }

        public long? track_unit_history_auto { get; set; }

        public long? UCSystemId { get; set; }

        public bool ReadingEnteredByEval { get; set; }
        public int Side { get; set; }

        public virtual GENERAL_EQ_UNIT GENERAL_EQ_UNIT { get; set; }

        public virtual InspectionDetails_Side SIDE { get; set; }

        public virtual LU_Module_Sub LU_Module_Sub { get; set; }

        public virtual TRACK_INSPECTION TRACK_INSPECTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACK_INSPECTION_IMAGES> Images { get; set; }

        public virtual TRACK_TOOL TRACK_TOOL { get; set; }
        public virtual ICollection<MEASUREMENT_POINT_RECORD> MeaseurementPointRecors { get; set; }
    }
}
