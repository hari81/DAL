using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE")]
    public class CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CompartType")]
        public int CompartTypeId { get; set; }
        [ForeignKey("Model")]
        public int? ModelId { get; set; }
        [ForeignKey("Customer")]
        public long? CustomerId { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DefaultNumberOfImages { get; set; } = 1;
        public int RecordStatus { get; set; }
        public virtual LU_COMPART_TYPE CompartType { get; set; }
        public virtual CUSTOMER Customer { get; set; }
        public virtual MODEL Model { get; set; }
    }
}