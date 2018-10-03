namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_EVENTS_COMPONENT
    {
        public GET_EVENTS_COMPONENT()
        {
            recordStatus = 0;
        }

        [Key]
        public long component_events_auto { get; set; }

        [ForeignKey("GET_COMPONENT")]
        public int get_component_auto { get; set; }

        public int ltd { get; set; }

        [ForeignKey("Events")]
        public long events_auto { get; set; }

        public int recordStatus { get; set; }

        public virtual GET_EVENTS Events { get; set; }

        public virtual GET_COMPONENT GET_COMPONENT { get; set; }
    }
}
