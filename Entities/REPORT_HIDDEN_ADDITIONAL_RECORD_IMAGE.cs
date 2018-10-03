using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class REPORT_HIDDEN_ADDITIONAL_RECORD_IMAGE
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CompartTypeRecordImage")]
        public int CompartTypeRecordImageId { get; set; }
        [ForeignKey("Report")]
        public int ReportId { get; set; }
        public virtual MININGSHOVEL_REPORT Report { get; set; }
        public virtual INSPECTION_COMPARTTYPE_RECORD_IMAGES CompartTypeRecordImage { get; set; }
    }
}


