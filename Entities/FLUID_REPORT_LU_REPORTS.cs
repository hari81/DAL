namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FLUID_REPORT_LU_REPORTS
    {
        [Key]
        public int report_auto { get; set; }

        [Required]
        [StringLength(100)]
        public string report_display_name { get; set; }

        [Required]
        [StringLength(100)]
        public string report_tool_name { get; set; }

        [Required]
        [StringLength(100)]
        public string report_display_desc { get; set; }

        [Required]
        [StringLength(50)]
        public string language { get; set; }

        public bool active { get; set; }
    }
}
