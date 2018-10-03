namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class GET_OBSERVATION_POINT_INSPECTION
    {
        [Key]
        public int observation_point_inspection_auto { get; set; }

        public int observation_point_auto { get; set; }

        public int inspection_auto { get; set; }

        [Column(TypeName = "numeric")]
        public decimal measurement { get; set; }

        public string comment { get; set; }

        public DateTime inspection_date { get; set; }
    }
}