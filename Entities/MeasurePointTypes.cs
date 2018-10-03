namespace DAL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class MeasurePointTypes
    {
        [Key]
        public int ID { get; set; }

        public string MeasurePointTypeDescription { get; set; }

        public int LUCompartTypeID { get; set; }
    }
}
