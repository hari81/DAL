using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DAL
{
    public class REPORT_HIDDEN_INSPECTION_MANDATORY_IMAGES
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("InspectionMandatoryImage")]
        public int InspectionMandatoryImageId { get; set; }
        [ForeignKey("Report")]
        public int ReportId { get; set; }
        public virtual MININGSHOVEL_REPORT Report { get; set; }
        public virtual INSPECTION_MANDATORY_IMAGES InspectionMandatoryImage { get; set; }
    }
}




