using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL")]
    public class CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CompartType")]
        public int CompartTypeId { get; set; }
        [ForeignKey("Model")]
        public int? ModelId { get; set; }
        [ForeignKey("Customer")]
        public long? CustomerId { get; set; }
        [ForeignKey("Family")]
        public int? FamilyId { get; set; }
        [ForeignKey("AdditionalType")]
        public int AdditionalTypeId { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DefaultNumberOfReadings { get; set; } = 1;
        [ForeignKey("DefaultTool")]
        public int? DefaultToolId { get; set; }
        public int RecordStatus { get; set; }
        public virtual TRACK_TOOL DefaultTool { get; set; }
        public virtual LU_COMPART_TYPE CompartType { get; set; }
        public virtual CUSTOMER Customer { get; set; }
        public virtual MODEL Model { get; set; }
        public virtual TYPE Family { get; set; }
        public virtual COMPARTTYPE_ADDITIONAL_TYPE AdditionalType { get; set; }
        public virtual ICollection<COMPARTTYPE_ADDITIONAL_POSSIBLE_TOOLS> PossibleTools { get; set; }
    }
}

///Priority -> 
/// If there is any record with CompartTypeId, CustomerId and ModelId then we load just those columns
/// if there is any record with CompartTypeId and CustomerId then we load just those only
/// if there is any record with CompartTypeId and modelId then we load just those only
/// it there is none of the above then we load records for the comparttypeId only