using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("MININGSHOVEL_REPORT_RECOMMENDATION_IMAGES")]
    public class MININGSHOVEL_REPORT_RECOMMENDATION_IMAGES
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MiningShovelReportRecommendation")]
        public int RecommendationId { get; set; }

        [ForeignKey("ImageCategories")]
        public int ImageCategoryId { get; set; }

        public virtual MININGSHOVEL_REPORT_RECOMMENDATIONS MiningShovelReportRecommendation { get; set; }

        public virtual MININGSHOVEL_REPORT_IMAGE_CATEGORIES ImageCategories { get; set; }
    }
}