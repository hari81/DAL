namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LU_MODULE_GROUP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LU_MODULE_GROUP()
        {
            MENU_L1 = new HashSet<MENU_L1>();
            MENU_L2 = new HashSet<MENU_L2>();
            MENU_L3 = new HashSet<MENU_L3>();
            USER_MODULE_ACCESS = new HashSet<USER_MODULE_ACCESS>();
        }

        [Key]
        public byte moduleid { get; set; }

        [Required]
        [StringLength(50)]
        public string moduledesc { get; set; }

        public byte? sorder { get; set; }

        public bool active { get; set; }

        public bool have_component { get; set; }

        [StringLength(50)]
        public string comp_tbl_name { get; set; }

        [StringLength(400)]
        public string login_targetpath { get; set; }

        [Column("default")]
        public bool? _default { get; set; }

        [StringLength(100)]
        public string homepage_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENU_L1> MENU_L1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENU_L2> MENU_L2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENU_L3> MENU_L3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_MODULE_ACCESS> USER_MODULE_ACCESS { get; set; }
    }
}
