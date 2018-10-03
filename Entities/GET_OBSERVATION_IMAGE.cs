namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_OBSERVATION_IMAGE
    {
        [Key]
        public int image_auto { get; set; }

        public int results_auto { get; set; }

        public byte[] observation_photo { get; set; }

        public virtual GET_OBSERVATION_RESULTS GET_OBSERVATION_RESULTS { get; set; }
    }
}
