namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRACK_ACTION_TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRACK_ACTION_TYPE()
        {
            ACTION_TAKEN_HISTORY = new HashSet<ACTION_TAKEN_HISTORY>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int action_type_auto { get; set; }

        [StringLength(100)]
        public string action_description { get; set; }

        [StringLength(200)]
        public string compartment_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACTION_TAKEN_HISTORY> ACTION_TAKEN_HISTORY { get; set; }
    }
}
