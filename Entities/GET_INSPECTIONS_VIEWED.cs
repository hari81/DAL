namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_INSPECTIONS_VIEWED
    {
        [Key]
        public long inspections_viewed_auto { get; set; }

        public long inspection_auto { get; set; }

        public long user_auto { get; set; }

        public DateTime viewed_date { get; set; }
    }
}
