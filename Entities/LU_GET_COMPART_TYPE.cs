namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LU_GET_COMPART_TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LU_GET_COMPART_TYPE()
        {
            LU_GET_COMPART = new HashSet<LU_GET_COMPART>();
        }

        [Key]
        public int comparttype_auto { get; set; }

        [Required]
        [StringLength(10)]
        public string comparttypeid { get; set; }

        [Required]
        [StringLength(100)]
        public string comparttype { get; set; }

        public int? sorder { get; set; }

        [Column("protected")]
        public bool? _protected { get; set; }

        public long? modified_user_auto { get; set; }

        public DateTime? modified_date { get; set; }

        public long? implement_auto { get; set; }

        public bool? multiple { get; set; }

        public int? max_no { get; set; }

        public byte? progid { get; set; }

        public int? fixedamount { get; set; }

        public int? min_no { get; set; }

        public bool? getmesurement { get; set; }

        public short? system_auto { get; set; }

        public int? cs_comparttype_auto { get; set; }

        public long? standard_compart_type_auto { get; set; }

        [StringLength(10)]
        public string comparttype_shortkey { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LU_GET_COMPART> LU_GET_COMPART { get; set; }
    }
}
