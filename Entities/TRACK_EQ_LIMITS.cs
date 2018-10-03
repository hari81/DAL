namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRACK_EQ_LIMITS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long equipmentid_auto { get; set; }

        public int? smcs_code { get; set; }

        public int? a_limit { get; set; }

        public int? b_limit { get; set; }

        public int? c_limit { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(30)]
        public string modified_user { get; set; }

        public int? compartid_auto { get; set; }
    }
}
