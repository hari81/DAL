using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("MININGSHOVEL_REPORT_OVERALL_COMMENTS")]
    public class MININGSHOVEL_REPORT_OVERALL_COMMENTS
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MiningShovelReport")]
        public int MiningShovelReportId { get; set; }

        [ForeignKey("CompartType")]
        public int CompartTypeId { get; set; }

        public string Comments { get; set; }

        public virtual MININGSHOVEL_REPORT MiningShovelReport { get; set; }

        public virtual LU_COMPART_TYPE CompartType { get; set; }
    }
}