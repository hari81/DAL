using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("SEARCH_ITEM")]
    public class SEARCH_ITEM
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("DashboardSearch")]
        public int DashboradSearchId { get; set; }
        public int ItemId { get; set; }
        public string Title { get; set; }
        public int SearchId { get; set; }
        public string SearchStr { get; set; }
        public virtual DASHBOARD_SEARCH DashboardSearch { get; set; }
    }
}