namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_CONFIG
    {
        [Key]
        [StringLength(32)]
        public string variable_key { get; set; }

        [StringLength(32)]
        public string value_key { get; set; }

        [StringLength(256)]
        public string description { get; set; }
    }
}
