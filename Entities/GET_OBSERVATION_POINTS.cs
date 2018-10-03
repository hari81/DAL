namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class GET_OBSERVATION_POINTS
    {
        public GET_OBSERVATION_POINTS()
        {
            req_measure = false;
            active = true;
        }

        [Key]
        public int observation_point_auto { get; set; }

        [StringLength(32)]
        public string observation_name { get; set; }

        public int? make { get; set; }

        public int? observation_list { get; set; }

        public bool req_measure { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? initial_length { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? worn_length { get; set; }

        [StringLength(32)]
        public string part_number { get; set; }

        public decimal? price { get; set; }

        public int get_auto { get; set; }

        public int? schematic_auto { get; set; }

        public int? positionX { get; set; }

        public int? positionY { get; set; }

        public bool active { get; set; }
    }
}