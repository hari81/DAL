using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("MININGSHOVEL_REPORT_IMAGE_RESIZED")]
    public class MININGSHOVEL_REPORT_IMAGE_RESIZED
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MiningShovelReport")]
        public int ReportId { get; set; }

        [ForeignKey("ImageCategories")]
        public int? ReportImageId { get; set; }

        [ForeignKey("RecommendationImages")]
        public int? RecommendationImageId { get; set; }

        public virtual MININGSHOVEL_REPORT MiningShovelReport { get; set; }

        public virtual MININGSHOVEL_REPORT_IMAGE_CATEGORIES ImageCategories { get; set; }

        public virtual MININGSHOVEL_REPORT_RECOMMENDATION_IMAGES RecommendationImages { get; set; }
    }
}