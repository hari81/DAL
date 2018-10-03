namespace DAL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ModelCommentMap
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("TrackInspectionCommentTypes")]
        public int CommentTypeID { get; set; }

        [ForeignKey("Model")]
        public int ModelID { get; set; }

        public virtual TrackInspectionCommentTypes TrackInspectionCommentTypes { get; set; }

        public virtual MODEL Model { get; set; }
    }
}
