using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DAL
{
    public class LU_QuoteReport
    {
        [Key]
        public int Id { get; set; }

        public string QuoteReportDesc { get; set; }
        public bool isDefaultOption { get; set; }
    }
}