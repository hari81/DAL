namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER_TABLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER_TABLE()
        {
            COMP_Inventory_Inspec_Details = new HashSet<COMP_Inventory_Inspec_Details>();
            COMPONENT_LIFE = new HashSet<ComponentLife>();
            Dealerships = new HashSet<Dealership>();
            EQUIPMENT_AUDIT_HISTOY = new HashSet<EQUIPMENT_AUDIT_HISTOY>();
            EQUIPMENT_LIFE = new HashSet<EQUIPMENT_LIFE>();
            UCSYSTEM_LIFE = new HashSet<SystemLife>();
            USER_CRSF_CUST_EQUIP = new HashSet<USER_CRSF_CUST_EQUIP>();
            USER_CRSF_CUST_EQUIP1 = new HashSet<USER_CRSF_CUST_EQUIP>();
            USER_DEALERSHIP = new HashSet<USER_DEALERSHIP>();
            UserAccessMaps = new HashSet<UserAccessMaps>();
        }

        [Key]
        public long user_auto { get; set; }

        [Required]
        [StringLength(50)]
        public string userid { get; set; }

        [Required]
        [StringLength(100)]
        public string username { get; set; }

        [Required]
        [StringLength(100)]
        public string passwd { get; set; }

        public bool internalemp { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(5)]
        public string phone_area_code { get; set; }

        [StringLength(20)]
        public string phone_number { get; set; }

        [StringLength(5)]
        public string fax_area_code { get; set; }

        [StringLength(20)]
        public string fax_number { get; set; }

        [StringLength(20)]
        public string mobile { get; set; }

        [StringLength(500)]
        public string street1 { get; set; }

        [StringLength(500)]
        public string street2 { get; set; }

        [StringLength(200)]
        public string suburb { get; set; }

        [StringLength(20)]
        public string postcode { get; set; }

        [StringLength(50)]
        public string state { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        public int? position_auto { get; set; }
        [ForeignKey("Language")]
        public byte language_auto { get; set; }

        [StringLength(1)]
        public string temperature_unit { get; set; }

        [ForeignKey("Currency")]
        public int currency_auto { get; set; }

        [StringLength(1)]
        public string weight_unit { get; set; }

        [StringLength(1)]
        public string length_unit { get; set; }

        [StringLength(1)]
        public string area_unit { get; set; }

        [StringLength(1)]
        public string volume_unit { get; set; }

        [StringLength(10)]
        public string pressure_unit { get; set; }

        public bool interpreter { get; set; }

        public bool viewr { get; set; }

        public bool viewe { get; set; }

        public bool active { get; set; }

        public bool first_login { get; set; }

        public DateTime? last_login_date { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(50)]
        public string created_user { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(50)]
        public string modified_user { get; set; }

        public bool? rpt_print { get; set; }

        public bool? EvalA { get; set; }

        public bool? EvalB { get; set; }

        public bool? EvalC { get; set; }

        public bool? EvalX { get; set; }

        public bool? SMS { get; set; }

        [Column("protected")]
        public bool _protected { get; set; }

        [StringLength(100)]
        public string company { get; set; }

        public byte? login_moduleid { get; set; }

        public short? colorscheme_auto { get; set; }

        public bool? send_fax { get; set; }

        public bool? send_email { get; set; }

        public bool? send_hardcopy { get; set; }

        public DateTime? away_start_date { get; set; }

        public DateTime? away_end_date { get; set; }

        public bool attach { get; set; }

        public byte print_copies { get; set; }

        public long? customer_auto { get; set; }

        public byte? url_auto { get; set; }

        public bool sos { get; set; }

        public byte? laboratory_auto { get; set; }

        public bool? must_change_password { get; set; }

        public byte? invalid_login_count { get; set; }

        public DateTime? invalid_login_start_time { get; set; }

        public DateTime? last_password_change { get; set; }

        public bool? password_encrypted { get; set; }

        public long? CS_UserAuto { get; set; }

        public bool? can_create_cs_account { get; set; }

        public bool? internalother { get; set; }

        public int? country_auto { get; set; }

        public byte? detail_email { get; set; }

        public byte? summary_email { get; set; }

        public byte? summary_group { get; set; }

        [StringLength(1000)]
        public string comment { get; set; }

        public bool suspended { get; set; }

        public bool? branded_admin { get; set; }

        public bool IsEquipmentEdit { get; set; }

        [StringLength(50)]
        public string mob_license { get; set; }

        public string mob_device_id { get; set; }

        [StringLength(50)]
        public string track_uom { get; set; }

        public bool? eq_health { get; set; }

        public long? AS400_PSSR_AUTO { get; set; }

        [StringLength(10)]
        public string AS400_PSSR_EMPNO { get; set; }

        [StringLength(50)]
        public string cat_id { get; set; }

        [StringLength(50)]
        public string cat_password { get; set; }

        public bool? eq_undercarriage { get; set; }

        public string Position_name_Quote { get; set; }
        public string AspNetUserId { get; set; }
        public int? ApplicationAccess { get; set; }


        public virtual CURRENCY Currency { get; set; }
        public virtual LANGUAGE Language { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMP_Inventory_Inspec_Details> COMP_Inventory_Inspec_Details { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComponentLife> COMPONENT_LIFE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dealership> Dealerships { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EQUIPMENT_AUDIT_HISTOY> EQUIPMENT_AUDIT_HISTOY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EQUIPMENT_LIFE> EQUIPMENT_LIFE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SystemLife> UCSYSTEM_LIFE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_CRSF_CUST_EQUIP> USER_CRSF_CUST_EQUIP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_CRSF_CUST_EQUIP> USER_CRSF_CUST_EQUIP1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_DEALERSHIP> USER_DEALERSHIP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAccessMaps> UserAccessMaps { get; set; }

        public virtual ICollection<USER_GROUP_ASSIGN> JobRoles { get; set; }
        public virtual ICollection<SearchFavorite> UCSearchFavorites { get; set; }
        public virtual ICollection<USER_DEALERGROUP_RELATION> DealerGroups { get; set; }
        public virtual ICollection<USER_DEALER_RELATION> Dealers { get; set; }
        public virtual ICollection<USER_CUSTOMER_RELATION> Customers { get; set; }
        public virtual ICollection<USER_JOBSITE_RELATION> Jobsites { get; set; }
        public virtual ICollection<EQUIPMENT> Equipments { get; set; }
        public virtual ICollection<USER_SUPPORTTEAM_RELATION> SupportTeams { get; set; }

    }
}
