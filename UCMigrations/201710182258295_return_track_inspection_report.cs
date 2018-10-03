namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class return_track_inspection_report : DbMigration
    {
        public override void Up()
        {
            Sql(return_track_inspection_report_left);
            Sql(return_track_inspection_report_right);
        }
        
        public override void Down()
        {
        }
        string return_track_inspection_report_left = @"
/****** Object:  StoredProcedure [dbo].[return_track_inspection_report_left]    Script Date: 19/10/2017 9:55:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------
-- Created By:		Mason Based on -> 'return_track_inspection_report' Stored Proc
-- Changed Date:	26 07 2017
-- Reason:			TT-82  and TT-28
---------------------------------
ALTER PROCEDURE[dbo].[return_track_inspection_report_left]
        @quote_auto INT
 AS

 DECLARE @inspection_auto INT
 SELECT @inspection_auto = inspection_auto FROM TRACK_QUOTE WHERE quote_auto = @quote_auto



 SELECT CASE WHEN[dbo].HasComponentAnyParentBasedOnCompart(tid.track_unit_auto) = 0 THEN
       CONVERT(VARCHAR(150), lct.comparttype + ' : ' + lc.compart) ELSE '       ' + lc.compart END AS[Component],
		tu.compartsn AS[CompSerial],
        CASE WHEN[dbo].HasComponentAnyParentBasedOnCompart(tid.track_unit_auto) = 0 THEN CONVERT(VARCHAR(8),tu.smu_at_install) ELSE '-' END AS[SMUInstall],
       tu.date_installed AS[DateInstall],
       CASE WHEN[dbo].HasComponentAnyParentBasedOnCompart(tid.track_unit_auto) = 0 THEN
      CONVERT(VARCHAR(8), tid.hours_on_surface) ELSE '-' END AS[HoursSurface],
      tid.reading AS[Measurement],
      tid.worn_percentage AS[WornPercentage],
      tu.side,
		CASE WHEN[dbo].HasComponentAnyParentBasedOnCompart(tid.track_unit_auto) = 0 THEN
       CONVERT(VARCHAR(8), tid.remaining_hours) ELSE '-' END AS[PotHours100],
       CASE WHEN[dbo].HasComponentAnyParentBasedOnCompart(tid.track_unit_auto) = 0 THEN
      CONVERT(VARCHAR(8), tid.ext_remaining_hours) ELSE '-' END AS[PotHours120],
      tt.tool_name AS[ToolName],
      tid.eval_code AS[EvalCode],
      lct.sorder, lc.comparttype_auto,
		lc.smcs_code,
		lct.comparttype + CASE WHEN tu.pos = 0 THEN '' ELSE ' ' + CONVERT(VARCHAR(2), tu.pos) END AS CompartSide,
		(CASE WHEN(lc.comparttype_auto = 233 OR lc.comparttype_auto = 234) AND tu.pos = 1 THEN 'Front' 

             WHEN lc.comparttype_auto = 233 AND tu.pos = 2 THEN 'Rear'

             WHEN lc.comparttype_auto = 230 OR lc.comparttype_auto = 231 OR lc.comparttype_auto = 232 THEN ' '

             WHEN lc.comparttype_auto = 236 AND tu.pos = 0 THEN ' '

             ELSE CONVERT(VARCHAR(5), tu.pos) END) AS Position,
       lc.compartid AS PartSerialNumber, tu.equnit_auto as CompId
FROM TRACK_INSPECTION ti

        INNER JOIN   TRACK_INSPECTION_DETAIL tid on tid.inspection_auto= ti.inspection_auto
        LEFT JOIN GENERAL_EQ_UNIT tu ON  tid.track_unit_auto = tu.equnit_auto

        INNER JOIN   LU_COMPART lc ON lc.compartid_auto = tu.compartid_auto

        INNER JOIN   LU_COMPART_TYPE lct ON lct.comparttype_auto = lc.comparttype_auto

        INNER JOIN   TRACK_TOOL tt ON tt.tool_auto = tid.tool_auto

        INNER JOIN InspectionDetails_Side tidSide ON InspectionDetailsId = tid.inspection_detail_auto
WHERE tid.inspection_auto = @inspection_auto

    AND tidSide.Side= 1 AND (tid.track_unit_history_auto IS NULL OR (tid.track_unit_history_auto IS NOT NULL AND tu.date_installed<ti.inspection_date))
	 
order by lct.sorder, tu.pos, lc.compartid_auto
";

        string return_track_inspection_report_right = @"
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------
-- Created By:		Mason Based on -> 'return_track_inspection_report' Stored Proc
-- Changed Date:	26 07 2017
-- Reason:			TT-82  and TT-28
---------------------------------
ALTER PROCEDURE[dbo].[return_track_inspection_report_right]
        @quote_auto INT
 AS

 DECLARE @inspection_auto INT
 SELECT @inspection_auto = inspection_auto FROM TRACK_QUOTE WHERE quote_auto = @quote_auto



 SELECT CASE WHEN[dbo].HasComponentAnyParentBasedOnCompart(tid.track_unit_auto) = 0 THEN
       CONVERT(VARCHAR(150), lct.comparttype + ' : ' + lc.compart) ELSE '       ' + lc.compart END AS[Component],
		tu.compartsn AS[CompSerial],
        CASE WHEN[dbo].HasComponentAnyParentBasedOnCompart(tid.track_unit_auto) = 0 THEN CONVERT(VARCHAR(8),tu.smu_at_install) ELSE '-' END AS[SMUInstall],
       tu.date_installed AS[DateInstall],
       CASE WHEN[dbo].HasComponentAnyParentBasedOnCompart(tid.track_unit_auto) = 0 THEN
      CONVERT(VARCHAR(8), tid.hours_on_surface) ELSE '-' END AS[HoursSurface],
      tid.reading AS[Measurement],
      tid.worn_percentage AS[WornPercentage],
      tu.side,
		CASE WHEN[dbo].HasComponentAnyParentBasedOnCompart(tid.track_unit_auto) = 0 THEN
       CONVERT(VARCHAR(8), tid.remaining_hours) ELSE '-' END AS[PotHours100],
       CASE WHEN[dbo].HasComponentAnyParentBasedOnCompart(tid.track_unit_auto) = 0 THEN
      CONVERT(VARCHAR(8), tid.ext_remaining_hours) ELSE '-' END AS[PotHours120],
      tt.tool_name AS[ToolName],
      tid.eval_code AS[EvalCode],
      lct.sorder, lc.comparttype_auto,
		lc.smcs_code,
		lct.comparttype + CASE WHEN tu.pos = 0 THEN '' ELSE ' ' + CONVERT(VARCHAR(2), tu.pos) END AS CompartSide,
		(CASE WHEN(lc.comparttype_auto = 233 OR lc.comparttype_auto = 234) AND tu.pos = 1 THEN 'Front' 

             WHEN lc.comparttype_auto = 233 AND tu.pos = 2 THEN 'Rear'

             WHEN lc.comparttype_auto = 230 OR lc.comparttype_auto = 231 OR lc.comparttype_auto = 232 THEN ' ' 

             WHEN lc.comparttype_auto = 236 AND tu.pos = 0 THEN ' '

             ELSE CONVERT(VARCHAR(5), tu.pos) END) AS Position,
       lc.compartid AS PartSerialNumber, tu.equnit_auto as CompId
FROM TRACK_INSPECTION ti

        INNER JOIN   TRACK_INSPECTION_DETAIL tid on tid.inspection_auto= ti.inspection_auto
        LEFT JOIN GENERAL_EQ_UNIT tu ON  tid.track_unit_auto = tu.equnit_auto

        INNER JOIN   LU_COMPART lc ON lc.compartid_auto = tu.compartid_auto

        INNER JOIN   LU_COMPART_TYPE lct ON lct.comparttype_auto = lc.comparttype_auto

        INNER JOIN   TRACK_TOOL tt ON tt.tool_auto = tid.tool_auto

        INNER JOIN InspectionDetails_Side tidSide ON InspectionDetailsId = tid.inspection_detail_auto
WHERE tid.inspection_auto = @inspection_auto

    AND tidSide.Side= 2 AND (tid.track_unit_history_auto IS NULL OR (tid.track_unit_history_auto IS NOT NULL AND tu.date_installed<ti.inspection_date))
	 
order by lct.sorder, tu.pos, lc.compartid_auto

";
    }
}
