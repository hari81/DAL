using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("MININGSHOVEL_REPORT_IMAGE_CATEGORIES")]
    public class MININGSHOVEL_REPORT_IMAGE_CATEGORIES
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("InspectionComparttypeImages")]
        public int? Comparttype_Mandatory_Image { get; set; }

        [ForeignKey("InspectionComparttypeRecordImages")]
        public int? Comparttype_Additional_Image { get; set; }

        [ForeignKey("InspectionMandatoryImages")]
        public int? Inspection_Mandatory_Image { get; set; }

        [ForeignKey("MeasurePointRecordImages")]
        public int? Measurement_Point_Image { get; set; }

        public virtual INSPECTION_COMPARTTYPE_IMAGES InspectionComparttypeImages { get; set; }

        public virtual INSPECTION_COMPARTTYPE_RECORD_IMAGES InspectionComparttypeRecordImages { get; set; }

        public virtual INSPECTION_MANDATORY_IMAGES InspectionMandatoryImages { get; set; }

        public virtual MEASUREPOINT_RECORD_IMAGES MeasurePointRecordImages { get; set; }
    }
}