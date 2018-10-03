namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class GET_OBSERVATION_POINT_RESULTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GET_OBSERVATION_POINT_RESULTS()
        {
            GET_OBSERVATION_POINT_IMAGES = new HashSet<GET_OBSERVATION_POINT_IMAGES>();
        }

        [Key]
        public int observation_point_results_auto { get; set; }

        public int observation_point_inspection_auto { get; set; }

        public int observations_auto { get; set; }

        [Column("checked")]
        public bool _checked { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GET_OBSERVATION_POINT_IMAGES> GET_OBSERVATION_POINT_IMAGES { get; set; }
    }
}