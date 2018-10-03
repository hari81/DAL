namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GET")]
    public partial class GET
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GET()
        {
            GET_IMPLEMENT_INSPECTION = new HashSet<GET_IMPLEMENT_INSPECTION>();
            IMPLEMENT_READING_ENTRY = new HashSet<IMPLEMENT_READING_ENTRY>();
            on_equipment = true;
            equipmentid_auto = null;
        }

        [Key]
        public int get_auto { get; set; }

        [Required]
        [StringLength(50)]
        public string impserial { get; set; }

        public long? implement_auto { get; set; }

        public long? equipmentid_auto { get; set; }

        public bool? isinuse { get; set; }

        public int? make_auto { get; set; }

        [StringLength(50)]
        public string makeid { get; set; }

        public long? installsmu { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(50)]
        public string created_user { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(50)]
        public string modified_user { get; set; }

        public short? get_linkage_system_auto { get; set; }

        public decimal? bucket_width { get; set; }

        public decimal? base_edge_thickness { get; set; }

        public decimal? eb_bottom_thickness { get; set; }

        public decimal? eb_side_thickness { get; set; }

        public decimal? cutting_edge_thickness { get; set; }

        public decimal? mb_bottom_thickness { get; set; }

        public decimal? mb_rear_thickness { get; set; }

        [StringLength(20)]
        public string bucket_width_uom { get; set; }

        [StringLength(20)]
        public string base_edge_thickness_uom { get; set; }

        public int? num { get; set; }

        public decimal? segment_length { get; set; }

        public int? plates_width { get; set; }

        public int? plates_length { get; set; }

        public int? plates_thickness { get; set; }

        public int? strips_width { get; set; }

        public int? strips_length { get; set; }

        public int? strips_thickness { get; set; }

        public long? feet_type_auto { get; set; }

        [StringLength(50)]
        public string num_feet { get; set; }

        public decimal? start_height { get; set; }

        public decimal? end_height { get; set; }

        public Guid? image_guid { get; set; }

        public long? impsetup_hours { get; set; }

        public bool on_equipment { get; set; }

        public virtual EQUIPMENT EQUIPMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GET_IMPLEMENT_INSPECTION> GET_IMPLEMENT_INSPECTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IMPLEMENT_READING_ENTRY> IMPLEMENT_READING_ENTRY { get; set; }
    }
}
