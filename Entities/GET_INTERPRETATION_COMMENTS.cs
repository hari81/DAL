namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_INTERPRETATION_COMMENTS
    {
        [Key]
        public long comment_auto { get; set; }

        public long user_auto { get; set; }

        [Required]
        [StringLength(128)]
        public string comment { get; set; }

        public DateTime comment_date { get; set; }

        public int inspection_auto { get; set; }
    }
}
