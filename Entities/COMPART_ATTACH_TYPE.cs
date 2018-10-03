namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class COMPART_ATTACH_TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COMPART_ATTACH_TYPE()
        {
            COMPART_ATTACH_FILESTREAM = new HashSet<COMPART_ATTACH_FILESTREAM>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int compart_attach_type_auto { get; set; }

        [Required]
        public string compart_attach_type_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMPART_ATTACH_FILESTREAM> COMPART_ATTACH_FILESTREAM { get; set; }
    }
}
