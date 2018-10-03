namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRACK_ACTION_COMPONENT
    {
        [Key]
        [Column(Order = 0)]
        public int action_auto { get; set; }

        public int? equipmentid_auto { get; set; }

        public int? compartid_auto { get; set; }

        public int? eq_smu { get; set; }

        public int? inspection_auto { get; set; }

        public int? track_unit_auto { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool is_done { get; set; }

        public int? action_type_auto { get; set; }

        public int? compartid_auto_new { get; set; }

        public int? smu { get; set; }

        public int? budget_life { get; set; }

        [StringLength(4000)]
        public string comment { get; set; }

        public DateTime? action_date { get; set; }

        [StringLength(50)]
        public string action_user { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(50)]
        public string created_user { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(50)]
        public string modified_user { get; set; }

        public int? cmu { get; set; }

        [Column(TypeName = "money")]
        public decimal? cost { get; set; }

        public int? side { get; set; }
    }
}
