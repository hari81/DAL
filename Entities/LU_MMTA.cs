namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LU_MMTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LU_MMTA()
        {
            EQUIPMENTs = new HashSet<EQUIPMENT>();
        }

        [Key]
        public int mmtaid_auto { get; set; }

        public int make_auto { get; set; }

        public int model_auto { get; set; }

        public int type_auto { get; set; }

        public int? arrangement_auto { get; set; }

        public short? app_auto { get; set; }

        public int? service_cycle_type_auto { get; set; }

        public DateTime expiry_date { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(50)]
        public string created_user { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(50)]
        public string modified_user { get; set; }

        public int? cs_mmtaid_auto { get; set; }

        public virtual APPLICATION APPLICATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EQUIPMENT> EQUIPMENTs { get; set; }

        public virtual MAKE MAKE { get; set; }

        public virtual MODEL MODEL { get; set; }

        public virtual TYPE TYPE { get; set; }
    }
}
