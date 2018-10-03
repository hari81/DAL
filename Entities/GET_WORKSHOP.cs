namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_WORKSHOP
    {
        [Key]
        public int workshop_auto { get; set; }

        public string name { get; set; }

        [ForeignKey("repairer")]
        public int repairer_auto { get; set; }

        public virtual GET_REPAIRER repairer { get; set; }
    }
}