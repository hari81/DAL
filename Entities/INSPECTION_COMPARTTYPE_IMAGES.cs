using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class INSPECTION_COMPARTTYPE_IMAGES
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CompartTypeMandatoryImage")]
        public int CompartTypeMandatoryImageId { get; set; }
        [ForeignKey("Inspection")]
        public int InspectionId { get; set; }
        public byte[] Data { get; set; }
        [StringLength(250)]
        public string Title { get; set; }
        public string Comment { get; set; }
        public int Side { get; set; }
        public virtual CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE CompartTypeMandatoryImage { get; set; }
        public virtual TRACK_INSPECTION Inspection { get; set; }
        public virtual ICollection<REPORT_HIDDEN_COMPARTTYPE_MANDATORY_IMAGE> HiddenInReports { get; set; }
    }
}