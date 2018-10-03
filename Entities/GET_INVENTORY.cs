namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class GET_INVENTORY
    {
        [Key]
        public int inventory_auto { get; set; }

        [ForeignKey("GETs")]
        public int get_auto { get; set; }

        [ForeignKey("crsf")]
        public long jobsite_auto { get; set; }

        [ForeignKey("inventory_status")]
        public int status_auto { get; set; }

        public int ltd { get; set; }

        public DateTime modified_date { get; set; }

        public int modified_user { get; set; }

        [ForeignKey("workshop")]
        public int? workshop_auto { get; set; }

        public virtual GET GETs { get; set; }

        public virtual CRSF crsf { get; set; }

        public virtual GET_INVENTORY_STATUS inventory_status { get; set; }

        public virtual GET_WORKSHOP workshop { get; set; }
    }
}