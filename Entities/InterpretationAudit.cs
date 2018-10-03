namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class InterpretationAudit
    {
        public int Id { get; set; }
        public DateTime EventTime { get; set; }
        public string Message { get; set; }
        [ForeignKey("User")]
        public long UserId { get; set; }
        [ForeignKey("Inspection")]
        public int InspectionId { get; set; }

        public virtual TRACK_INSPECTION Inspection { get; set; }
        public virtual USER_TABLE User { get; set; }
    }
}
