namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CUSTOMER")]
    public partial class CUSTOMER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUSTOMER()
        {
            UserAccessMaps = new HashSet<UserAccessMaps>();
            USER_CRSF_CUST_EQUIP = new HashSet<USER_CRSF_CUST_EQUIP>();
        }

        [Key]
        public long customer_auto { get; set; }

        [Required]
        [StringLength(200)]
        public string custid { get; set; }

        [Required]
        [StringLength(400)]
        public string cust_name { get; set; }

        [StringLength(100)]
        public string cust_street { get; set; }

        [StringLength(50)]
        public string cust_suburb { get; set; }

        [StringLength(20)]
        public string cust_postcode { get; set; }

        [StringLength(50)]
        public string cust_state { get; set; }

        [StringLength(50)]
        public string cust_country { get; set; }

        [StringLength(50)]
        public string cust_phone { get; set; }

        [StringLength(15)]
        public string cust_mobile { get; set; }

        [StringLength(50)]
        public string cust_fax { get; set; }

        [StringLength(100)]
        public string cust_email { get; set; }

        [StringLength(1000)]
        public string note { get; set; }

        public long? customer_auto_main { get; set; }

        [StringLength(500)]
        public string companyname { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(50)]
        public string created_user { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(50)]
        public string modified_user { get; set; }

        [StringLength(20)]
        public string cust_formid { get; set; }

        [StringLength(20)]
        public string db_custid { get; set; }

        [StringLength(100)]
        public string cust_street2 { get; set; }

        public bool active { get; set; }

        [StringLength(100)]
        public string cust_billing_street { get; set; }

        [StringLength(100)]
        public string cust_billing_street2 { get; set; }

        [StringLength(50)]
        public string cust_billing_suburb { get; set; }

        [StringLength(20)]
        public string cust_billing_postcode { get; set; }

        [StringLength(50)]
        public string cust_billing_state { get; set; }

        [StringLength(50)]
        public string cust_billing_country { get; set; }

        public bool billing_address { get; set; }

        public byte? primary_language { get; set; }

        public byte? second_language { get; set; }

        public bool? is_account_payment { get; set; }

        public long? cs_customer_auto { get; set; }

        public bool? labonly { get; set; }

        public int? cust_country_auto { get; set; }

        public int? cust_billing_country_auto { get; set; }

        public int? payment_terms { get; set; }

        [StringLength(200)]
        public string logo_name { get; set; }

        public byte? district_auto { get; set; }

        public long? cs_ws_url_auto { get; set; }

        [StringLength(150)]
        public string business_system { get; set; }

        public bool? ic_workorder { get; set; }

        public bool? ic_component_forecast { get; set; }

        public string business_system_key { get; set; }

        public decimal? quote_discount { get; set; }

        public long? ProfileID { get; set; }

        public bool Showlimits { get; set; }

        public bool? send_fax { get; set; }

        public bool? send_email { get; set; }

        public bool? send_hardcopy { get; set; }

        [StringLength(50)]
        public string Payment_Type { get; set; }

        [StringLength(50)]
        public string Contact_Type { get; set; }

        public decimal? terms_Exceeded { get; set; }

        public long? AS400_CUSTOMER_AUTO { get; set; }

        public string invoice_note { get; set; }

        [Column(TypeName = "image")]
        public byte[] logo { get; set; }

        public int DealershipId { get; set; }

        public long? CreatedByUserId { get; set; }

        public int? subPremise { get; set; }

        public string fullAddress { get; set; }
        [ForeignKey("SelectedReport")]
        public int? SelectedReportId { get; set; }

        public virtual Dealership Dealership { get; set; }
        public virtual FLUID_REPORT_LU_REPORTS SelectedReport { get; set; }



        public int? QuoteReportStyle { get; set; }

        public decimal DefaultHourlyRate { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAccessMaps> UserAccessMaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_CRSF_CUST_EQUIP> USER_CRSF_CUST_EQUIP { get; set; }
        public virtual ICollection<DEALER_CUSTOMER_RELATION> Dealers { get; set; }
        public virtual ICollection<USER_CUSTOMER_RELATION> Users { get; set; }
        public virtual ICollection<DEALERGROUP_CUSTOMER_RELATION> DealerGroups { get; set; }
    }
}
