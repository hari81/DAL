using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace DAL
{
    public class WSREComponentImage
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ComponentRecord")]
        public int ComponentRecordId { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public byte[] Data { get; set; }
        public bool IncludeInReport { get; set; }
        public bool Deleted { get; set; }
        public virtual WSREComponentRecord ComponentRecord { get; set; }
    }
}