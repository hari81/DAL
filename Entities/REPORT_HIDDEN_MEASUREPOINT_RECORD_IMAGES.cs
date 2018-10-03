using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DAL
{
    public class REPORT_HIDDEN_MEASUREPOINT_RECORD_IMAGES
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MeasurePointRecordImage")]
        public int MeasurePointRecordImageId { get; set; }
        [ForeignKey("Report")]
        public int ReportId { get; set; }
        public virtual MININGSHOVEL_REPORT Report { get; set; }
        public virtual MEASUREPOINT_RECORD_IMAGES MeasurePointRecordImage { get; set; }
    }
}