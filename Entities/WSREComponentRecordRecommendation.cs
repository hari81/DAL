using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace DAL
{
    public class WSREComponentRecordRecommendation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ComponentRecord")]
        public int ComponentRecordId { get; set; }
        [ForeignKey("Recommendation")]
        public int RecommendationId { get; set; }
        public virtual WSREComponentRecord ComponentRecord { get; set; }
        public virtual WSREComponentRecommendation Recommendation { get; set; }
    }
}