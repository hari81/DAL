namespace DAL
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class GET_COMPONENT_INSPECTION_IMAGES
    {
        [Key]
        public int image_auto { get; set; }

        public int component_inspection_auto { get; set; }

        public byte[] component_photo { get; set; }

        [ForeignKey("component_inspection_auto")]
        public virtual GET_COMPONENT_INSPECTION GET_COMPONENT_INSPECTION { get; set; }
    }
}
