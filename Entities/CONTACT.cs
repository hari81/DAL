namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTACTS")]
    public partial class CONTACT
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long equipmentid_auto { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long customer_auto { get; set; }

        [Key]
        [ForeignKey("User")]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long user_auto { get; set; }

        public bool EvalA { get; set; }

        public bool EvalB { get; set; }

        public bool EvalC { get; set; }

        public bool EvalX { get; set; }

        public bool wty_letter { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(20)]
        public string Type { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long crsf_auto { get; set; }

        public DateTime? modified_date { get; set; }

        public long? modified_user { get; set; }

        public bool service { get; set; }

        public bool eq_health { get; set; }

        public bool? eq_undercarriage { get; set; }

        public virtual USER_TABLE User { get; set; }
    }
}
