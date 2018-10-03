namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CRSF_AREA
    {
        [Key]
        public long crsf_area_auto { get; set; }

        [Required]
        [StringLength(200)]
        public string area { get; set; }

        public long? parentid_auto { get; set; }

        public long? crsf_auto { get; set; }

        public bool active { get; set; }

        public virtual CRSF CRSF { get; set; }
    }
}
