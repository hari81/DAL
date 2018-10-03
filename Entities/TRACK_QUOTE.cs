namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRACK_QUOTE
    {
        [Key]
        public int quote_auto { get; set; }

        [StringLength(50)]
        public string quote_name { get; set; }

        [ForeignKey("Inspection")]
        public int inspection_auto { get; set; }

        public int status_auto { get; set; }

        public DateTime? due_date { get; set; }

        [StringLength(1000)]
        public string notes { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(50)]
        public string created_user { get; set; }

        [StringLength(50)]
        public string modified_user { get; set; }

        public DateTime? modified_date { get; set; }
        public virtual TRACK_QUOTE_STATUS TRACK_QUOTE_STATUS { get; set; }
        public virtual TRACK_INSPECTION Inspection { get; set; }
        public virtual ICollection<TRACK_QUOTE_DETAIL> Recommendations { get; set; }
    }
}
