namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class GET_OBSERVATION_POINT_IMAGES
    {
        [Key]
        public int image_auto { get; set; }

        public int results_auto { get; set; }

        public byte[] observation_photo { get; set; }

        [ForeignKey("results_auto")]
        public virtual GET_OBSERVATION_POINT_RESULTS GET_OBSERVATION_POINT_RESULTS { get; set; }
    }
}