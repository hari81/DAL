namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class COMP_Inventory_Inspec_Details
    {
        public long Id { get; set; }

        public long equnit_Id { get; set; }

        public decimal? reading { get; set; }

        public decimal? worn_percentage { get; set; }

        [StringLength(1)]
        public string eval_code { get; set; }

        public int? tool_Id { get; set; }

        public DateTime? InsertDate { get; set; }

        public long UserId { get; set; }

        public virtual GENERAL_EQ_UNIT GENERAL_EQ_UNIT { get; set; }

        public virtual TRACK_TOOL TRACK_TOOL { get; set; }

        public virtual USER_TABLE USER_TABLE { get; set; }
    }
}
