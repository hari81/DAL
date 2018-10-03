namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRACK_ACTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRACK_ACTION()
        {
            TRACK_ACTION_TAKEN = new HashSet<TRACK_ACTION_TAKEN>();
        }

        [Key]
        public int action_auto { get; set; }

        public int inspection_auto { get; set; }

        [StringLength(1000)]
        public string action_recommandation { get; set; }

        [StringLength(50)]
        public string recommanded_by { get; set; }

        public DateTime? recommanded_on { get; set; }

        public bool? problem_solved { get; set; }

        [StringLength(50)]
        public string created_user { get; set; }

        public DateTime? created_date { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(50)]
        public string modified_user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACK_ACTION_TAKEN> TRACK_ACTION_TAKEN { get; set; }

        public virtual TRACK_INSPECTION TRACK_INSPECTION { get; set; }
    }
}
