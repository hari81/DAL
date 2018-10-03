namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LU_IMPLEMENT
    {
        [Key]
        public long implement_auto { get; set; }

        [StringLength(50)]
        public string implementdescription { get; set; }

        public long? parentID { get; set; }

        [StringLength(50)]
        public string schematic_auto_multiple { get; set; }

        public int implement_category_auto { get; set; }

        [ForeignKey("Customer")]
        public long? CustomerId { get; set; }

        public CUSTOMER Customer { get; set; }
    }
}
