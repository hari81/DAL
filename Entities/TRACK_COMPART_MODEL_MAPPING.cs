namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRACK_COMPART_MODEL_MAPPING
    {
        [Key]
        public int compart_model_mapping_auto { get; set; }
        [ForeignKey("Compart")]
        public int compartid_auto { get; set; }
        [ForeignKey("Model")]
        public int model_auto { get; set; }
        public virtual LU_COMPART Compart { get; set; }
        public virtual MODEL Model { get; set; }
    }
}
