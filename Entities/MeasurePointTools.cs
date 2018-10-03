namespace DAL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class MeasurePointTools
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("MeasurePointTypes")]
        public int MeasurePointTypeID { get; set; }

        [ForeignKey("TrackTool")]
        public int ToolID { get; set; }

        public virtual MeasurePointTypes MeasurePointTypes { get; set; }

        public virtual TRACK_TOOL TrackTool { get; set; }
    }
}
