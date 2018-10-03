namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER_CRSF_CUST_EQUIP
    {
        [Key]
        public long user_assign_auto { get; set; }
        //[ForeignKey("USER_TABLE")]
        public long user_auto { get; set; }
        //[ForeignKey("CUSTOMER")]
        public long customer_auto { get; set; }
        //[ForeignKey("CRSF")]
        public long? crsf_auto { get; set; }
        //[ForeignKey("EQUIPMENT")]
        public long? equipmentid_auto { get; set; }

        public byte? level_type { get; set; }

        public bool? keep_with_equip { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(50)]
        public string modified_user { get; set; }

        public long? modified_user_auto { get; set; }

        public virtual CRSF CRSF { get; set; }

        public virtual CUSTOMER CUSTOMER { get; set; }

        public virtual EQUIPMENT EQUIPMENT { get; set; }

        public virtual USER_TABLE USER_TABLE { get; set; }
    }
}
