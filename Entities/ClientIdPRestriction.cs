namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ClientIdPRestriction
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Provider { get; set; }
        [ForeignKey("Client")]
        public int Client_Id { get; set; }

        public virtual Client Client { get; set; }
    }
}
