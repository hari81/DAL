using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL
{
    [Table("COMPART_MEASUREMENT_POINT")]
    public class COMPART_MEASUREMENT_POINT
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Compart")]
        public int CompartId { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        public int Order { get; set; }
        public int DefaultNumberOfMeasurements { get; set; } = 1;
        public byte[] Image { get; set; }
        public bool Disabled { get; set; }
        [ForeignKey("DefaultTool")]
        public int? DefaultToolId { get; set; }
        public virtual TRACK_TOOL DefaultTool { get; set; }
        public virtual LU_COMPART Compart { get; set; }
        public virtual ICollection<MEASUREMENT_POSSIBLE_TOOLS> PossibleTools { get; set; }
    }
}