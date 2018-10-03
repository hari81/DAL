using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace DAL
{
    [Table("CustomerReports")]
    public class CustomerReports
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Customer")]
        [Index("IX_CustomerReport", 1, IsUnique = true)]
        public long CustomerId { get; set; }
        [ForeignKey("Report")]
        [Index("IX_CustomerReport", 2, IsUnique = true)]
        public int ReportId { get; set; }
        public virtual CUSTOMER Customer { get; set; }
        public virtual FLUID_REPORT_LU_REPORTS Report { get; set; }
    }
}