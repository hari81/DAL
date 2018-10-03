using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace DAL
{
    [Table("SystemFamilyTemplate")]
    public class SystemFamilyTemplate
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Family")]
        [Index("IX_FamilyCompartType", 1, IsUnique = true)]
        public int FamilyId { get; set; }
        [ForeignKey("CompartType")]
        [Index("IX_FamilyCompartType", 2, IsUnique = true)]
        public int CompartTypeId { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public virtual TYPE Family { get; set; }
        public virtual LU_COMPART_TYPE CompartType { get; set; }

        [NotMapped]
        public string TypeName { get; set; }
    }
}