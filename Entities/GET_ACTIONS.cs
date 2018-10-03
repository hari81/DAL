namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_ACTIONS
    {
        [Key]
        public int actions_auto { get; set; }

        [Required]
        [StringLength(64)]
        public string action_name { get; set; }
    }
}
