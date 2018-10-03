namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class COMPART_ATTACH_FILESTREAM
    {
        public Guid guid { get; set; }

        [Key]
        public long compart_attach_auto { get; set; }

        public long? compartid_auto { get; set; }

        public long? comparttype_auto { get; set; }

        public int? tool_auto { get; set; }

        public int? compart_attach_type_auto { get; set; }

        public long? user_auto { get; set; }

        public DateTime? entry_date { get; set; }

        [StringLength(2000)]
        public string comment { get; set; }

        [StringLength(100)]
        public string attachment_name { get; set; }

        public byte[] attachment { get; set; }

        public int? inspection_auto { get; set; }

        public int? position { get; set; }

        public virtual COMPART_ATTACH_TYPE COMPART_ATTACH_TYPE { get; set; }
    }
}
