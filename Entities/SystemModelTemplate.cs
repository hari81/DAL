using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace DAL
{
    [Table("SystemModelTemplate")]
    public class SystemModelTemplate
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Model")]
        [Index("IX_ModelCompartType", 1, IsUnique = true)]
        public int ModelId { get; set; }
        [ForeignKey("CompartType")]
        [Index("IX_ModelCompartType", 2, IsUnique = true)]
        public int CompartTypeId { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public virtual MODEL Model { get; set; }
        public virtual LU_COMPART_TYPE CompartType { get; set; }
    }
}