namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_EVENTS_IMPLEMENT
    {
        [Key]
        public long implement_events_auto { get; set; }

        [ForeignKey("GETs")]
        public int get_auto { get; set; }

        public int ltd { get; set; }

        [ForeignKey("Events")]
        public long events_auto { get; set; }

        public virtual GET_EVENTS Events { get; set; }

        public virtual GET GETs { get; set; }
    }
}
