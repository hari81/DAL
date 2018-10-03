namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixStoredProcReturningImagesNotGreen : DbMigration
    {
        public override void Up()
        {
            Sql(@"ALTER PROCEDURE [dbo].[spReturnTrackInspectionWithUCSubSystem]
	@inspection_auto INT,
	@equipmentid_auto BIGINT
 AS
	IF (@inspection_auto!=0)
	BEGIN
	
	
		SELECT lct.comparttype + ' : ' + lu.compart as compart, lu.compartid_auto, lu.track_comp_cts_maintype, lu.track_comp_cts_subtype,
				CASE WHEN (lu.smcs_code = '4174' OR lu.smcs_code = '4175') AND geu.pos = 1 THEN 'Internal' 
					WHEN (lu.smcs_code = '4174' OR lu.smcs_code = '4175') AND geu.pos = 2 THEN 'External' 
					WHEN lu.smcs_code = '4159' AND geu.pos = 1 THEN 'Front' 
					WHEN lu.smcs_code = '4159' AND geu.pos = 2 THEN 'Rear' 
					WHEN lu.comparttype_auto = 233 AND geu.pos = 1 THEN 'Front' 
					WHEN lu.comparttype_auto = 233 AND geu.pos = 2 THEN 'Rear' 
					WHEN lu.comparttype_auto = 234 AND geu.pos = 1 THEN 'Front' 
					WHEN geu.pos = -1 THEN '' 
					ELSE 	 CAST(geu.pos AS VARCHAR) END as pos,
				geu.side,tid.eval_code, tool_name, tid.reading, tid.worn_percentage, tid.worn_percentage_120, tid.hours_on_surface AS component_hours,  remaining_hours, 
				ext_remaining_hours,projected_hours as expected_life, ext_projected_hours as ext_expected_life,tid.eval_code,geu.equnit_auto,lu.smcs_code,
				geu.smu_at_install, tt.tool_auto, tid.comments, geu.track_0_worn, geu.track_100_worn, geu.track_120_worn, geu.eq_ltd_at_install, geu.smu_at_install, 
				(SELECT COUNT(*) 
					FROM TRACK_INSPECTION_IMAGES tis
					WHERE tis.inspection_detail_auto = tid.inspection_detail_auto) AS imgCountLeft, 
				(SELECT COUNT(*) 
					FROM TRACK_INSPECTION_IMAGES tis
					WHERE tis.inspection_detail_auto = tid.inspection_detail_auto) AS imgCountRight, 
					tid.inspection_detail_auto ,lu.compartid
					,lct.sorder, lu.compartid_auto, geu.pos,geu.side,lu.smcs_code,0 AS historytable_auto,geu.cmu,lct.comparttypeid --added comparttypeid
					,lms.Serialno, lct.comparttype_auto, lct.sorder
		--FROM  GENERAL_EQ_UNIT AS geu  
		--		INNER JOIN	EQUIPMENT AS e ON e.equipmentid_auto = geu.equipmentid_auto 
		--		INNER JOIN	LU_COMPART lu ON geu.compartid_auto=lu.compartid_auto 
		--		INNER JOIN	LU_COMPART_TYPE lct ON lu.comparttype_auto = lct.comparttype_auto
		--		INNER JOIN	TRACK_INSPECTION AS ti ON  ti.equipmentid_auto = e.equipmentid_auto
		--		LEFT OUTER JOIN TRACK_INSPECTION_DETAIL AS tid ON geu.equnit_auto = tid.track_unit_auto and ti.inspection_auto = tid.inspection_auto 
		--		LEFT JOIN TRACK_COMPART_EXT tce ON lu.compartid_auto = tce.compartid_auto
		--		LEFT JOIN TRACK_TOOL tt ON tt.tool_auto = ISNULL(tid.tool_auto, tce.tools_auto)
		--		INNER JOIN LU_SYSTEM ls ON lct.system_auto = ls.system_auto --PRN9692
		--		LEFT JOIN LU_Module_Sub lms ON geu.module_ucsub_auto = lms.Module_sub_auto --PRN10920

		--WHERE ti.equipmentid_auto=@equipmentid_auto AND ti.inspection_auto = @inspection_auto 

				FROM TRACK_INSPECTION AS ti
				INNER JOIN TRACK_INSPECTION_DETAIL AS tid ON ti.inspection_auto = tid.inspection_auto
				INNER JOIN 	GENERAL_EQ_UNIT AS geu ON tid.track_unit_auto = geu.equnit_auto
				INNER JOIN	LU_COMPART lu ON geu.compartid_auto=lu.compartid_auto 
				INNER JOIN	LU_COMPART_TYPE lct ON lu.comparttype_auto = lct.comparttype_auto
				LEFT JOIN TRACK_COMPART_EXT tce ON lu.compartid_auto = tce.compartid_auto
				LEFT JOIN TRACK_TOOL tt ON tt.tool_auto = ISNULL(tid.tool_auto, tce.tools_auto)
				INNER JOIN LU_SYSTEM ls ON lct.system_auto = ls.system_auto --PRN9692
				LEFT JOIN LU_Module_Sub lms ON geu.module_ucsub_auto = lms.Module_sub_auto --PRN10920

		WHERE ti.inspection_auto = @inspection_auto 


			--PRN9082
			AND (tid.track_unit_history_auto IS NULL OR (tid.track_unit_history_auto IS NOT NULL AND geu.date_installed < ti.inspection_date))
			--PRN9692 
			AND (ls.system_desc = 'U/C' OR ls.system_desc='Undercarriage')

			

		--PRN9082 - Union query added
		UNION

		SELECT lct.comparttype + ' : ' + lu.compart as compart, lu.compartid_auto, lu.track_comp_cts_maintype, lu.track_comp_cts_subtype,
				CASE WHEN (lu.smcs_code = '4174' OR lu.smcs_code = '4175') AND geu.pos = 1 THEN 'Internal' 
					WHEN (lu.smcs_code = '4174' OR lu.smcs_code = '4175') AND geu.pos = 2 THEN 'External' 
					WHEN lu.smcs_code = '4159' AND geu.pos = 1 THEN 'Front' 
					WHEN lu.smcs_code = '4159' AND geu.pos = 2 THEN 'Rear' 
					WHEN lu.comparttype_auto = 233 AND geu.pos = 1 THEN 'Front' 
					WHEN lu.comparttype_auto = 233 AND geu.pos = 2 THEN 'Rear' 
					WHEN lu.comparttype_auto = 234 AND geu.pos = 1 THEN 'Front' 
					WHEN geu.pos = -1 THEN '' 
					ELSE 	 CAST(geu.pos AS VARCHAR) END as pos,
				geu.side,tid.eval_code, tool_name, tid.reading, tid.worn_percentage, tid.worn_percentage_120, tid.hours_on_surface AS component_hours,  remaining_hours, 
				ext_remaining_hours,projected_hours as expected_life, ext_projected_hours as ext_expected_life,tid.eval_code,geu.oequnit_auto,lu.smcs_code,
				geu.smu_at_install, tt.tool_auto, tid.comments, geu.track_0_worn, geu.track_100_worn, geu.track_120_worn, geu.eq_ltd_at_install, geu.smu_at_install, 
				(SELECT COUNT(*) 
					FROM TRACK_INSPECTION_IMAGES tis
					WHERE tis.inspection_detail_auto = tid.inspection_detail_auto) AS imgCountLeft, 
				(SELECT COUNT(*) 
					FROM TRACK_INSPECTION_IMAGES tis
					WHERE tis.inspection_detail_auto = tid.inspection_detail_auto) AS imgCountRight, 
					tid.inspection_detail_auto ,lu.compartid
					,lct.sorder, lu.compartid_auto, geu.pos,geu.side,lu.smcs_code, geu.equnit_auto AS historytable_auto,geu.cmu,lct.comparttypeid --added comparttypeid
					,lms.Serialno, lct.comparttype_auto, lct.sorder
		FROM  GENERAL_EQ_UNIT_HISTORY AS geu  
				left JOIN	EQUIPMENT AS e ON e.equipmentid_auto = geu.equipmentid_auto 
				INNER JOIN	LU_COMPART lu ON geu.compartid_auto=lu.compartid_auto 
				INNER JOIN	LU_COMPART_TYPE lct ON lu.comparttype_auto = lct.comparttype_auto
				INNER JOIN	TRACK_INSPECTION AS ti ON  ti.equipmentid_auto = e.equipmentid_auto
				LEFT OUTER JOIN TRACK_INSPECTION_DETAIL AS tid ON geu.oequnit_auto = tid.track_unit_auto and ti.inspection_auto = tid.inspection_auto 
				LEFT JOIN TRACK_COMPART_EXT tce ON lu.compartid_auto = tce.compartid_auto
				LEFT JOIN TRACK_TOOL tt ON tt.tool_auto = ISNULL(tid.tool_auto, tce.tools_auto)
				INNER JOIN LU_SYSTEM ls ON lct.system_auto = ls.system_auto --PRN9692
				LEFT JOIN LU_Module_Sub lms ON geu.module_ucsub_auto = lms.Module_sub_auto --PRN10920
		WHERE ti.equipmentid_auto=@equipmentid_auto AND ti.inspection_auto = @inspection_auto and tid.track_unit_history_auto IS NOT NULL
			AND oequnit_auto NOT IN (

									SELECT	tu.equnit_auto 

										FROM track_inspection_detail tid 
												INNER JOIN 	general_eq_unit tu ON tu.equnit_auto=tid.track_unit_auto 
												INNER JOIN TRACK_INSPECTION t on tid.inspection_auto = t.inspection_auto
										WHERE tid.inspection_auto = @inspection_auto 
												AND (tid.track_unit_history_auto IS NULL OR (tid.track_unit_history_auto IS NOT NULL AND tu.date_installed < t.inspection_date))
										)

			--PRN9692 
			AND (ls.system_desc = 'U/C' OR ls.system_desc='Undercarriage')
		--ORDER BY lct.sorder, lu.compartid_auto, geu.pos,geu.side,lu.smcs_code
		ORDER BY lct.sorder,  geu.pos,geu.side,lu.smcs_code

	END
	ELSE
	BEGIN
		SELECT lct.comparttype + ' : ' + lu.compart as compart, lu.compartid_auto, lu.track_comp_cts_maintype, lu.track_comp_cts_subtype,
			CASE WHEN (lu.smcs_code = '4174' OR lu.smcs_code = '4175') AND geu.pos = 1 THEN 'Internal' 
				WHEN (lu.smcs_code = '4174' OR lu.smcs_code = '4175') AND geu.pos = 2 THEN 'External' 
				WHEN lu.smcs_code = '4159' AND geu.pos = 1 THEN 'Front' 
				WHEN lu.smcs_code = '4159' AND geu.pos = 2 THEN 'Rear' 
				WHEN lu.comparttype_auto = 233 AND geu.pos = 1 THEN 'Front' 
				WHEN lu.comparttype_auto = 233 AND geu.pos = 2 THEN 'Rear' 
				WHEN lu.comparttype_auto = 234 AND geu.pos = 1 THEN 'Front' 
				WHEN geu.pos = -1 THEN '' 
				ELSE 	 CAST(geu.pos AS varchar) END AS pos,
			geu.side,'' AS eval_code, tt.tool_name, '' AS reading, '' AS worn_percentage, '' AS worn_percentage_120, geu.CMU AS component_hours,  '' AS remaining_hours, 
			'' AS ext_remaining_hours,'' AS expected_life, '' AS ext_expected_life,'' AS eval_code,geu.equnit_auto,lu.smcs_code,geu.smu_at_install, tt.tool_auto,'' AS comments, 
			geu.track_0_worn, geu.track_100_worn, geu.track_120_worn, geu.eq_ltd_at_install, geu.smu_at_install, 0 AS imgCountLeft, 0 AS imgCountRight, '' AS inspection_detail_auto 
			,lu.compartid,geu.equipmentid_auto, 0 AS historytable_auto,geu.cmu,lct.comparttypeid --added comparttypeid
			,lms.Serialno, lct.comparttype_auto, lct.sorder
		FROM general_eq_unit geu
			INNER JOIN LU_COMPART lu ON geu.compartid_auto=lu.compartid_auto
			INNER JOIN LU_COMPART_TYPE lct ON lu.comparttype_auto = lct.comparttype_auto
			LEFT JOIN TRACK_COMPART_EXT tce ON lu.compartid_auto = tce.compartid_auto
			LEFT JOIN TRACK_TOOL tt ON tt.tool_auto = tce.tools_auto
			INNER JOIN LU_SYSTEM ls ON lct.system_auto = ls.system_auto --PRN9692
			LEFT JOIN LU_Module_Sub lms  ON geu.module_ucsub_auto = lms.Module_sub_auto --PRN10920
		WHERE geu.equipmentid_auto=@equipmentid_auto 
		--PRN9692 
			AND (ls.system_desc = 'U/C' OR ls.system_desc='Undercarriage')
		--and geu.side=1
		--ORDER BY lct.sorder, lu.compartid_auto, geu.pos,geu.side,lu.smcs_code
		ORDER BY lct.sorder,  geu.pos,geu.side,lu.smcs_code
	END

	IF (@inspection_auto!=0)
		SELECT * FROM track_inspection WHERE inspection_auto=@inspection_auto

		SELECT     EQUIPMENT.track_make_auto, MAKE.makedesc, EQUIPMENT.track_code_auto, TRACK_CODE.track_code
		FROM       EQUIPMENT 
						INNER JOIN	MAKE ON EQUIPMENT.track_make_auto = MAKE.make_auto 
						INNER JOIN	MODEL ON EQUIPMENT.track_code_auto = MODEL.model_auto 
						INNER JOIN  TRACK_CODE ON EQUIPMENT.track_code_auto = TRACK_CODE.track_code_auto
		WHERE     (EQUIPMENT.equipmentid_auto = @equipmentid_auto)");
        }
        
        public override void Down()
        {
        }
    }
}
