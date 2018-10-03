namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CURRENCY")]
    public partial class CURRENCY
    {
        [Key]
        public int currency_auto { get; set; }

        [Required]
        [StringLength(5)]
        public string currency_code { get; set; }

        [Required]
        [StringLength(50)]
        public string currency_name { get; set; }
    }
}
