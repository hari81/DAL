namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GENERAL_EQ_UNIT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GENERAL_EQ_UNIT()
        {
            COMP_Inventory_Inspec_Details = new HashSet<COMP_Inventory_Inspec_Details>();
            Life = new HashSet<ComponentLife>();
            TRACK_INSPECTION_DETAIL = new HashSet<TRACK_INSPECTION_DETAIL>();
        }

        [Key]
        public long equnit_auto { get; set; }
        [ForeignKey("Equipment")]
        public long? equipmentid_auto { get; set; }

        public int compartid_auto { get; set; }

        [StringLength(50)]
        public string compartsn { get; set; }

        public DateTime? date_installed { get; set; }

        public long? smu_at_install { get; set; }

        public long? eq_smu_at_install { get; set; }

        public short max_rebuild { get; set; }

        public bool insp_item { get; set; }

        public short? insp_interval { get; set; }

        public short? insp_uom { get; set; }

        [StringLength(50)]
        public string created_user { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(50)]
        public string modified_user { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(1000)]
        public string compart_note { get; set; }

        public byte comp_status { get; set; }

        public Guid comp_uniq_id { get; set; }

        [StringLength(50)]
        public string compart_descr { get; set; }

        public int? make_auto { get; set; }

        public int? model_auto { get; set; }

        public short? rebuild_no { get; set; }

        public bool? rebuild_cost_builder { get; set; }

        [Column(TypeName = "money")]
        public decimal? rebuild_cost_before_failure { get; set; }

        [Column(TypeName = "money")]
        public decimal? rebuild_cost_after_failure { get; set; }

        public decimal? rebuild_cost_probability_factor { get; set; }

        public decimal? rebuild_cost_minor_repair_provision { get; set; }

        public decimal? rebuild_cost_unscheduled_provision { get; set; }

        [Column(TypeName = "money")]
        public decimal? rebuild_cost_calculated { get; set; }

        public byte? pos { get; set; }

        public byte? side { get; set; }

        public bool? variable_comp { get; set; }

        public bool? create_forecast { get; set; }

        public double? track_0_worn { get; set; }

        public double? track_100_worn { get; set; }

        public double? track_120_worn { get; set; }

        public long? eq_ltd_at_install { get; set; }

        public bool? chkOil { get; set; }

        public bool? chkInspectionTracking { get; set; }

        public bool? chkReplace { get; set; }

        public bool? chkRebuild { get; set; }

        public bool? chkFinancialTracking { get; set; }

        public bool? chkWarranty { get; set; }

        [Column(TypeName = "money")]
        public decimal? rebuild_cost_calculated1 { get; set; }

        [Column(TypeName = "money")]
        public decimal? rebuild_cost_calculated2 { get; set; }

        [Column(TypeName = "money")]
        public decimal? replace_cost_calculated { get; set; }

        public long? positionid_auto { get; set; }

        public bool? chkActivateForecast { get; set; }

        public int? parent_equnit_auto { get; set; }

        public decimal? component_current_value { get; set; }

        public int? track_budget_life { get; set; }

        public long? cmu { get; set; }

        public decimal? cost { get; set; }

        [ForeignKey("SHOE_SIZE")]
        public int? ShoeSizeId { get; set; }
        public virtual SHOE_SIZE SHOE_SIZE { get; set; }

        public int? ShoeGrouserNo { get; set; }

        [ForeignKey("UCSystem")]
        public long? module_ucsub_auto { get; set; }

        public virtual LU_Module_Sub UCSystem { get; set; }

        public long? system_LTD_at_install { get; set; }

        public virtual MAKE Make { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMP_Inventory_Inspec_Details> COMP_Inventory_Inspec_Details { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComponentLife> Life { get; set; }

        public virtual LU_COMPART LU_COMPART { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACK_INSPECTION_DETAIL> TRACK_INSPECTION_DETAIL { get; set; }
        public virtual EQUIPMENT Equipment { get; set; }
    }
}
