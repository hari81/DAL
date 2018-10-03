namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_OBSERVATION_LIST
    {
        [Key]
        public int observation_list_auto { get; set; }

        [Required]
        [StringLength(128)]
        public string name { get; set; }

        public int create_user { get; set; }

        public DateTime create_date { get; set; }

        public bool active { get; set; }

        public long? customer_auto { get; set; } 
    }
}
