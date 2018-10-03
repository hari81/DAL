namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mbl_Track_Inspection_Detail
    {
        [Key]
        [Column(Order = 0)]
        public int inspection_detail_auto { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int inspection_auto { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long track_unit_auto { get; set; }

        public int? tool_auto { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal reading { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal worn_percentage { get; set; }

        [StringLength(1)]
        public string eval_code { get; set; }

        public int? hours_on_surface { get; set; }

        public int? projected_hours { get; set; }

        public int? ext_projected_hours { get; set; }

        public int? remaining_hours { get; set; }

        public int? ext_remaining_hours { get; set; }

        [StringLength(200)]
        public string comments { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal worn_percentage_120 { get; set; }
    }
}
