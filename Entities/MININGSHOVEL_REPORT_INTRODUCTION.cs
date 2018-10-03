using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("MININGSHOVEL_REPORT_INTRODUCTION")]
    public class MININGSHOVEL_REPORT_INTRODUCTION
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MiningShovelReport")]
        public int MiningShovelReportId { get; set; }

        [ForeignKey("InspectionMandatoryImages")]
        public int? CoverImage { get; set; }

        public string IntroText1 { get; set; }

        public string IntroText2 { get; set; }

        public virtual MININGSHOVEL_REPORT MiningShovelReport { get; set; }

        public virtual INSPECTION_MANDATORY_IMAGES InspectionMandatoryImages { get; set; }
    }
}