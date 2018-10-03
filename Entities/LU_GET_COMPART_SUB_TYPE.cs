namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LU_GET_COMPART_SUB_TYPE
    {
        [Key]
        public short get_compart_sub_auto { get; set; }

        public int compartid_auto { get; set; }

        [StringLength(50)]
        public string teeth_size { get; set; }

        public decimal? nl { get; set; }

        public decimal? wl { get; set; }

        [StringLength(50)]
        public string series { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(50)]
        public string modified_user { get; set; }

        [StringLength(50)]
        public string compart { get; set; }

        public virtual LU_COMPART LU_COMPART { get; set; }
    }
}
