using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("MININGSHOVEL_REPORT_RECOMMENDATIONS")]
    public class MININGSHOVEL_REPORT_RECOMMENDATIONS
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MiningShovelReport")]
        public int MiningShovelReportId { get; set; }

        public string RecommendationTitle { get; set; }

        public string RecommendationText { get; set; }

        public virtual MININGSHOVEL_REPORT MiningShovelReport { get; set; }
    }
}