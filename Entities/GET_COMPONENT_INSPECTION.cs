namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_COMPONENT_INSPECTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GET_COMPONENT_INSPECTION()
        {
            GET_OBSERVATION_RESULTS = new HashSet<GET_OBSERVATION_RESULTS>();
        }

        [Key]
        public int inspection_auto { get; set; }

        public int get_component_auto { get; set; }

        [Column(TypeName = "numeric")]
        public decimal measurement { get; set; }

        public bool flag { get; set; }

        public bool replace { get; set; }

        [StringLength(256)]
        public string comment { get; set; }

        public DateTime inspection_date { get; set; }

        public int implement_inspection_auto { get; set; }

        public bool flag_ignored { get; set; }

        public int ltd { get; set; }

        public virtual GET_IMPLEMENT_INSPECTION GET_IMPLEMENT_INSPECTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GET_OBSERVATION_RESULTS> GET_OBSERVATION_RESULTS { get; set; }
    }
}
