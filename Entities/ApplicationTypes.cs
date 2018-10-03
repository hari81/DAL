namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ApplicationTypes
    {
        [Key]
        public int ApplicationTypeId { get; set; }
        public string ApplicationName { get; set; }
    }
}