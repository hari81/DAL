using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("MININGSHOVEL_REPORT")]
    public class MININGSHOVEL_REPORT
    {
        [Key]
        public int Id { get; set; }
        public int InspectionId { get; set; }
        public long CreatedByUserId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public virtual ICollection<REPORT_HIDDEN_ADDITIONAL_RECORD> HiddenAdditionalRecords { get; set; }
        public virtual ICollection<REPORT_HIDDEN_ADDITIONAL_RECORD_IMAGE> HiddenAdditionalRecordImages { get; set; }
        public virtual ICollection<REPORT_HIDDEN_COMPARTTYPE_MANDATORY_IMAGE> HiddenCompartTypeMandatoryImages { get; set; }
        public virtual ICollection<REPORT_HIDDEN_MEASUREMENT_POINT_RECORD> HiddenMeasurementPointRecords { get; set; }
        public virtual ICollection<REPORT_HIDDEN_MEASUREPOINT_RECORD_IMAGES> HiddenMeasurementPointRecordImages { get; set; }
        public virtual ICollection<REPORT_HIDDEN_INSPECTION_MANDATORY_IMAGES> HiddenInspectionMandatoryImages { get; set; }
    }
}