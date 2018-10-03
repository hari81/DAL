namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRACK_INSPECTION_IMAGES
    {
        [Key]
        public long ID { get; set; }

        public Guid? GUID { get; set; }

        [StringLength(10)]
        public string inspection_detail_auto { get; set; }

        public byte[] image_data { get; set; }

        public string image_comment { get; set; }

        public string image_title { get; set; }

        public int? InspectionDetailId { get; set; }

        public virtual TRACK_INSPECTION_DETAIL TRACK_INSPECTION_DETAIL { get; set; }
    }
}
