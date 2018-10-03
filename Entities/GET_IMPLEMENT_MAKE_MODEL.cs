namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_IMPLEMENT_MAKE_MODEL
    {
        [Key]
        public long implement_make_model_auto { get; set; }

        public long implement_auto { get; set; }

        public long? make_auto { get; set; }

        public long model_auto { get; set; }
    }
}
