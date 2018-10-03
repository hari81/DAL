using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DAL
{
    public class REPORT_HIDDEN_COMPARTTYPE_MANDATORY_IMAGE
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("InspectionCompartTypeImage")]
        public int InspectionCompartTypeImageId { get; set; }
        [ForeignKey("Report")]
        public int ReportId { get; set; }
        public virtual MININGSHOVEL_REPORT Report { get; set; }
        public virtual INSPECTION_COMPARTTYPE_IMAGES InspectionCompartTypeImage { get; set; }
    }
}