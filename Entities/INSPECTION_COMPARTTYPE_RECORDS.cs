using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("INSPECTION_COMPARTTYPE_RECORD")]
    public class INSPECTION_COMPARTTYPE_RECORD
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CompartTypeAdditional")]
        public int CompartTypeAdditionalId { get; set; }
        public decimal Reading { get; set; }
        public string ObservationNote { get; set; }
        [ForeignKey("Tool")]
        public int ToolId { get; set; }
        public int MeasureNumber { get; set; }
        [ForeignKey("Inspection")]
        public int InspectionId { get; set; }
        public int Side { get; set; }
        public virtual TRACK_TOOL Tool { get; set; }
        public virtual TRACK_INSPECTION Inspection { get; set; }
        public virtual CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL CompartTypeAdditional { get; set; }
        public ICollection<INSPECTION_COMPARTTYPE_RECORD_IMAGES> RecordImages { get; set; }
        //public ICollection<REPORT_HIDDEN_ADDITIONAL_RECORD> HiddenInReports { get; set; }
    }
}