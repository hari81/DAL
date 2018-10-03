namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LU_COMPART
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LU_COMPART()
        {
            CHILD_RELATION_LIST = new HashSet<COMPART_PARENT_RELATION>();
            PARENT_RELATION_LIST = new HashSet<COMPART_PARENT_RELATION>();
            COMPART_TOOL_IMAGE = new HashSet<COMPART_TOOL_IMAGE>();
            GENERAL_EQ_UNIT = new HashSet<GENERAL_EQ_UNIT>();
            LU_COMPART_PARTS = new HashSet<LU_COMPART_PARTS>();
            LU_GET_COMPART_SUB_TYPE = new HashSet<LU_GET_COMPART_SUB_TYPE>();
            TRACK_COMPART_EXT = new HashSet<TRACK_COMPART_EXT>();
            TRACK_COMPART_WORN_LIMIT_CAT = new HashSet<TRACK_COMPART_WORN_LIMIT_CAT>();
            TRACK_COMPART_WORN_LIMIT_ITM = new HashSet<TRACK_COMPART_WORN_LIMIT_ITM>();
        }

        [Key]
        public int compartid_auto { get; set; }

        [Required]
        [StringLength(20)]
        public string compartid { get; set; }

        [Required]
        [StringLength(50)]
        public string compart { get; set; }

        public int? smcs_code { get; set; }

        [StringLength(20)]
        public string modifier_code { get; set; }

        public int? hrs { get; set; }

        public byte progid { get; set; }

        public bool? Left { get; set; }

        public int? parentid_auto { get; set; }

        [StringLength(10)]
        public string parentid { get; set; }

        public short? childoptid { get; set; }

        public bool? multiple { get; set; }

        public int? fixedamount { get; set; }

        public long? implement_auto { get; set; }

        public bool? core { get; set; }

        [StringLength(10)]
        public string group_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? expected_life { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? expected_cost { get; set; }

        public int comparttype_auto { get; set; }

        [StringLength(50)]
        public string companyname { get; set; }

        public short sumpcapacity { get; set; }

        public short max_rebuilt { get; set; }

        public short oilsample_interval { get; set; }

        public short oilchg_interval { get; set; }

        public bool? insp_item { get; set; }

        public short? insp_interval { get; set; }

        public short? insp_uom { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(50)]
        public string created_user { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(50)]
        public string modified_user { get; set; }

        public short? bowldisplayorder { get; set; }

        public short? track_comp_row { get; set; }

        [StringLength(5)]
        public string track_comp_cts_maintype { get; set; }

        [StringLength(5)]
        public string track_comp_cts_subtype { get; set; }

        [StringLength(1000)]
        public string compart_note { get; set; }

        public int? sorder { get; set; }

        [StringLength(100)]
        public string hydraulic_inspect_symptoms { get; set; }

        public int? cs_compart_auto { get; set; }

        public int? positionid_auto { get; set; }

        public bool? allow_duplicate { get; set; }

        public bool AcceptEvalAsReading { get; set; }

        public long? standard_compartid_auto { get; set; }

        public int? ranking_auto { get; set; }

        [InverseProperty("ParentCompartment")]
        public virtual ICollection<COMPART_PARENT_RELATION> CHILD_RELATION_LIST { get; set; }

        [InverseProperty("ChildCompartment")]
        public virtual ICollection<COMPART_PARENT_RELATION> PARENT_RELATION_LIST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMPART_TOOL_IMAGE> COMPART_TOOL_IMAGE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GENERAL_EQ_UNIT> GENERAL_EQ_UNIT { get; set; }

        public virtual LU_COMPART_TYPE LU_COMPART_TYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LU_COMPART_PARTS> LU_COMPART_PARTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LU_GET_COMPART_SUB_TYPE> LU_GET_COMPART_SUB_TYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACK_COMPART_EXT> TRACK_COMPART_EXT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACK_COMPART_WORN_LIMIT_CAT> TRACK_COMPART_WORN_LIMIT_CAT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACK_COMPART_WORN_LIMIT_ITM> TRACK_COMPART_WORN_LIMIT_ITM { get; set; }
        public virtual ICollection<COMPART_MEASUREMENT_POINT> MeasurementPoints { get; set; }
    }
}
