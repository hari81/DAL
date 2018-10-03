namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRACK_QUOTE_DETAIL
    {
        [Key]
        public int quote_detail_auto { get; set; }

        [ForeignKey("Quote")]
        public int quote_auto { get; set; }

        [StringLength(10)]
        public string track_unit_auto { get; set; }

        public long ComponentId { get; set; }

        public int op_type_auto { get; set; }

        public int start_smu { get; set; }

        public int end_smu { get; set; }

        public int? part_auto { get; set; }

        [Column(TypeName = "money")]
        public decimal? price { get; set; }
        [Column(TypeName = "money")]
        public decimal? LabourCost { get; set; }
        [Column(TypeName = "money")]
        public decimal? PartsCost { get; set; }
        [Column(TypeName = "money")]
        public decimal? MiscCost { get; set; }

        public int? qty { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(50)]
        public string created_user { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(50)]
        public string modified_user { get; set; }
        public string Comment { get; set; }

        public virtual TRACK_QUOTE Quote { get; set; }
    }
}
