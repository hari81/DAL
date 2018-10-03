using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL
{
    [Table("COMPARTTYPE_ADDITIONAL_POSSIBLE_TOOLS")]
    public class COMPARTTYPE_ADDITIONAL_POSSIBLE_TOOLS
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CompartTypeAddtional")]
        [Index("IX_CompartTypeAddtionalTool", 1, IsUnique = true)]
        public int CompartTypeAddtionalId { get; set; }
        [ForeignKey("Tool")]
        [Index("IX_CompartTypeAddtionalTool", 2, IsUnique = true)]
        public int ToolId { get; set; }
        public virtual TRACK_TOOL Tool { get; set; }
        public virtual CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL CompartTypeAddtional { get; set; }
    }
}