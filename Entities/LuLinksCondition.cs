namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LuLinksCondition
    {
        [Key]
        public long ConditionId { get; set; }

        [StringLength(100)]
        public string Condition { get; set; }
    }
}
