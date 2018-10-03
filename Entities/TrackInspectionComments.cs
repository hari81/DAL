namespace DAL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TrackInspectionComments
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("TRACK_INSPECTION")]
        public int InspectionID { get; set; }

        [ForeignKey("TrackInspectionCommentTypes")]
        public int CommentTypeID { get; set; }

        public string Comment { get; set; }

        public virtual TRACK_INSPECTION TRACK_INSPECTION { get; set; }

        public virtual TrackInspectionCommentTypes TrackInspectionCommentTypes { get; set; }
    }
}
