namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Consent
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(200)]
        public string Subject { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string ClientId { get; set; }

        [Required]
        [StringLength(2000)]
        public string Scopes { get; set; }
    }
}
