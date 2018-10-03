using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace DAL
{
    public class WSRECrackTest
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("WSRE")]
        public int WSREId { get; set; }
        public bool TestPassed { get; set; }
        public string Comment { get; set; }
        public virtual WSRE WSRE { get; set; }
        public virtual ICollection<WSRECrackTestImage> Photos { get; set; }
    }
}