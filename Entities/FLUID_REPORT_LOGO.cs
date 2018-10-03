namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FLUID_REPORT_LOGO
    {
        [Key]
        public int logo_auto { get; set; }

        [Required]
        [StringLength(100)]
        public string display_name { get; set; }

        [StringLength(50)]
        public string top_left_logo_img { get; set; }

        [StringLength(50)]
        public string top_right_logo_img { get; set; }

        [StringLength(50)]
        public string bottom_mid_logo_img { get; set; }

        [StringLength(50)]
        public string bottom_right_img { get; set; }

        [StringLength(2000)]
        public string bottom_address_str { get; set; }

        [StringLength(2000)]
        public string bottom_desc_str { get; set; }

        [Column("default")]
        public bool _default { get; set; }

        [StringLength(2000)]
        public string advertisement { get; set; }
    }
}
