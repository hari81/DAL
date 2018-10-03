namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EQUIPMENT_ACTIONS
    {
        [Key]
        public long equipment_action_auto { get; set; }

        public long equipment_recommendation_list_auto { get; set; }

        public long action_auto { get; set; }

        public string action_details { get; set; }

        public DateTime? action_date { get; set; }

        [Column(TypeName = "money")]
        public decimal? action_cost { get; set; }

        [StringLength(50)]
        public string work_order { get; set; }

        [StringLength(100)]
        public string warranty_claim_no { get; set; }

        [StringLength(50)]
        public string created_user { get; set; }

        public DateTime created_date { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(50)]
        public string modified_user { get; set; }

        [StringLength(50)]
        public string Downtime { get; set; }
    }
}
