namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_OBSERVATION_RESULTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GET_OBSERVATION_RESULTS()
        {
            GET_OBSERVATION_IMAGE = new HashSet<GET_OBSERVATION_IMAGE>();
        }

        [Key]
        public int results_auto { get; set; }

        public int inspection_auto { get; set; }

        public int observations_auto { get; set; }

        [Column("checked")]
        public bool _checked { get; set; }

        public virtual GET_COMPONENT_INSPECTION GET_COMPONENT_INSPECTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GET_OBSERVATION_IMAGE> GET_OBSERVATION_IMAGE { get; set; }

        public virtual GET_OBSERVATIONS GET_OBSERVATIONS { get; set; }
    }
}
