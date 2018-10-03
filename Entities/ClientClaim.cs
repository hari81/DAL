namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ClientClaim
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Type { get; set; }

        [Required]
        [StringLength(250)]
        public string Value { get; set; }
        [ForeignKey("Client")]
        public int Client_Id { get; set; }

        public virtual Client Client { get; set; }
    }
}
