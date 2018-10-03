namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MENU_L3
    {
        [Key]
        public int menu_L3_auto { get; set; }

        public int? menu_L2_auto { get; set; }

        public byte? moduleid { get; set; }

        [StringLength(100)]
        public string label { get; set; }

        [StringLength(100)]
        public string targetpath { get; set; }

        public int? object_auto { get; set; }

        public short? sorder { get; set; }

        public bool active { get; set; }

        [StringLength(500)]
        public string tooltip { get; set; }

        public bool new_window { get; set; }

        public virtual LU_MODULE_GROUP LU_MODULE_GROUP { get; set; }

        public virtual MENU_L2 MENU_L2 { get; set; }
    }
}
