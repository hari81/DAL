namespace DAL
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class GET_IMPLEMENT_IMAGE
    {
        [Key]
        public int image_auto { get; set; }

        public int get_auto { get; set; }

        public byte[] attachment { get; set; }

        [ForeignKey("get_auto")]
        public virtual GET GET { get; set; }
    }
}
