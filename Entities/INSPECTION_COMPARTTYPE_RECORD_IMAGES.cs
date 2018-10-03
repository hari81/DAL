using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL
{
    public class INSPECTION_COMPARTTYPE_RECORD_IMAGES
    {
        [Key]
        public int Id { get; set; }
        public int RecordId { get; set; }
        public byte[] Data { get; set; }
        [StringLength(250)]
        public string Title { get; set; }
        public string Comment { get; set; }
        public virtual INSPECTION_COMPARTTYPE_RECORD InspectionCompartTypeRecord { get; set; }
        public ICollection<REPORT_HIDDEN_ADDITIONAL_RECORD_IMAGE> HiddenInReports { get; set; }
    }
}