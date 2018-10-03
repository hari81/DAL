using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("DEALER_GROUP")]
    public class DEALER_GROUP
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        public virtual ICollection<USER_DEALERGROUP_RELATION> Users { get; set; }
        public virtual ICollection<DEALERGROUP_DEALER_RELATION> Dealers { get; set; }
        public virtual ICollection<DEALERGROUP_CUSTOMER_RELATION> Customers { get; set; }
    }
}