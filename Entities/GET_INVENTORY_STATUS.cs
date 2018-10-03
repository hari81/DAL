namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class GET_INVENTORY_STATUS
    {
        [Key]
        public int status_auto { get; set; }

        public string status_desc { get; set; }
    }
}