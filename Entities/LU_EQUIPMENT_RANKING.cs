namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LU_EQUIPMENT_RANKING
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte ranking_auto { get; set; }

        [Required]
        [StringLength(50)]
        public string ranking { get; set; }

        public byte rorder { get; set; }

        [StringLength(50)]
        public string color { get; set; }
    }
}
