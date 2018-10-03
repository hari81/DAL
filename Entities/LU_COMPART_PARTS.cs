namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LU_COMPART_PARTS
    {
        [Key]
        public int compartment_part_auto { get; set; }

        public int compartid_auto { get; set; }

        public string name { get; set; }

        public bool active { get; set; }

        public virtual LU_COMPART LU_COMPART { get; set; }
    }
}
