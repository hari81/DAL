using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class REPORT_HIDDEN_ADDITIONAL_RECORD
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CompartType")]
        public int CompartTypeId { get; set; }
        [ForeignKey("Report")]
        public int ReportId { get; set; }
        public virtual MININGSHOVEL_REPORT Report { get; set; }
        public virtual LU_COMPART_TYPE CompartType { get; set; }
    }
}