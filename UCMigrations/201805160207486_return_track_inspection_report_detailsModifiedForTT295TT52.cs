namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class return_track_inspection_report_detailsModifiedForTT295TT52 : DbMigration
    {
        public override void Up()
        {
            Sql(@"

ALTER PROCEDURE[dbo].[return_track_inspection_report_details]
        @quote_auto INT
AS
BEGIN
      SET NOCOUNT ON;
      SELECT tq.quote_name AS[UCReportID],
            cu.cust_name AS [Customer],
            cu.custid AS [CustomerID],
            cu.logo AS CustomerLogo,
            crsf.site_name AS [Jobsite],
            CONVERT(NVARCHAR, ti.inspection_date, 106) AS[InspectDate],
            ti.examiner AS[Inspector],
            make.makedesc AS[Make],
            model.modeldesc AS[Model],
            eq.serialno AS[SerialNo],
            eq.unitno AS[UnitNo],
            --eq.currentsmu AS[CurrentSMU],
            ti.smu AS[CurrentSMU],
            ti.track_sag_left AS[TrackSagLeft],
            ti.track_sag_right AS[TrackSagRight],
            ti.dry_joints_left AS[NoDryJointsLeft],
            ti.dry_joints_right AS[NoDryJointsRight],
            ti.ext_cannon_left AS[ExtCannonLeft],
            ti.ext_cannon_right AS[ExtCannonRight],
            CASE ti.impact WHEN 0 THEN 'Low' WHEN 1 THEN 'Moderate' WHEN 2 THEN 'High' ELSE 'Invalid' END AS[Impact],
            CASE ti.abrasive WHEN 0 THEN 'Low' WHEN 1 THEN 'Moderate' WHEN 2 THEN 'High' ELSE 'Invalid' END AS[Abrasive],
            CASE ti.moisture WHEN 0 THEN 'Low' WHEN 1 THEN 'Moderate' WHEN 2 THEN 'High' ELSE 'Invalid' END AS[Moisture],
            CASE ti.packing WHEN 0 THEN 'Low' WHEN 1 THEN 'Moderate' WHEN 2 THEN 'High' ELSE 'Invalid' END AS[Packing],
            ti.allowableWear AS[BrushingAllowableWear],
            --REPLACE(REPLACE(RTRIM(LTRIM(ti.eval_comment)),CHAR(13),''),'<br>','') AS[OverallComments],
			dbo.fn_sampleRemoveHTMLFromText(ti.eval_comment) as OverallComments,
            ti.evalcode AS[EvalCode],
            ti.inspection_comments as [InspectionComments],
            ti.Jobsite_Comms as [JobsiteComments],
			ti.LeftTrackSagComment,
			ti.RightTrackSagComment,
			ti.LeftCannonExtensionComment,
			ti.RightCannonExtensionComment,
			ti.LeftTrackSagImage,
			ti.RightTrackSagImage,
			ti.LeftCannonExtensionImage,
			ti.RightCannonExtensionImage,
			ti.ForwardTravelHours,
			ti.ReverseTravelHours,
			ti.LeftScallopMeasurement,
			ti.RightScallopMeasurement
        FROM TRACK_QUOTE tq INNER JOIN
             TRACK_INSPECTION ti ON ti.inspection_auto = tq.inspection_auto INNER JOIN
              EQUIPMENT eq ON eq.equipmentid_auto = ti.equipmentid_auto INNER JOIN
              LU_MMTA mmta ON mmta.mmtaid_auto = eq.mmtaid_auto INNER JOIN
              MAKE make ON make.make_auto = mmta.make_auto INNER JOIN
              MODEL model ON mmta.model_auto = model.model_auto INNER JOIN
              CRSF crsf ON crsf.crsf_auto = eq.crsf_auto INNER JOIN
              CUSTOMER cu ON cu.customer_auto = crsf.customer_auto
              LEFT JOIN FLUID_REPORT_CUSTOMER_LOGO frcl on cu.customer_auto = frcl.customer_auto
              LEFT JOIN FLUID_REPORT_LOGO frl on frcl.logo_auto = frcl.logo_auto
              LEFT JOIN DB_EQUIPMENT_INTERPRETATION dei ON eq.equipmentid_auto = dei.equipmentid_auto
      -- INNER JOIN EQ_UNIT_ATTACHMENTS_FILESTREAM att ON eq.equipmentid_auto = att.equipmentid_auto
WHERE tq.quote_auto = @quote_auto
END


");
        }
        
        public override void Down()
        {

            Sql(@"

ALTER PROCEDURE[dbo].[return_track_inspection_report_details]
        @quote_auto INT
AS
BEGIN
      SET NOCOUNT ON;
      SELECT tq.quote_name AS[UCReportID],
            cu.cust_name AS [Customer],
            cu.custid AS [CustomerID],
            cu.logo AS CustomerLogo,
            crsf.site_name AS [Jobsite],
            CONVERT(NVARCHAR, ti.inspection_date, 106) AS[InspectDate],
            ti.examiner AS[Inspector],
            make.makedesc AS[Make],
            model.modeldesc AS[Model],
            eq.serialno AS[SerialNo],
            eq.unitno AS[UnitNo],
            --eq.currentsmu AS[CurrentSMU],
            ti.smu AS[CurrentSMU],
            ti.track_sag_left AS[TrackSagLeft],
            ti.track_sag_right AS[TrackSagRight],
            ti.dry_joints_left AS[NoDryJointsLeft],
            ti.dry_joints_right AS[NoDryJointsRight],
            ti.ext_cannon_left AS[ExtCannonLeft],
            ti.ext_cannon_right AS[ExtCannonRight],
            CASE ti.impact WHEN 0 THEN 'Low' WHEN 1 THEN 'Moderate' WHEN 2 THEN 'High' ELSE 'Invalid' END AS[Impact],
            CASE ti.abrasive WHEN 0 THEN 'Low' WHEN 1 THEN 'Moderate' WHEN 2 THEN 'High' ELSE 'Invalid' END AS[Abrasive],
            CASE ti.moisture WHEN 0 THEN 'Low' WHEN 1 THEN 'Moderate' WHEN 2 THEN 'High' ELSE 'Invalid' END AS[Moisture],
            CASE ti.packing WHEN 0 THEN 'Low' WHEN 1 THEN 'Moderate' WHEN 2 THEN 'High' ELSE 'Invalid' END AS[Packing],
            ti.allowableWear AS[BrushingAllowableWear],
            --REPLACE(REPLACE(RTRIM(LTRIM(ti.eval_comment)),CHAR(13),''),'<br>','') AS[OverallComments],
			dbo.fn_sampleRemoveHTMLFromText(ti.eval_comment) as OverallComments,
            ti.evalcode AS[EvalCode],
            ti.inspection_comments as [InspectionComments],
            ti.Jobsite_Comms as [JobsiteComments]
        FROM TRACK_QUOTE tq INNER JOIN
             TRACK_INSPECTION ti ON ti.inspection_auto = tq.inspection_auto INNER JOIN
              EQUIPMENT eq ON eq.equipmentid_auto = ti.equipmentid_auto INNER JOIN
              LU_MMTA mmta ON mmta.mmtaid_auto = eq.mmtaid_auto INNER JOIN
              MAKE make ON make.make_auto = mmta.make_auto INNER JOIN
              MODEL model ON mmta.model_auto = model.model_auto INNER JOIN
              CRSF crsf ON crsf.crsf_auto = eq.crsf_auto INNER JOIN
              CUSTOMER cu ON cu.customer_auto = crsf.customer_auto
              LEFT JOIN FLUID_REPORT_CUSTOMER_LOGO frcl on cu.customer_auto = frcl.customer_auto
              LEFT JOIN FLUID_REPORT_LOGO frl on frcl.logo_auto = frcl.logo_auto
              LEFT JOIN DB_EQUIPMENT_INTERPRETATION dei ON eq.equipmentid_auto = dei.equipmentid_auto
      -- INNER JOIN EQ_UNIT_ATTACHMENTS_FILESTREAM att ON eq.equipmentid_auto = att.equipmentid_auto
WHERE tq.quote_auto = @quote_auto
END


");

        }
    }
}
