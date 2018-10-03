namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRACK_COMPART_WORN_LIMIT_LIEBHERR
    {
        [Key]
        public int track_compart_worn_limit_liebherr_auto { get; set; }
        [Index("IX_LIEBHERRCompartMeasurementTool", 1, IsUnique = true)]
        public int compartid_auto { get; set; }
        [Index("IX_LIEBHERRCompartMeasurementTool", 2, IsUnique = true)]
        public int track_tools_auto { get; set; }

        public decimal? impact_slope { get; set; }

        public decimal? normal_slope { get; set; }

        public decimal? impact_intercept { get; set; }

        public decimal? normal_intercept { get; set; }
        [ForeignKey("MeasurePoint")]
        [Index("IX_LIEBHERRCompartMeasurementTool", 3, IsUnique = true)]
        public int? MeasurePointId { get; set; }
        public virtual COMPART_MEASUREMENT_POINT MeasurePoint { get; set; }
    }
}
