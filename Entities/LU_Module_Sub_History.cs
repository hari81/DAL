namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LU_Module_Sub_History
    {
        [Key]
        public long Module_sub_his_auto { get; set; }

        [StringLength(50)]
        public string Serialno { get; set; }

        public long? SMU { get; set; }

        public long? CMU { get; set; }

        public long? SMU_at_install { get; set; }

        public long? LTD_at_install { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? Compartid_auto { get; set; }

        public long? Equipmentid_auto { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }

        public long? Equnit_auto { get; set; }

        public long? crsf_auto { get; set; }

        public long? make_auto { get; set; }

        public long? model_auto { get; set; }

        public long? type_auto { get; set; }
    }
}
