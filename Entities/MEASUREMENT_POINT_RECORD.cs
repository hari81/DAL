using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("MEASUREMENT_POINT_RECORD")]
    public class MEASUREMENT_POINT_RECORD
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("InspectionDetail")]
        public int InspectionDetailId { get; set; }
        [ForeignKey("CompartMeasurePoint")]
        public int CompartMeasurePointId { get; set; }
        public int InboardOutborad { get; set; }
        [ForeignKey("Tool")]
        public int ToolId { get; set; }
        public decimal Reading { get; set; }
        public decimal Worn { get; set; }
        public string EvalCode { get; set; }
        public int MeasureNumber { get; set; }
        public string Notes { get; set; }
        public virtual TRACK_INSPECTION_DETAIL InspectionDetail { get; set; }
        public virtual COMPART_MEASUREMENT_POINT CompartMeasurePoint { get; set; }
        public virtual TRACK_TOOL Tool { get; set; }
        //public virtual ICollection<REPORT_HIDDEN_MEASUREMENT_POINT_RECORD> HiddenInReports { get; set; }
        public virtual ICollection<MEASUREPOINT_RECORD_IMAGES> Photos { get; set; }
    }
}