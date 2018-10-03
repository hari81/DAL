namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MODULE_REGISTRATION_EQUIPMENT
    {
        [Key]
        public long module_reg_auto { get; set; }

        public long equipmentid_auto { get; set; }

        public bool? pm_servicing { get; set; }

        public DateTime? pm_servicing_last_reg_date { get; set; }

        public bool? backlog { get; set; }

        public DateTime? backlog_last_reg_date { get; set; }

        public bool? scheduler { get; set; }

        public DateTime? scheduler_last_reg_date { get; set; }

        public bool? trakalerts { get; set; }

        public DateTime? trakalerts_last_reg_date { get; set; }

        public bool? component_manager { get; set; }

        public DateTime? component_manager_last_reg_date { get; set; }

        public bool? tyre { get; set; }

        public DateTime? tyre_last_reg_date { get; set; }

        public bool? general_inspection { get; set; }

        public DateTime? general_inspection_last_reg_date { get; set; }

        public bool? get { get; set; }

        public DateTime? get_last_reg_date { get; set; }

        public bool? undercarriage { get; set; }

        public DateTime? undercarriage_last_reg_date { get; set; }

        public bool? body_bowl { get; set; }

        public DateTime? body_bowl_last_reg_date { get; set; }

        [StringLength(50)]
        public string modified_user { get; set; }

        public bool? rail { get; set; }

        public DateTime? rail_last_reg_date { get; set; }

        public bool? dashboard { get; set; }

        public DateTime? dashboard_last_reg_date { get; set; }
    }
}
