namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mbl_NewEquipment
    {
        [Key]
        [Column(Order = 0)]
        public long equipmentid_auto { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string serialno { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string unitno { get; set; }

        [StringLength(50)]
        public string description { get; set; }

        public long? derived_from { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int mmtaid_auto { get; set; }

        public byte? market_auto { get; set; }

        public byte? measure_unit { get; set; }

        public int? op_hrs_per_day { get; set; }

        public byte? op_dist_uom { get; set; }

        [StringLength(50)]
        public string op_range { get; set; }

        public DateTime? start_date { get; set; }

        public DateTime? end_date { get; set; }

        public long? smu_at_start { get; set; }

        public long? distance_at_start { get; set; }

        public long? smu_at_end { get; set; }

        public long? distance_at_end { get; set; }

        public long? currentsmu { get; set; }

        public long? currentdistance { get; set; }

        public DateTime? last_reading_date { get; set; }

        [StringLength(5000)]
        public string notes { get; set; }

        public long? LTD_at_start { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long crsf_auto { get; set; }

        [StringLength(50)]
        public string location { get; set; }

        public int? purchase_op_hrs { get; set; }

        public int? purchase_op_dist { get; set; }

        public DateTime? purchase_date { get; set; }

        [Column(TypeName = "money")]
        public decimal? purchase_cost { get; set; }

        public int? deprate { get; set; }

        [StringLength(10)]
        public string depmethod { get; set; }

        [StringLength(10)]
        public string uccode { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(50)]
        public string created_user { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(50)]
        public string modified_user { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int equip_status { get; set; }

        [StringLength(50)]
        public string regno { get; set; }

        public short? errorcode { get; set; }

        public long? fleet_auto { get; set; }

        public bool? update_accept { get; set; }

        [StringLength(10)]
        public string DBS_serialno { get; set; }

        public bool? da_inclusion { get; set; }

        public short? status_auto { get; set; }

        public DateTime? first_reg_start_date { get; set; }

        public DateTime? reg_start_date { get; set; }

        public short? period_auto { get; set; }

        public DateTime? reg_expiry_date { get; set; }

        public int? service_cycle_type_auto { get; set; }

        public int? turbo_mod_auto { get; set; }

        public int? control_sys_auto { get; set; }

        public int? calendar_period { get; set; }

        public byte? recurring_int_auto { get; set; }

        public DateTime? no_contract_fcast_date_at_start { get; set; }

        public int? no_contract_fcast_s_cycle_auto_at_end { get; set; }

        public int? no_contract_fcast_s_cycle_auto_at_start { get; set; }

        public long? no_contract_fcast_smu_at_start { get; set; }

        public int? track_make_auto { get; set; }

        public long? track_code_auto { get; set; }

        public long? cs_equip_auto { get; set; }

        public long? dtd_at_start { get; set; }

        public long? no_contract_fcast_smu_at_end { get; set; }

        public long? no_contract_fcast_LTD_at_start { get; set; }

        public long? no_contract_fcast_LTD_at_end { get; set; }

        public DateTime? no_contract_fcast_date_at_end { get; set; }

        public byte? ranking_auto { get; set; }

        public bool? secondary_uom_isHours { get; set; }

        public bool? secondary_uom_isDistance { get; set; }

        public bool? secondary_uom_isKWHours { get; set; }

        public bool? secondary_uom_isCalendar { get; set; }

        public bool? secondary_uom_isFuelBurn { get; set; }

        public decimal? smu_sec_reading { get; set; }

        public decimal? smu_ltd_sec_reading { get; set; }

        public decimal? distance_sec_reading { get; set; }

        public decimal? distance_ltd_sec_reading { get; set; }

        public byte? distance_sec_reading_uom { get; set; }

        public decimal? kw_hrs_sec_reading { get; set; }

        public decimal? kw_hrs_ltd_sec_reading { get; set; }

        public decimal? fuel_burn_sec_reading { get; set; }

        public decimal? fuel_burn_ltd_sec_reading { get; set; }

        public decimal? calender_sec_reading { get; set; }

        public byte? calender_sec_reading_uom { get; set; }

        public decimal? current_smu_sec_reading { get; set; }

        public decimal? current_distance_sec_reading { get; set; }

        public decimal? current_kw_hrs_sec_reading { get; set; }

        public decimal? current_fuel_burn_sec_reading { get; set; }

        public decimal? current_calender_sec_reading { get; set; }

        public int? health_review_auto { get; set; }

        public long? AS400_EQUIPMENT_AUTO { get; set; }

        public decimal? Sec_AVGDB_Hours { get; set; }

        public decimal? Sec_AVGDB_Distance { get; set; }

        public decimal? Sec_AVGDB_KWHOURS { get; set; }

        public decimal? Sec_AVGDB_FuelBurn { get; set; }

        public decimal? Sec_AVGDB_Calender { get; set; }

        public long? no_fcast_Sec_Smu { get; set; }

        public long? no_fcast_Sec_distance { get; set; }

        public long? no_fcast_Sec_SMU_ltd { get; set; }

        public long? no_fcast_Sec_distance_ltd { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool vision_link_exist { get; set; }

        public DateTime? vision_link_import_date { get; set; }

        [StringLength(200)]
        public string customer_name { get; set; }

        [StringLength(200)]
        public string jobsite_name { get; set; }

        [StringLength(200)]
        public string model { get; set; }

        public long? pc_equipmentid_auto { get; set; }

        public int? pc_inspection_auto { get; set; }

        public byte[] EquipmentPhoto { get; set; }
    }
}
