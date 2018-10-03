namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class spGetSubSystemDataWithDetailsModifyForParentCompId : DbMigration
    {
        public override void Up()
        {
            Sql(spGetSubSystemDataWithDetails);
        }
        
        public override void Down()
        {
        }

        string spGetSubSystemDataWithDetails = @"
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mason S
-- =============================================
ALTER PROCEDURE [dbo].[spGetSubSystemDataWithDetails] 
	@module_sub_auto	INT
AS

BEGIN

DECLARE @currentComponent BIGINT

	SELECT lms.Module_sub_auto SystemId, components.equnit_auto ComponentId, comparts_type.comparttype CompartType ,comparts.compart ComponentCompart,comparts.compartid ComponentSerial, dbo.get_component_cmu(components.equnit_auto) component_cmu, inspection_detail.reading ReadValue, inspection_detail.worn_percentage WornPercentage, inspection_detail.eval_code EvalCode, inspection_tool.tool_code InspectionToolCode, '0' parentCompId FROM LU_Module_Sub lms
	INNER JOIN GENERAL_EQ_UNIT components ON components.module_ucsub_auto = lms.Module_sub_auto
	INNER JOIN LU_COMPART comparts ON comparts.compartid_auto = components.compartid_auto
	INNER JOIN LU_COMPART_TYPE comparts_type ON comparts.comparttype_auto = comparts_type.comparttype_auto
	OUTER APPLY [dbo].fnGetLatestInspectionDetailOfEquipment(components.equnit_auto) inspection_detail
	LEFT JOIN TRACK_TOOL inspection_tool ON inspection_detail.tool_auto = inspection_tool.tool_auto
	WHERE lms.Module_sub_auto = @module_sub_auto
END
        ";
    }
}
