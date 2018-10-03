namespace DAL
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class GET_OBSERVATION_POINT_INSPECTION_IMAGES
    {
        [Key]
        public int image_auto { get; set; }

        public int observation_point_inspection_auto { get; set; }

        public byte[] observation_point_photo { get; set; }

        [ForeignKey("observation_point_inspection_auto")]
        public virtual GET_OBSERVATION_POINT_INSPECTION GET_OBSERVATION_POINT_INSPECTION { get; set; }
    }
}
