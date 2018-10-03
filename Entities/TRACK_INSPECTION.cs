namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRACK_INSPECTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRACK_INSPECTION()
        {
            TRACK_ACTION = new HashSet<TRACK_ACTION>();
            TRACK_INSPECTION_DETAIL = new HashSet<TRACK_INSPECTION_DETAIL>();
        }

        [Key]
        public int inspection_auto { get; set; }

        public long equipmentid_auto { get; set; }

        [Required]
        [StringLength(50)]
        public string examiner { get; set; }

        public DateTime inspection_date { get; set; }

        public int? smu { get; set; }

        [StringLength(1)]
        public string evalcode { get; set; }

        [StringLength(1000)]
        public string notes { get; set; }

        public decimal? track_sag_left { get; set; }

        public decimal? track_sag_right { get; set; }

        [StringLength(50)]
        public string track_sag_left_status { get; set; }

        [StringLength(50)]
        public string track_sag_right_status { get; set; }

        public decimal? dry_joints_left { get; set; }
        public byte[] DryJointsLeftImage { get; set; }
        public string LeftDryJointComments { get; set; }
        public decimal? dry_joints_right { get; set; }
        public byte[] DryJointsRightImage { get; set; }
        public string RightDryJointComments { get; set; }


        public decimal? frame_ext_left { get; set; }

        public decimal? frame_ext_right { get; set; }

        [StringLength(50)]
        public string sprocket_left_status { get; set; }

        [StringLength(50)]
        public string sprocket_right_status { get; set; }

        public short? impact { get; set; }

        public short? abrasive { get; set; }

        public short? moisture { get; set; }

        public short? packing { get; set; }

        public short? allowableWear { get; set; }

        [StringLength(50)]
        public string uccode { get; set; }

        [StringLength(255)]
        public string uccodedesc { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(50)]
        public string created_user { get; set; }

        public DateTime? confirmed_date { get; set; }

        [StringLength(50)]
        public string confirmed_user { get; set; }

        public DateTime? last_interp_date { get; set; }

        [StringLength(50)]
        public string last_interp_user { get; set; }

        [StringLength(2000)]
        public string eval_comment { get; set; }

        [StringLength(100)]
        public string location { get; set; }

        [StringLength(50)]
        public string docket_no { get; set; }

        [StringLength(50)]
        public string ucbrand { get; set; }

        public byte? wear { get; set; }

        public int? ltd { get; set; }

        [StringLength(2000)]
        public string Jobsite_Comms { get; set; }

        public DateTime? released_date { get; set; }

        [StringLength(100)]
        public string released_by { get; set; }

        public string inspection_comments { get; set; }

        public int? quote_auto { get; set; }

        public decimal? ext_cannon_left { get; set; }

        public decimal? ext_cannon_right { get; set; }
        public string LeftTrackSagComment { get; set; }
        public byte[] LeftTrackSagImage { get; set; }
        public string RightTrackSagComment { get; set; }
        public byte[] RightTrackSagImage { get; set; }
        public string LeftCannonExtensionComment { get; set; }
        public byte[] LeftCannonExtensionImage { get; set; }
        public string RightCannonExtensionComment { get; set; }
        public byte[] RightCannonExtensionImage { get; set; }
        public int ForwardTravelHours { get; set; }
        public int ReverseTravelHours { get; set; }
        public int ForwardTravelKm { get; set; }
        public int ReverseTravelKm { get; set; }
        public bool TravelledKms { get; set; }
        public decimal LeftScallopMeasurement { get; set; }
        public byte[] LeftScallopImage { get; set; }
        public string LeftScallopComments { get; set; }
        public decimal RightScallopMeasurement { get; set; }
        public byte[] RightScallopImage { get; set; }
        public string RightScallopComments { get; set; }
        public long? ActionHistoryId { get; set; }
        [ForeignKey("ActionTakenHistory")]
        public virtual ACTION_TAKEN_HISTORY ActionTakenHistory { get; set; }

        public virtual EQUIPMENT EQUIPMENT { get; set; }

        [StringLength(500)]
        public string CustomerContact { get; set; }
        public int? TrammingHours { get; set; }
        [StringLength(1000)]
        public string GeneralNotes { get; set; }

        public int? LeftShoeNo { get; set; }
        public int? RightShoeNo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACK_ACTION> TRACK_ACTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACK_INSPECTION_DETAIL> TRACK_INSPECTION_DETAIL { get; set; }
        public virtual ICollection<INSPECTION_COMPARTTYPE_RECORD> CompartTypeAdditionals { get; set; }
        public virtual ICollection<INSPECTION_COMPARTTYPE_RECORD_IMAGES> CompartTypeAdditionalImages { get; set; }
        public virtual ICollection<INSPECTION_MANDATORY_IMAGES> InspectionMandatoryImages { get; set; }
        public virtual ICollection<INSPECTION_COMPARTTYPE_IMAGES> InspectionCompartTypeImages { get; set; }
        public virtual ICollection<TRACK_QUOTE> Quotes { get; set; }
    }
}
