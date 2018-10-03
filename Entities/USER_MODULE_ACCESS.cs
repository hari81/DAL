namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER_MODULE_ACCESS
    {
        [Key]
        public int user_module_auto { get; set; }
        public long user_auto { get; set; }
        public Int16 moduleid { get; set; }

    }
}
