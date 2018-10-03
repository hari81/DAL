namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MENU_L2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MENU_L2()
        {
            MENU_L3 = new HashSet<MENU_L3>();
        }

        [Key]
        public int menu_L2_auto { get; set; }

        public int? menu_L1_auto { get; set; }

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

        public virtual MENU_L1 MENU_L1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENU_L3> MENU_L3 { get; set; }
    }
}
