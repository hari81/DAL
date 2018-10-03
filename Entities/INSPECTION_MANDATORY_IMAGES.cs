using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("INSPECTION_MANDATORY_IMAGES")]
    public class INSPECTION_MANDATORY_IMAGES
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CustomerModelMandatoryImage")]
        public int CustomerModelMandatoryImageId { get; set; }
        [ForeignKey("Inspection")]
        public int InspectionId { get; set; }
        public byte[] Data { get; set; }
        [StringLength(250)]
        public string Title { get; set; }
        public string Comment { get; set; }
        public int Side { get; set; }
        public virtual CUSTOMER_MODEL_MANDATORY_IMAGE CustomerModelMandatoryImage { get; set; }
        public virtual TRACK_INSPECTION Inspection { get; set; }
        public virtual ICollection<REPORT_HIDDEN_INSPECTION_MANDATORY_IMAGES> HiddenInReports { get; set; }
    }
}