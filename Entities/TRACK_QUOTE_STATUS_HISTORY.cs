namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRACK_QUOTE_STATUS_HISTORY
    {
        [Key]
        [Column(Order = 0)]
        public int quote_status_hist_auto { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int quote_auto { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int status_auto { get; set; }

        [StringLength(1000)]
        public string comment { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string created_user { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime created_date { get; set; }

        public virtual TRACK_QUOTE_STATUS TRACK_QUOTE_STATUS { get; set; }
    }
}
