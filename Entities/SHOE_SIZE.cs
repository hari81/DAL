using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DAL
{
    [Table("SHOE_SIZE")]
    public class SHOE_SIZE
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public float Size { get; set; }
    }
}