using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace DAL
{
    public class WSRE
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("System")]
        public long SystemId { get; set; }
        [ForeignKey("Jobsite")]
        public long JobsiteId { get; set; }
        [ForeignKey("Inspector")]
        public long InspectorId { get; set; }
        public string CustomerReference { get; set; }
        public string JobNumber { get; set; }
        public string OldTagNumber { get; set; }
        public string OverallEval { get; set; }
        public string OverallComment { get; set; }
        public string OverallRecommendation { get; set; }
        public int SystemLife { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public virtual LU_Module_Sub System { get; set; }
        public virtual USER_TABLE Inspector { get; set; }
        public virtual CRSF Jobsite { get; set; }
        public virtual WSREStatusType Status { get; set; }
        public virtual ICollection<WSREComponentRecord> ComponentRecords { get; set; }
        public virtual ICollection<WSREDipTest> DipTests { get; set; }
        public virtual ICollection<WSRECrackTest> CrackTest { get; set; }
        public virtual ICollection<WSREInitialImage> InitialPhotos { get; set; }
    }
}