namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LANGUAGE")]
    public partial class LANGUAGE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte language_auto { get; set; }

        [Column("language")]
        [Required]
        [StringLength(50)]
        public string Fulllanguage { get; set; }
    }
}
