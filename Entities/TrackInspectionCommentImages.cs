﻿namespace DAL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TrackInspectionCommentImages
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("TrackInspectionComments")]
        public int CommentID { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageComment { get; set; }

        public string ImageTitle { get; set; }

        public virtual TrackInspectionComments TrackInspectionComments { get; set; }
    }
}
