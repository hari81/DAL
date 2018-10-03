namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_EVENTS_INVENTORY
    {
        [Key]
        public long inventory_events_auto { get; set; }

        [ForeignKey("implement_event")]
        public long implement_events_auto { get; set; }

        [ForeignKey("crsf")]
        public long jobsite_auto { get; set; }

        [ForeignKey("inventory_status")]
        public int status_auto { get; set; }

        [ForeignKey("workshop")]
        public int? workshop_auto { get; set; }

        public virtual GET_EVENTS_IMPLEMENT implement_event { get; set; }

        public virtual CRSF crsf { get; set; }

        public virtual GET_INVENTORY_STATUS inventory_status { get; set; }

        public virtual GET_WORKSHOP workshop { get; set; }
    }
}