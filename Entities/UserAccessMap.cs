namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserAccessMaps
    {
        [Key]
        public int UserAccessMapId { get; set; }

        public long? user_auto { get; set; }

        public int? DealershipId { get; set; }

        public long? customer_auto { get; set; }

        public long? crsf_auto { get; set; }

        public long? equipmentid_auto { get; set; }

        public int AccessLevelTypeId { get; set; }

        public virtual AccessLevelType AccessLevelType { get; set; }

        public virtual CRSF CRSF { get; set; }

        public virtual CUSTOMER CUSTOMER { get; set; }

        public virtual Dealership Dealership { get; set; }

        public virtual EQUIPMENT EQUIPMENT { get; set; }

        public virtual USER_TABLE USER_TABLE { get; set; }
    }
}
