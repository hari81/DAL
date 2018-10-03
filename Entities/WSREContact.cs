using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace DAL
{
    public class WSREContact
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("WSRE")]
        public int WSREId { get; set; }
        [ForeignKey("User")]
        public long UserId { get; set; }
        public bool EmailSent { get; set; }

        public virtual USER_TABLE User { get; set; }
        public virtual WSRE WSRE { get; set; }
    }
}