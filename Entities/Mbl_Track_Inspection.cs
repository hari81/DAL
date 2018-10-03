namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mbl_Track_Inspection
    {
        [Key]
        [Column(Order = 0)]
        public int inspection_auto { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long equipmentid_auto { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string examiner { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime inspection_date { get; set; }

        public int? smu { get; set; }

        [StringLength(1000)]
        public string notes { get; set; }

        public decimal? track_sag_left { get; set; }

        public decimal? track_sag_right { get; set; }

        [StringLength(50)]
        public string track_sag_left_status { get; set; }

        [StringLength(50)]
        public string track_sag_right_status { get; set; }

        public decimal? dry_joints_left { get; set; }

        public decimal? dry_joints_right { get; set; }

        public decimal? ext_cannon_left { get; set; }

        public decimal? ext_cannon_right { get; set; }

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

        public DateTime? created_date { get; set; }

        [StringLength(50)]
        public string created_user { get; set; }

        public DateTime? confirmed_date { get; set; }

        [StringLength(50)]
        public string confirmed_user { get; set; }

        [StringLength(1)]
        public string evalcode { get; set; }

        public short? allowableWear { get; set; }

        [StringLength(50)]
        public string uccode { get; set; }

        [StringLength(255)]
        public string uccodedesc { get; set; }

        public DateTime? last_interp_date { get; set; }

        [StringLength(50)]
        public string last_interp_user { get; set; }

        [StringLength(1000)]
        public string eval_comment { get; set; }

        [StringLength(100)]
        public string location { get; set; }

        [StringLength(50)]
        public string docket_no { get; set; }

        [StringLength(50)]
        public string ucbrand { get; set; }

        public byte? wear { get; set; }

        public int? ltd { get; set; }

        [StringLength(1000)]
        public string Jobsite_Comms { get; set; }

        public DateTime? released_date { get; set; }

        [StringLength(100)]
        public string released_by { get; set; }

        public string inspection_comments { get; set; }

        public int? quote_auto { get; set; }
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
        public bool TravelledKms { get; set; }
        public decimal LeftScallopMeasurement { get; set; }
        public decimal RightScallopMeasurement { get; set; }
    }
}
