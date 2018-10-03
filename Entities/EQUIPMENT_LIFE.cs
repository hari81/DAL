namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("EQUIPMENT_LIFE")]
    public partial class EQUIPMENT_LIFE
    {
        public long Id { get; set; }
        [Required]
        public long EquipmentId { get; set; }
        [Required]
        public long ActionId { get; set; }

        public long UserId { get; set; }

        public DateTime ActionDate { get; set; }

        public int SerialMeterReading { get; set; }

        public int ActualLife { get; set; }

        public string Title { get; set; }

        [ForeignKey("EquipmentId")]
        public virtual EQUIPMENT Equipment { get; set; }
        [ForeignKey("ActionId")]
        public virtual ACTION_TAKEN_HISTORY Action { get; set; }
        [ForeignKey("UserId")]
        public virtual USER_TABLE User { get; set; }
    }
}
