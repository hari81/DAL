namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class InspectionDetails_Side
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("INSPECTION_DETAIL")]
        public int InspectionDetailsId { get; set; }

        public int Side { get; set; }

        public virtual TRACK_INSPECTION_DETAIL INSPECTION_DETAIL { get; set; }
    }
}
