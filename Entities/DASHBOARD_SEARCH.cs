using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("DASHBOARD_SEARCH")]
    public class DASHBOARD_SEARCH
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 0 -> Fleet View
        /// 1 -> Component View
        /// </summary>
        public int ViewId { get; set; }
        public string Html { get; set; }
        public string Element { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int _clientReqId { get; set; }
        public string memberName { get; set; }
        public string sortName { get; set; }
        public bool ascendingOrder { get; set; }
        public virtual ICollection<SEARCH_ITEM> SearchItems { get; set; }
    }
}