namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sp_update : DbMigration
    {
        public override void Up()
        {
            Sql(return_track_inspection);
        }
        
        public override void Down()
        {
        }
        string return_track_inspection = @"
            SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*===================================================================
--  Modified:		NB | 09-11-16 | PRN11693
--  Updated:		NB | 10-06-16 | PRN10921
--  Update:			NB | 03-03-16 | PRN9692
--	Update By:		Nouman Bhatti
--	Date:			14-08-2015
--	Reason:			PRN9082 - Added Union 
--
--  Updated By:		Nouman Bhatti
--	Update Date:	07-08-2015
--	Reason:			Removed the one column from order by 
--
--
--  Updated By:		Nouman Bhatti
--	Update Date:	10-07-2015
--	Reason:			Added Columns for Part Number, Comments 
--					Also Done formatting on the SP
--
--
-- modified by Ken So 26/05/2009 change track_unit to general_eq_unit
-- modified by Yasitha 31/05/2007 (Spec:ECUNDERCARRIAGEVIEW02.doc)
--

--
-- Test Run:		exec return_track_inspection 467,2
======================================================================
*/
ALTER PROCEDURE [dbo].[return_track_inspection]
	@inspection_auto	INT,
	@side				INT = NULL
 AS

	SELECT	tu.equnit_auto, 
			lct.comparttype, lu.compart, lu.compartid_auto, lu.track_comp_cts_maintype, lu.track_comp_cts_subtype,
			CASE	WHEN lu.smcs_code = '4174' OR lu.smcs_code = '4175' AND tu.pos = 1 THEN 'Internal' 
					WHEN lu.smcs_code = '4174' OR lu.smcs_code = '4175' AND tu.pos = 2 THEN 'External' 
					WHEN lu.smcs_code = '4159' AND tu.pos = 1 THEN 'Front' 
					WHEN lu.smcs_code = '4159' AND tu.pos = 2 THEN 'Rear' 
					WHEN tu.pos = -1 THEN '' 
					WHEN tu.pos = 0 THEN '' 
					ELSE 	 CAST(tu.pos AS VARCHAR) END AS pos, -- modified by Yasitha 13th July 2007 (added new filters) 
			tu.side,tid.eval_code, tool_name, tid.reading, tid.worn_percentage
			--PRN11150
			--,tid.hours_on_surface AS component_hours,  remaining_hours, 
			,(ISNULL(t.smu,0)-ISNULL( tu.smu_at_install,0)+ISNULL(tu.cmu,0)) AS component_hours,  remaining_hours,
			ext_remaining_hours,projected_hours AS expected_life, ext_projected_hours AS ext_expected_life,tid.eval_code,tu.equnit_auto AS track_unit_auto,lu.smcs_code,
			tu.eq_ltd_at_install, tu.smu_at_install, 
			(SELECT COUNT(*) 
				FROM COMPART_ATTACH_FILESTREAM 
				WHERE compartid_auto = lu.compartid_auto AND inspection_auto = @inspection_auto AND compart_attach_type_auto = 3 AND (position IS NULL OR position = pos)) AS imgCountLeft, 
			(SELECT COUNT(*) 
				FROM COMPART_ATTACH_FILESTREAM 
				WHERE compartid_auto = lu.compartid_auto AND inspection_auto = @inspection_auto AND compart_attach_type_auto = 4 AND (position IS NULL OR position = pos)) AS imgCountRight,
			lu.compartid,tid.comments,tid.inspection_detail_auto,tu.side, lct.sorder, lu.sorder, tu.pos
			,lct.comparttypeid
			,isnull(tu.cost,0) as cost, 
			--cast(round(isnull(tu.cost,0)/isnull((Case tu.cmu When 0 then 1 else tu.cmu end),1),2) as decimal(16,2)) as costperhour
			--cast(round(case isnull(tid.hours_on_surface,0) when 0 then 0 else isnull(tu.cost,0)/tid.hours_on_surface end ,2) as decimal(16,2)) as costperhour --PRN10843 commented
			cast(round(case isnull(tid.projected_hours,0) when 0 then 0 else isnull(tu.cost,0)/tid.projected_hours end ,2) as decimal(16,2)) as costperhour 
			,lms.Serialno --PRN10921
			,tu.equipmentid_auto
			,0 AS historytable_auto, t.inspection_date
	FROM track_inspection_detail tid 
			--INNER JOIN 	track_unit tu ON tu.track_unit_auto=tid.track_unit_auto 
			INNER JOIN 	general_eq_unit tu ON tu.equnit_auto=tid.track_unit_auto 
			INNER JOIN 	LU_COMPART lu ON lu.compartid_auto=tu.compartid_auto 
			INNER JOIN LU_COMPART_TYPE lct on lct.comparttype_auto = lu.comparttype_auto
			INNER JOIN	track_tool tt ON tt.tool_auto=tid.tool_auto
			INNER JOIN TRACK_INSPECTION t on tid.inspection_auto = t.inspection_auto
			LEFT JOIN	LU_Module_Sub lms ON tu.module_ucsub_auto = lms.Module_sub_auto
	WHERE tid.inspection_auto =@inspection_auto AND tu.side = CASE WHEN @side IS NOT NULL THEN @side ELSE tu.side END
	--PRN9082
			AND (tid.track_unit_history_auto IS NULL OR (tid.track_unit_history_auto IS NOT NULL AND tu.date_installed <= t.inspection_date))

	--PRN9082
	UNION

	SELECT	tu.oequnit_auto, 
			lct.comparttype, lu.compart, lu.compartid_auto, lu.track_comp_cts_maintype, lu.track_comp_cts_subtype,
			CASE	WHEN lu.smcs_code = '4174' OR lu.smcs_code = '4175' AND tu.pos = 1 THEN 'Internal' 
					WHEN lu.smcs_code = '4174' OR lu.smcs_code = '4175' AND tu.pos = 2 THEN 'External' 
					WHEN lu.smcs_code = '4159' AND tu.pos = 1 THEN 'Front' 
					WHEN lu.smcs_code = '4159' AND tu.pos = 2 THEN 'Rear' 
					WHEN tu.pos = -1 THEN '' 
					WHEN tu.pos = 0 THEN '' 
					ELSE 	 CAST(tu.pos AS VARCHAR) END AS pos, -- modified by Yasitha 13th July 2007 (added new filters) 
			tu.side,tid.eval_code, tool_name, tid.reading, tid.worn_percentage
			--PRN11150
			--tid.hours_on_surface AS component_hours,  remaining_hours, 
			,(ISNULL(t.smu,0)-ISNULL( tu.smu_at_install,0)+ISNULL(tu.cmu,0)) AS component_hours,  remaining_hours,
			ext_remaining_hours,projected_hours AS expected_life, ext_projected_hours AS ext_expected_life,tid.eval_code,tu.equnit_auto AS track_unit_auto,lu.smcs_code,
			tu.eq_ltd_at_install, tu.smu_at_install, 
			(SELECT COUNT(*) 
				FROM COMPART_ATTACH_FILESTREAM 
				WHERE compartid_auto = lu.compartid_auto AND inspection_auto = @inspection_auto AND compart_attach_type_auto = 3 AND (position IS NULL OR position = pos)) AS imgCountLeft, 
			(SELECT COUNT(*) 
				FROM COMPART_ATTACH_FILESTREAM 
				WHERE compartid_auto = lu.compartid_auto AND inspection_auto = @inspection_auto AND compart_attach_type_auto = 4 AND (position IS NULL OR position = pos)) AS imgCountRight,
			lu.compartid,tid.comments,tid.inspection_detail_auto,tu.side, lct.sorder, lu.sorder, tu.pos
			,lct.comparttypeid
			,isnull(tu.cost,0) as cost, 
			--cast(round(isnull(tu.cost,0)/isnull((Case tu.cmu When 0 then 1 else tu.cmu end),1),2) as decimal(16,2)) as costperhour
			--cast(round(case isnull(tid.hours_on_surface,0) when 0 then 0 else isnull(tu.cost,0)/tid.hours_on_surface end ,2) as decimal(16,2)) as costperhour --PRN10743 - commented
			cast(round(case isnull(tid.projected_hours,0) when 0 then 0 else isnull(tu.cost,0)/tid.projected_hours end ,2) as decimal(16,2)) as costperhour 
			,lms.Serialno --PRN10921
			,tu.equipmentid_auto
			,tu.equnit_auto AS historytable_auto, t.inspection_date
	FROM track_inspection_detail tid 
			--INNER JOIN 	track_unit tu ON tu.track_unit_auto=tid.track_unit_auto 
			INNER JOIN 	GENERAL_EQ_UNIT_HISTORY tu ON tu.oequnit_auto=tid.track_unit_auto 
			INNER JOIN 	LU_COMPART lu ON lu.compartid_auto=tu.compartid_auto 
			INNER JOIN	LU_COMPART_TYPE lct on lct.comparttype_auto = lu.comparttype_auto
			INNER JOIN	track_tool tt ON tt.tool_auto=tid.tool_auto
			LEFT JOIN	LU_Module_Sub lms ON lms.Module_sub_auto = tu.module_ucsub_auto 
			INNER JOIN TRACK_INSPECTION t ON tid.inspection_auto = t.inspection_auto
	WHERE tid.inspection_auto =@inspection_auto AND tu.side = CASE WHEN @side IS NOT NULL THEN @side ELSE tu.side END AND tid.track_unit_history_auto IS NOT NULL
		AND oequnit_auto NOT IN (

	SELECT	tu.equnit_auto 

	FROM track_inspection_detail tid 
			INNER JOIN 	general_eq_unit tu ON tu.equnit_auto=tid.track_unit_auto 
			INNER JOIN TRACK_INSPECTION t on tid.inspection_auto = t.inspection_auto
	WHERE tid.inspection_auto = @inspection_auto AND tu.side = CASE WHEN @side IS NOT NULL THEN @side ELSE tu.side END
			AND (tid.track_unit_history_auto IS NULL OR (tid.track_unit_history_auto IS NOT NULL AND tu.date_installed <= t.inspection_date))
	)


--	ORDER BY lu.compart, tu.pos, tu.side     --Modified by Jerry 4th July 2007
--	ORDER BY tu.pos, lu.compart, tu.side     --commented by Yasitha 13th July 2007
--PRN9037	--ORDER BY tu.side, lct.sorder, lu.sorder, lu.smcs_code, tu.pos	 --added by Yasitha 13th July 2007

ORDER BY tu.side, lct.sorder, lu.sorder, tu.pos	 --PRN9037


	SELECT max(hours_on_surface) AS max_component_hours, max(ext_projected_hours) AS max_ext_projected_hours , max(ext_remaining_hours) AS max_ext_remaining_hours
	FROM track_inspection_detail 
	WHERE inspection_auto = @inspection_auto

	SELECT value_key FROM APPLICATION_LU_CONFIG WHERE variable_key = 'UCSubSysSerialShow'
";

    }
}
