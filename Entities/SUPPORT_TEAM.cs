using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("SUPPORT_TEAM")]
    public class SUPPORT_TEAM
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        public virtual ICollection<USER_SUPPORTTEAM_RELATION> Users { get; set; }
    }
}