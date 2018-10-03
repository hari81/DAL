namespace DAL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TrackInspectionImagesMain
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("TRACK_INSPECTION")]
        public int InspectionID { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageComment { get; set; }

        public string ImageTitle { get; set; }

        [ForeignKey("TrackInspectionImageType")]
        public int ImageType { get; set; }

        public virtual TRACK_INSPECTION TRACK_INSPECTION{ get; set; }
        public virtual TrackInspectionImageType TrackInspectionImageType { get; set; }


    }
}
