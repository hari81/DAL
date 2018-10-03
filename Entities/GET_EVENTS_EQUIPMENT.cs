namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_EVENTS_EQUIPMENT
    {
        [Key]
        public long equipment_events_auto { get; set; }

        [ForeignKey("Equipment")]
        public long equipment_auto { get; set; }

        public int smu { get; set; }

        public int ltd { get; set; }

        [ForeignKey("Event")]
        public long events_auto { get; set; }

        public virtual GET_EVENTS Event { get; set; }

        public virtual EQUIPMENT Equipment { get; set; }
    }
}
