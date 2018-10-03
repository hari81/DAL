namespace DAL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TrackInspectionRecords
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("TrackInspectionMeasurePoints")]
        public int TrackInspectionMeasurePointID { get; set; }

        public bool InboardOutboard { get; set; }

        public int ToolID { get; set; }

        public string Reading { get; set; }

        public virtual TrackInspectionMeasurePoints TrackInspectionMeasurePoints { get; set; }
    }
}
