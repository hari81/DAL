namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyspReturnTrackInspectionEquipment : DbMigration
    {
        public override void Up()
        {
            Sql(storedProcAfterChange);
        }
        
        public override void Down()
        {
            Sql(storedProcBeforeChange);
        }

        string storedProcBeforeChange = @"SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
--By Rumesh MM on 12/11/2007 changed the join of CRSF and REGION to CRSF ,BRANCH and REGION
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[return_track_inspection_equipment]
	@inspection_auto int
 AS
	
SELECT   EQUIPMENT.equipmentid_auto,EQUIPMENT.serialno, EQUIPMENT.unitno, CUSTOMER.customer_auto,CUSTOMER.cust_name, TRACK_INSPECTION.inspection_auto, MAKE.makedesc,
	    MODEL.modeldesc, CRSF.crsf_auto,CRSF.site_name, APPLICATION.appdesc, TRACK_INSPECTION.inspection_date,TRACK_INSPECTION.evalcode,TRACK_INSPECTION.smu
		, TRACK_INSPECTION.inspection_comments as notes
		,LU_DEALERSHIP.dealershipname,TRACK_ACTION.action_recommandation,TRACK_ACTION.problem_solved
		,CASE WHEN TRACK_INSPECTION.last_interp_date IS NOT NULL THEN
			1 ELSE 	0 END AS interpreted
		,TRACK_INSPECTION.eval_comment
FROM      EQUIPMENT INNER JOIN
                CRSF ON EQUIPMENT.crsf_auto = CRSF.crsf_auto INNER JOIN
                CUSTOMER ON CRSF.customer_auto = CUSTOMER.customer_auto INNER JOIN
                TRACK_INSPECTION ON EQUIPMENT.equipmentid_auto = TRACK_INSPECTION.equipmentid_auto INNER JOIN
                LU_MMTA ON EQUIPMENT.mmtaid_auto = LU_MMTA.mmtaid_auto LEFT OUTER JOIN
                APPLICATION ON LU_MMTA.app_auto = APPLICATION.app_auto INNER JOIN
                MAKE ON LU_MMTA.make_auto = MAKE.make_auto INNER JOIN
                MODEL ON LU_MMTA.model_auto = MODEL.model_auto INNER JOIN 
	   BRANCH b ON CRSF.branch_auto = b.branch_auto INNER JOIN
                REGION ON b.region_auto = REGION.region_auto INNER JOIN
                LU_DEALERSHIP ON REGION.dealership_auto = LU_DEALERSHIP.dealership_auto  LEFT JOIN
	  TRACK_ACTION ON 	TRACK_INSPECTION.inspection_auto = TRACK_ACTION.inspection_auto
WHERE  (TRACK_INSPECTION.inspection_auto = @inspection_auto) AND (CUSTOMER.active = 1)

";
        string storedProcAfterChange = @"SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
--By Rumesh MM on 12/11/2007 changed the join of CRSF and REGION to CRSF ,BRANCH and REGION
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[return_track_inspection_equipment]
	@inspection_auto int
 AS
	
SELECT   EQUIPMENT.equipmentid_auto,EQUIPMENT.serialno, EQUIPMENT.unitno, CUSTOMER.customer_auto,CUSTOMER.cust_name, TRACK_INSPECTION.inspection_auto, MAKE.makedesc,
	    MODEL.modeldesc, CRSF.crsf_auto,CRSF.site_name, APPLICATION.appdesc, TRACK_INSPECTION.inspection_date,TRACK_INSPECTION.evalcode,TRACK_INSPECTION.smu
		, TRACK_INSPECTION.inspection_comments as notes
		,'' as dealershipname,TRACK_ACTION.action_recommandation,TRACK_ACTION.problem_solved
		,CASE WHEN TRACK_INSPECTION.last_interp_date IS NOT NULL THEN
			1 ELSE 	0 END AS interpreted
		,TRACK_INSPECTION.eval_comment
FROM      EQUIPMENT 
INNER JOIN CRSF ON EQUIPMENT.crsf_auto = CRSF.crsf_auto 
INNER JOIN CUSTOMER ON CRSF.customer_auto = CUSTOMER.customer_auto 
INNER JOIN TRACK_INSPECTION ON EQUIPMENT.equipmentid_auto = TRACK_INSPECTION.equipmentid_auto 
INNER JOIN LU_MMTA ON EQUIPMENT.mmtaid_auto = LU_MMTA.mmtaid_auto 
LEFT OUTER JOIN APPLICATION ON LU_MMTA.app_auto = APPLICATION.app_auto 
INNER JOIN MAKE ON LU_MMTA.make_auto = MAKE.make_auto 
INNER JOIN MODEL ON LU_MMTA.model_auto = MODEL.model_auto 
--INNER JOIN BRANCH b ON CRSF.branch_auto = b.branch_auto -- Removed region, branch and lu_dealership as these fields are not in use anymore and cause no data to flow through
--INNER JOIN REGION ON b.region_auto = REGION.region_auto 
--INNER JOIN LU_DEALERSHIP ON REGION.dealership_auto = LU_DEALERSHIP.dealership_auto
LEFT JOIN TRACK_ACTION ON TRACK_INSPECTION.inspection_auto = TRACK_ACTION.inspection_auto
WHERE (TRACK_INSPECTION.inspection_auto = @inspection_auto) AND (CUSTOMER.active = 1)
";
    }
}
