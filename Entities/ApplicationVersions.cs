namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ApplicationVersions
    {
        [Key]
        public int ApplicationVersionId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Version { get; set; }
        public int ApplicationTypeId { get; set; }
        public virtual ApplicationTypes ApplicationTypes { get; set; }
    }
}