namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class APPLICATION_LU_CONFIG
    {
        [Key]
        [StringLength(50)]
        public string variable_key { get; set; }

        [Required]
        public string value_key { get; set; }

        [StringLength(1000)]
        public string description { get; set; }
    }
}
