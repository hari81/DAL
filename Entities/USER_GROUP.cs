namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER_GROUP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER_GROUP()
        {
            USER_GROUP_ASSIGN = new HashSet<USER_GROUP_ASSIGN>();
        }

        [Key]
        public int group_auto { get; set; }

        [Required]
        [StringLength(50)]
        public string groupname { get; set; }

        [StringLength(500)]
        public string comment { get; set; }

        public bool active { get; set; }

        public byte? protect { get; set; }

        public DateTime? created_date { get; set; }

        public int? created_user_auto { get; set; }

        public DateTime start_date { get; set; }

        public DateTime? end_date { get; set; }

        public bool hid_value { get; set; }

        public bool can_chg_group { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_GROUP_ASSIGN> USER_GROUP_ASSIGN { get; set; }
    }
}
