using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("MEASUREMENT_POSSIBLE_TOOLS")]
    public class MEASUREMENT_POSSIBLE_TOOLS
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MeasurementPoint")]
        [Index("IX_MeasurePointTool", 1, IsUnique = true)]
        public int MeasurePointId { get; set; }
        [ForeignKey("Tool")]
        [Index("IX_MeasurePointTool", 2, IsUnique = true)]
        public int ToolId { get; set; }
        public byte[] HowToUseImage { get; set; }
        public string HowToUseText { get; set; }
        public virtual TRACK_TOOL Tool { get; set; }
        public virtual COMPART_MEASUREMENT_POINT MeasurementPoint { get; set; }
    }
}