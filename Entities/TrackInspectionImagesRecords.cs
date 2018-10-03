namespace DAL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TrackInspectionImagesRecords
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("TrackInspectionRecords")]
        public int RecordID { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageComment { get; set; }

        public string ImageTitle { get; set; }

        public virtual TrackInspectionRecords TrackInspectionRecords { get; set; }
    }
}
