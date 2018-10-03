namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_IMPLEMENT_COMPARTTYPE
    {
        [Key]
        public long implement_comparttype_auto { get; set; }

        public long implement_auto { get; set; }

        public int comparttype_auto { get; set; }
    }
}
