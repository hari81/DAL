namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VERSION")]
    public partial class VERSION
    {
        [Key]
        [Column(Order = 0)]
        public DateTime InstallDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string VersionNo { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string UpdatedBy { get; set; }

        [StringLength(1000)]
        public string Comment { get; set; }

        [StringLength(50)]
        public string dbVersion { get; set; }

        public DateTime? dbDate { get; set; }

        public DateTime? appDate { get; set; }

        [StringLength(10)]
        public string MailService { get; set; }

        public DateTime? MailServiceDateUpdated { get; set; }

        [StringLength(10)]
        public string PrintTool { get; set; }

        public DateTime? PrintToolDateUpdated { get; set; }

        [StringLength(10)]
        public string IFTLab { get; set; }

        public DateTime? IFTLabDateUpdated { get; set; }
    }
}
