namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_IMPLEMENT_INSPECTION_IMAGE
    {
        [Key]
        public int image_auto { get; set; }

        public int inspection_auto { get; set; }

        public int parameter_type { get; set; }

        public byte[] inspection_photo { get; set; }

        public virtual GET_IMPLEMENT_INSPECTION GET_IMPLEMENT_INSPECTION { get; set; }

        public virtual GET_INSPECTION_PARAMETERS GET_INSPECTION_PARAMETERS { get; set; }
    }
}
