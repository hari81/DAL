namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FLUID_REPORT_LU_SETTINGS
    {
        [Key]
        [StringLength(50)]
        public string variable_key { get; set; }

        [Required]
        [StringLength(1000)]
        public string value_key { get; set; }

        [StringLength(500)]
        public string comment { get; set; }
    }
}
