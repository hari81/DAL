namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_INSPECTION_CONSTANTS
    {
        [Key]
        public int constants_auto { get; set; }

        public int parameter_type { get; set; }

        [Required]
        [StringLength(64)]
        public string inspect_desc { get; set; }

        public int display_order { get; set; }

        public virtual GET_INSPECTION_PARAMETERS GET_INSPECTION_PARAMETERS { get; set; }
    }
}
