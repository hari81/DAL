using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace DAL
{
    public class WSREComponentRecommendation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ComponentType")]
        public int ValidComponentTypeId { get; set; }
        public string Description { get; set; }
        public virtual LU_COMPART_TYPE ComponentType { get; set; }
    }
}