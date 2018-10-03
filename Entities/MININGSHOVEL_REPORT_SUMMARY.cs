using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("MININGSHOVEL_REPORT_SUMMARY")]
    public class MININGSHOVEL_REPORT_SUMMARY
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MiningShovelReport")]
        public int MiningShovelReportId { get; set; }

        public string SummaryText { get; set; }

        public string RecommendationOverview { get; set; }

        public virtual MININGSHOVEL_REPORT MiningShovelReport { get; set; }
    }
}