using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace DAL
{
    public class TEMP_UPLOAD_IMAGE
    {
        [Key]
        public int Id { get; set; }
        public int? UploadInspectionId { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public DateTime? UploadDate { get; set; }
    }
}