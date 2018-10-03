namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GET_REPAIRER
    {
        [Key]
        public int repairer_auto { get; set; }

        public string name { get; set; }

        [ForeignKey("customer")]
        public long customer_auto { get; set; }

        //public string address_line1;

        //public string address_line2;

        //public string suburb;

        //public string city;

        //public int postcode;

        //public string country;

        //public string phone_number;

        //public string email;

        public virtual CUSTOMER customer { get; set; }
    }
}