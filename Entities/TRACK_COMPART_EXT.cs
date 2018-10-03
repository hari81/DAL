namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRACK_COMPART_EXT
    {
        [Key]
        public long track_compart_ext_auto { get; set; }
        [Index("IX_CompartMeasurementToolExt", 1, IsUnique = true)]
        public int compartid_auto { get; set; }
        [ForeignKey("CompartMeasurePoint")]
        [Index("IX_CompartMeasurementToolExt", 2, IsUnique = true)]
        public int? CompartMeasurePointId { get; set; }
        public int? make_auto { get; set; }
        [Index("IX_CompartMeasurementToolExt", 3, IsUnique = true)]
        public int? tools_auto { get; set; }

        public int? budget_life { get; set; }

        public int? track_compart_worn_calc_method_auto { get; set; }

        public virtual LU_COMPART LU_COMPART { get; set; }

        public virtual MAKE MAKE { get; set; }

        public virtual TRACK_COMPART_WORN_CALC_METHOD TRACK_COMPART_WORN_CALC_METHOD { get; set; }

        public virtual TRACK_TOOL TRACK_TOOL { get; set; }
        public virtual COMPART_MEASUREMENT_POINT CompartMeasurePoint { get; set; }
    }
}
