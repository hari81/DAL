namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class APPLICATION_ERROR_LOG
    {
        public long id { get; set; }

        public DateTime? date { get; set; }

        [StringLength(2000)]
        public string pagename { get; set; }

        [StringLength(5000)]
        public string error { get; set; }

        [StringLength(8000)]
        public string stacktrace { get; set; }
    }
}
