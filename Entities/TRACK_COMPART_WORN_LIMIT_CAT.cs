namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRACK_COMPART_WORN_LIMIT_CAT
    {
        [Key]
        public int track_compart_worn_limit_cat_auto { get; set; }
        [Index("IX_CATCompartMeasurementTool", 1, IsUnique = true)]
        public int compartid_auto { get; set; }
        [Index("IX_CATCompartMeasurementTool", 2, IsUnique = true)]
        public int track_tools_auto { get; set; }

        public decimal? hi_inflectionPoint { get; set; }

        public decimal? hi_slope1 { get; set; }

        public decimal? hi_intercept1 { get; set; }

        public decimal? hi_slope2 { get; set; }

        public decimal? hi_intercept2 { get; set; }

        public decimal? mi_inflectionPoint { get; set; }

        public decimal? mi_slope1 { get; set; }

        public decimal? mi_intercept1 { get; set; }

        public decimal? mi_slope2 { get; set; }

        public decimal? mi_intercept2 { get; set; }

        public decimal? adjust_base { get; set; }

        public int? slope { get; set; }
        [ForeignKey("MeasurePoint")]
        [Index("IX_CATCompartMeasurementTool", 3, IsUnique = true)]
        public int? MeasurePointId { get; set; }
        public virtual COMPART_MEASUREMENT_POINT MeasurePoint { get; set; }

        public virtual LU_COMPART LU_COMPART { get; set; }

        public virtual TRACK_TOOL TRACK_TOOL { get; set; }
    }
}
