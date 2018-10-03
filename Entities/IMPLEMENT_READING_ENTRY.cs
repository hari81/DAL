namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IMPLEMENT_READING_ENTRY
    {
        [Key]
        public int implement_reading_entry_auto { get; set; }

        public DateTime inspection_date { get; set; }

        public int implement_id { get; set; }

        public int ltd { get; set; }

        public virtual GET GET { get; set; }
    }
}
