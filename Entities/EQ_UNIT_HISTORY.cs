namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EQ_UNIT_HISTORY
    {
        [Key]
        public long equnit_history_auto { get; set; }

        public long module_equnit_auto { get; set; }

        public short moduleid { get; set; }

        public int? compartid_auto { get; set; }

        public long? equipmentid_auto { get; set; }

        public short? component_management_type_auto { get; set; }

        public DateTime? management_date { get; set; }

        public long? management_eq_smu { get; set; }

        public short? rebuild_no { get; set; }

        public DateTime? install_date { get; set; }

        public long? eq_smu_at_install { get; set; }

        public long? c_actual_auto { get; set; }

        [StringLength(500)]
        public string comment { get; set; }

        public int? cause_auto { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(50)]
        public string modified_user { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(50)]
        public string created_user { get; set; }

        public long? management_comp_smu { get; set; }

        public long? management_eq_LTD { get; set; }

        public int? component_status_id { get; set; }

        public int? documents_and_images { get; set; }
    }
}
