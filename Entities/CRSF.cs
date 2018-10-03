namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CRSF")]
    public partial class CRSF
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CRSF()
        {
            CRSF_AREA = new HashSet<CRSF_AREA>();
            UserAccessMaps = new HashSet<UserAccessMaps>();
            USER_CRSF_CUST_EQUIP = new HashSet<USER_CRSF_CUST_EQUIP>();
        }

        [Key]
        public long crsf_auto { get; set; }
        [ForeignKey("Customer")]
        public long customer_auto { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(50)]
        public string created_user { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(50)]
        public string modified_user { get; set; }

        [StringLength(500)]
        public string site_name { get; set; }

        [StringLength(300)]
        public string site_street { get; set; }

        [StringLength(300)]
        public string site_street2 { get; set; }

        [StringLength(100)]
        public string site_suburb { get; set; }

        [StringLength(20)]
        public string site_postcode { get; set; }

        [StringLength(50)]
        public string site_state { get; set; }

        [StringLength(50)]
        public string site_country { get; set; }

        public bool? priority { get; set; }

        public int? branch_auto { get; set; }

        public long? cs_jobsite_auto { get; set; }

        public int? site_country_auto { get; set; }

        public bool? hold_report_until_paid { get; set; }

        public short? hold_invoice_days { get; set; }

        public bool? schedule_sample_kit { get; set; }

        public int? type_auto { get; set; }

        public int DealerId { get; set; }
        public long? CreatedByUserId { get; set; }

        public string FullAddress { get; set; }

        [ForeignKey("CreatedByUserId")]
        public virtual USER_TABLE User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRSF_AREA> CRSF_AREA { get; set; }
        public virtual CUSTOMER Customer { get; set; }

        public virtual CRSF_TYPE CRSF_TYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAccessMaps> UserAccessMaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_CRSF_CUST_EQUIP> USER_CRSF_CUST_EQUIP { get; set; }
        public virtual ICollection<DEALER_JOBSITE_RELATION> Dealers { get; set; }
        public virtual ICollection<USER_JOBSITE_RELATION> Users { get; set; }
         
    }
}
