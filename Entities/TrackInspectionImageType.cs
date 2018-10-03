using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace DAL
{
    public class TrackInspectionImageType
    {
        [Key]
        public int Id { get; set; }
        public string TypeDescription { get; set; }
    }
}