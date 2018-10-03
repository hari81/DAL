using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class CUSTOMER_MODEL_MANDATORY_IMAGE
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Model")]
        public int? ModelId { get; set; }
        [ForeignKey("Customer")]
        public long? CustomerId { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DefaultNumberOfImages { get; set; } = 1;
        public int RecordStatus { get; set; }
        public virtual CUSTOMER Customer { get; set; }
        public virtual MODEL Model { get; set; }
        public virtual ICollection<INSPECTION_MANDATORY_IMAGES> InspectionMandatoryImages { get; set; }
    }
}