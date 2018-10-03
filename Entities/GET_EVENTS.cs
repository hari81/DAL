namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_EVENTS
    {
        [Key]
        public long events_auto { get; set; }

        public long user_auto { get; set; }

        [ForeignKey("Actions")]
        public int action_auto { get; set; }

        public DateTime event_date { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(256)]
        public string comment { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cost { get; set; }

        public DateTime recorded_date { get; set; }

        [ForeignKey("UCActionHistory")]
        public long? UCActionHistoryId { get; set; }
        public int recordStatus { get; set; }
        public virtual ACTION_TAKEN_HISTORY UCActionHistory { get; set; }

        public virtual GET_ACTIONS Actions { get; set; }
    }
}
