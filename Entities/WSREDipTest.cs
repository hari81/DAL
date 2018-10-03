using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace DAL
{
    public class WSREDipTest
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("WSRE")]
        public int WSREId { get; set; }
        public decimal Measurement { get; set; }
        [ForeignKey("Condition")]
        public int ConditionId { get; set; }
        public string Comment { get; set; }
        public string Recommendation { get; set; }
        public int Number { get; set; }
        public virtual WSRE WSRE { get; set; }
        public virtual WSREDipTestCondition Condition { get; set; }
        public virtual ICollection<WSREDipTestImage> Photos { get; set; }
    }
}