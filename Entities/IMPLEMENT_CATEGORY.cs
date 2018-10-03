namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IMPLEMENT_CATEGORY
    {
        [Key]
        public int implement_category_auto { get; set; }

        [Required]
        [StringLength(32)]
        public string category_name { get; set; }

        [Required]
        [StringLength(128)]
        public string category_desc { get; set; }

        [Required]
        [StringLength(16)]
        public string category_shortname { get; set; }
    }
}
