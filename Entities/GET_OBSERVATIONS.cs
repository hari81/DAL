namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_OBSERVATIONS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GET_OBSERVATIONS()
        {
            GET_OBSERVATION_RESULTS = new HashSet<GET_OBSERVATION_RESULTS>();
        }

        [Key]
        public int observations_auto { get; set; }

        [Required]
        [StringLength(128)]
        public string observation { get; set; }

        public int observation_list_auto { get; set; }

        public bool active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GET_OBSERVATION_RESULTS> GET_OBSERVATION_RESULTS { get; set; }
    }
}
