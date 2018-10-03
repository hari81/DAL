namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER_DEALERSHIP
    {
        public long user_auto { get; set; }

        public int dealership_auto { get; set; }

        public int Id { get; set; }

        public virtual USER_TABLE USER_TABLE { get; set; }
    }
}
