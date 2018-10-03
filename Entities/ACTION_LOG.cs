namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ACTION_LOG
    {
        [Key]
        public long action_auto { get; set; }

        public long equipmentid_auto { get; set; }

        [Required]
        [StringLength(500)]
        public string action_desc { get; set; }

        public DateTime action_date { get; set; }

        public bool? problemsolved { get; set; }

        [Column(TypeName = "money")]
        public decimal? actioncost { get; set; }

        public bool? warrantyclaim { get; set; }

        public short? status { get; set; }

        [StringLength(500)]
        public string manuf_comments { get; set; }

        [Column(TypeName = "money")]
        public decimal? reimburse_amt { get; set; }

        [StringLength(20)]
        public string workorderno { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(50)]
        public string created_user { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(50)]
        public string modified_user { get; set; }

        public virtual EQUIPMENT EQUIPMENT { get; set; }
    }
}
