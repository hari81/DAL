namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_IMPLEMENT_INSPECTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GET_IMPLEMENT_INSPECTION()
        {
            GET_COMPONENT_INSPECTION = new HashSet<GET_COMPONENT_INSPECTION>();
            GET_IMPLEMENT_INSPECTION_IMAGE = new HashSet<GET_IMPLEMENT_INSPECTION_IMAGE>();
        }

        [Key]
        public int inspection_auto { get; set; }

        public DateTime inspection_date { get; set; }

        public int get_auto { get; set; }

        public int meter_reading { get; set; }

        [Required]
        [StringLength(256)]
        public string overall_notes { get; set; }

        public int dirty_environment { get; set; }

        public int work_area { get; set; }

        public int machine { get; set; }

        public int area { get; set; }

        public int condition { get; set; }

        public bool flag { get; set; }

        public int eval { get; set; }

        public int ltd { get; set; }

        public long user_auto { get; set; }

        public virtual GET GET { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GET_COMPONENT_INSPECTION> GET_COMPONENT_INSPECTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GET_IMPLEMENT_INSPECTION_IMAGE> GET_IMPLEMENT_INSPECTION_IMAGE { get; set; }
    }
}
