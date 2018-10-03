

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class DealershipQuoteReports
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Dealership")]
        [Index("IX_DealershipQuoteReport", 1, IsUnique = true)]
        public int DealershipId { get; set; }
        [ForeignKey("QuoteReport")]
        [Index("IX_DealershipQuoteReport", 2, IsUnique = true)]
        public int QuoteReportId { get; set; }


        public virtual Dealership Dealership { get; set; }
        public virtual LU_QuoteReport QuoteReport { get; set; }
    }
}