namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EQUIPMENT_AUDIT_HISTOY
    {
        [Key]
        public long equipAudit_auto { get; set; }

        public long equipmentid_auto { get; set; }

        public DateTime date { get; set; }

        public long user_auto { get; set; }

        [Required]
        [StringLength(50)]
        public string field { get; set; }

        [Required]
        [StringLength(100)]
        public string beforeChange { get; set; }

        [Required]
        [StringLength(100)]
        public string afterChange { get; set; }

        public virtual USER_TABLE USER_TABLE { get; set; }
    }
}
