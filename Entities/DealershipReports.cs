using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace DAL
{
    [Table("DealershipReports")]
    public class DealershipReports
    {
       
        [Key]
        public int Id { get; set; }
        [ForeignKey("Dealership")]
        [Index("IX_DealershipReport", 1, IsUnique = true)]
        public int DealershipId { get; set; }
        [ForeignKey("Report")]
        [Index("IX_DealershipReport", 2, IsUnique = true)]
        public int ReportId { get; set; }
        public virtual Dealership Dealership { get; set; }
        public virtual FLUID_REPORT_LU_REPORTS Report { get; set; }
        
        
    }
}