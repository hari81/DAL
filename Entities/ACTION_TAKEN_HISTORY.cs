namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ACTION_TAKEN_HISTORY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACTION_TAKEN_HISTORY()
        {
            COMPONENT_LIFE = new HashSet<ComponentLife>();
            EQUIPMENT_LIFE = new HashSet<EQUIPMENT_LIFE>();
            TRACK_INSPECTION = new HashSet<TRACK_INSPECTION>();
            UCSYSTEM_LIFE = new HashSet<SystemLife>();
        }

        [Key]
        public long history_id { get; set; }

        public int action_type_auto { get; set; }

        [Column(TypeName = "date")]
        public DateTime event_date { get; set; }

        public int cmu { get; set; }

        public long cost { get; set; }
        public decimal LabourCost { get; set; }
        public decimal PartsCost { get; set; }
        public decimal MiscCost { get; set; }


        public int LabourCostOptions { get; set; }

        [StringLength(1000)]
        public string comment { get; set; }
        
        public long? equnit_auto { get; set; }

        public long? equnit_auto_new { get; set; }
        public long entry_user_auto { get; set; }

        public int compartid_auto { get; set; }

        public long equipmentid_auto { get; set; }

        public int equipment_smu { get; set; }

        public int equipment_ltd { get; set; }

        [Column(TypeName = "date")]
        public DateTime entry_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? last_modified_date { get; set; }

        public long? last_modified_user_auto { get; set; }
        public long? system_auto_id { get; set; }
        public long? system_auto_id_new { get; set; }
        
        public int recordStatus { get; set; }
        public virtual TRACK_ACTION_TYPE TRACK_ACTION_TYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComponentLife> COMPONENT_LIFE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EQUIPMENT_LIFE> EQUIPMENT_LIFE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACK_INSPECTION> TRACK_INSPECTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SystemLife> UCSYSTEM_LIFE { get; set; }

        [ForeignKey("GETActionHistory")]
        public long? GETActionHistoryId { get; set; }
        public ICollection<GET_EVENTS> GETActionHistory { get; set; }

    }
}
