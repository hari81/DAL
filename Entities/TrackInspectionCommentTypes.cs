namespace DAL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TrackInspectionCommentTypes
    {
        [Key]
        public int ID { get; set; }

        public string CommentDescription { get; set; }
    }
}
