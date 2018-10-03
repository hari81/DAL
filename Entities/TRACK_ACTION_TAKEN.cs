namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRACK_ACTION_TAKEN
    {
        [Key]
        public int action_taken_auto { get; set; }

        public int action_auto { get; set; }

        public DateTime action_taken_on { get; set; }

        [Required]
        [StringLength(50)]
        public string action_taken_by { get; set; }

        [StringLength(1000)]
        public string action_taken_desc { get; set; }

        [Column(TypeName = "money")]
        public decimal? action_cost { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(50)]
        public string created_user { get; set; }

        public virtual TRACK_ACTION TRACK_ACTION { get; set; }
    }
}
