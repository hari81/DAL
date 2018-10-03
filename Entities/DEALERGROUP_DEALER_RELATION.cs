using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("DEALERGROUP_DEALER_RELATION")]
    public class DEALERGROUP_DEALER_RELATION
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("DealerGroup")]
        public int DealerGroupId { get; set; }
        [ForeignKey("Dealer")]
        public int DealerId { get; set; }

        public virtual DEALER_GROUP DealerGroup { get; set; }
        public virtual Dealership Dealer { get; set; }

        [ForeignKey("AddedByUser")]
        public long? AddedByUserId { get; set; }
        public DateTime? AddedDate { get; set; }
        public virtual USER_TABLE AddedByUser { get; set; }

        [ForeignKey("ModifiedByUser")]
        public long? ModifiedByUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual USER_TABLE ModifiedByUser { get; set; }

        public int RecordStatus { get; set; }
    }
}