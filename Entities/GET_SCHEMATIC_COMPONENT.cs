namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_SCHEMATIC_COMPONENT
    {
        [Key]
        public int schematic_component_auto { get; set; }

        public int schematic_auto { get; set; }

        public int comparttype_auto { get; set; }

        public bool active { get; set; }

        public int positionX { get; set; }

        public int positionY { get; set; }
    }
}
