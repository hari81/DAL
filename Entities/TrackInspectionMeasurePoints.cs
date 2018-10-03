namespace DAL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TrackInspectionMeasurePoints
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("TRACK_INSPECTION_DETAIL")]
        public int InspectionDetailID { get; set; }

        [ForeignKey("MeasurePointTypes")]
        public int MeasurePointID { get; set; }

        public virtual TRACK_INSPECTION_DETAIL TRACK_INSPECTION_DETAIL { get; set; }

        public virtual MeasurePointTypes MeasurePointTypes { get; set; }
    }
}
