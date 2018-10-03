using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DAL
{
    [Table("DealershipBranding")]
    public class DealershipBranding
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Dealership")]
        public int DealershipId { get; set; }
        [ForeignKey("ApplicationStyle")]
        public int ApplicationStyleId { get; set; }
        public byte[] DealershipLogo { get; set; }
        [MaxLength(450,ErrorMessage = "Length must be less than 450")]
        [Index(IsUnique = true)]
        public string IdentityHost { get; set; }
        [MaxLength(450, ErrorMessage = "Length must be less than 450")]
        [Index(IsUnique = true)]
        public string UCHost { get; set; }
        [MaxLength(450, ErrorMessage = "Length must be less than 450")]
        [Index(IsUnique = true)]
        public string UCUIHost { get; set; }
        [MaxLength(450, ErrorMessage = "Length must be less than 450")]
        [Index(IsUnique = true)]
        public string GETHost { get; set; }
        [MaxLength(450, ErrorMessage = "Length must be less than 450")]
        [Index(IsUnique = true)]
        public string GETUIHost { get; set; }
        public string LogoutRedirectUrl { get; set; }
        public string HelpCentreUrl { get; set; }
        public virtual Dealership Dealership { get; set; }
        public virtual ApplicationStyle ApplicationStyle { get; set; }
    }
}