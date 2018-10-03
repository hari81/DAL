namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MODEL")]
    public partial class MODEL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MODEL()
        {
            LU_MMTA = new HashSet<LU_MMTA>();
        }

        [Key]
        public int model_auto { get; set; }

        [Required]
        [StringLength(50)]
        public string modelid { get; set; }

        [Required]
        [StringLength(50)]
        public string modeldesc { get; set; }

        public byte? tt_prog_auto { get; set; }

        public byte? gb_prog_auto { get; set; }

        public byte? axle_no { get; set; }

        public DateTime created_date { get; set; }

        [StringLength(50)]
        public string created_user { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(50)]
        public string modified_user { get; set; }

        public int? track_sag_maximum { get; set; }

        public int? track_sag_minimum { get; set; }

        public bool? isPSC { get; set; }

        public short? model_size_auto { get; set; }

        public int? cs_model_auto { get; set; }

        public bool? cat { get; set; }

        public short? model_pricing_level_auto { get; set; }

        public short? equip_reg_industry_auto { get; set; }

        public string ModelNote { get; set; }
        public int LinksInChain { get; set; }
        public decimal? UCSystemCost { get; set; }
        public byte[] ModelImage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LU_MMTA> LU_MMTA { get; set; }
    }
}
