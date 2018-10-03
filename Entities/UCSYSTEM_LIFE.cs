namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("UCSYSTEM_LIFE")]
    public partial class SystemLife
    {
        public long Id { get; set; }
        [ForeignKey("LU_Module_Sub")]
        public long SystemId { get; set; }

        public long ActionId { get; set; }

        public long UserId { get; set; }

        public DateTime ActionDate { get; set; }

        public int ActualLife { get; set; }

        public string Title { get; set; }

        public virtual ACTION_TAKEN_HISTORY ACTION_TAKEN_HISTORY { get; set; }

        public virtual LU_Module_Sub LU_Module_Sub { get; set; }

        public virtual USER_TABLE USER_TABLE { get; set; }
    }
}
