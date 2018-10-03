using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace DAL
{
    public class WSREComponentRecord
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("WSRE")]
        public int WSREId { get; set; }
        [ForeignKey("Component")]
        public long ComponentId { get; set; }
        public decimal Measurement { get; set; }
        public decimal WornPercentage { get; set; }
        public int Cmu { get; set; }
        public int RemainingLife { get; set; }
        [ForeignKey("MeasurementTool")]
        public int MeasurementToolId { get; set; }
        public string Comment { get; set; }
        public virtual WSRE WSRE { get; set; }
        public virtual GENERAL_EQ_UNIT Component { get; set; }
        public virtual TRACK_TOOL MeasurementTool { get; set; }
        public virtual ICollection<WSREComponentImage> Photos { get; set; }
        public virtual ICollection<WSREComponentRecordRecommendation> Recommendations { get; set; }
    }
}