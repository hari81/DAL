namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_SCHEMATIC_IMAGE
    {
        [Key]
        public int schematic_auto { get; set; }

        public byte[] attachment { get; set; }

        [Column(TypeName = "text")]
        public string button_positions { get; set; }

        [StringLength(100)]
        public string comment { get; set; }

        [StringLength(50)]
        public string file_name { get; set; }
    }
}
