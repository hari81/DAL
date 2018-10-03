namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_COMPONENT
    {
        [Key]
        public int get_component_auto { get; set; }

        public int? make_auto { get; set; }

        [ForeignKey("GETs")]
        public int get_auto { get; set; }

        public int? observation_list_auto { get; set; }

        public int cmu { get; set; }

        public DateTime? install_date { get; set; }

        public int ltd_at_setup { get; set; }

        public bool? req_measure { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? initial_length { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? worn_length { get; set; }

        [Column(TypeName = "money")]
        public decimal? price { get; set; }

        [StringLength(50)]
        public string part_no { get; set; }

        [ForeignKey("GET_SCHEMATIC_COMPONENT")]
        public int? schematic_component_auto { get; set; }

        public bool active { get; set; }

        public virtual GET GETs { get; set; }

        public virtual GET_SCHEMATIC_COMPONENT GET_SCHEMATIC_COMPONENT { get; set; }

    }
}
