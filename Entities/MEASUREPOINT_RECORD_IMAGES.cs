using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("MEASUREPOINT_RECORD_IMAGES")]
    public class MEASUREPOINT_RECORD_IMAGES
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MeasurePointRecord")]
        public int MeasurePointRecordId { get; set; }
        public byte[] Data { get; set; }
        [StringLength(250)]
        public string Title { get; set; }
        public string Comment { get; set; }
        public virtual MEASUREMENT_POINT_RECORD MeasurePointRecord { get; set; }
        public virtual ICollection<REPORT_HIDDEN_MEASUREPOINT_RECORD_IMAGES> HiddenInReports { get; set; }

    }
}