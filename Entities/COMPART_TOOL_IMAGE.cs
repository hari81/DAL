namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class COMPART_TOOL_IMAGE
    {
        public int Id { get; set; }

        public int CompartId { get; set; }

        public int ToolId { get; set; }

        public string Title { get; set; }

        public byte[] ImageData { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ImageType { get; set; }

        public virtual LU_COMPART LU_COMPART { get; set; }

        public virtual TRACK_TOOL Tool { get; set; }
    }
}
