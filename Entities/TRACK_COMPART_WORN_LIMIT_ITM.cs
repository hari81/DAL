namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRACK_COMPART_WORN_LIMIT_ITM
    {
        [Key]
        public int track_compart_worn_limit_itm_auto { get; set; }
        [Index("IX_ITMCompartMeasurementTool", 1, IsUnique = true)]
        public int compartid_auto { get; set; }
        [Index("IX_ITMCompartMeasurementTool", 2, IsUnique = true)]
        public int track_tools_auto { get; set; }

        public decimal? start_depth_new { get; set; }

        public decimal? wear_depth_10_percent { get; set; }

        public decimal? wear_depth_20_percent { get; set; }

        public decimal? wear_depth_30_percent { get; set; }

        public decimal? wear_depth_40_percent { get; set; }

        public decimal? wear_depth_50_percent { get; set; }

        public decimal? wear_depth_60_percent { get; set; }

        public decimal? wear_depth_70_percent { get; set; }

        public decimal? wear_depth_80_percent { get; set; }

        public decimal? wear_depth_90_percent { get; set; }

        public decimal? wear_depth_100_percent { get; set; }

        public decimal? wear_depth_110_percent { get; set; }

        public decimal? wear_depth_120_percent { get; set; }
        [ForeignKey("MeasurePoint")]
        [Index("IX_ITMCompartMeasurementTool", 3, IsUnique = true)]
        public int? MeasurePointId { get; set; }
        public virtual COMPART_MEASUREMENT_POINT MeasurePoint { get; set; }

        public virtual LU_COMPART LU_COMPART { get; set; }

        public virtual TRACK_TOOL TRACK_TOOL { get; set; }
    }
}
