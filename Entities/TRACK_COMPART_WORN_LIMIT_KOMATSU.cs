namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRACK_COMPART_WORN_LIMIT_KOMATSU
    {
        [Key]
        public int track_compart_worn_limit_komatsu_auto { get; set; }
        [Index("IX_KOMATSUCompartMeasurementTool", 1, IsUnique = true)]
        public int compartid_auto { get; set; }
        [Index("IX_KOMATSUCompartMeasurementTool", 2, IsUnique = true)]
        public int track_tools_auto { get; set; }

        public decimal? slope_impact { get; set; }

        public decimal? slope_normal { get; set; }

        public decimal? impact_slope { get; set; }

        public decimal? normal_slope { get; set; }

        public decimal? impact_intercept { get; set; }

        public decimal? normal_intercept { get; set; }

        public decimal? impact_secondorder { get; set; }

        public decimal? normal_secondorder { get; set; }
        [ForeignKey("MeasurePoint")]
        [Index("IX_KOMATSUCompartMeasurementTool", 3, IsUnique = true)]
        public int? MeasurePointId { get; set; }
        public virtual COMPART_MEASUREMENT_POINT MeasurePoint { get; set; }
    }
}
