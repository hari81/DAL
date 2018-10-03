namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ScopeSecret
    {
        public int Id { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public DateTimeOffset? Expiration { get; set; }

        [StringLength(250)]
        public string Type { get; set; }

        [Required]
        [StringLength(250)]
        public string Value { get; set; }

        public int Scope_Id { get; set; }

        public virtual Scope Scope { get; set; }
    }
}
