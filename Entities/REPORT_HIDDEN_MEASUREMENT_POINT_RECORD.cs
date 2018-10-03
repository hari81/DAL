using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DAL
{
    public class REPORT_HIDDEN_MEASUREMENT_POINT_RECORD
    {
        public REPORT_HIDDEN_MEASUREMENT_POINT_RECORD()
        {
            hideReadings = true;
            hideAll = false;
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("CompartMeasurementPoint")]
        public int CompartMeasurementPointId { get; set; }

        [ForeignKey("Report")]
        public int ReportId { get; set; }

        public bool hideReadings { get; set; }

        public bool hideAll { get; set; }

        public virtual MININGSHOVEL_REPORT Report { get; set; }

        public virtual COMPART_MEASUREMENT_POINT CompartMeasurementPoint { get; set; }
    }
}



