namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccessLevelChanges : DbMigration
    {
        public override void Up()
        {
            Sql(alterProc1);
        }
        
        public override void Down()
        {
        }

        public const string alterProc1 = @"
/****** Object:  StoredProcedure [dbo].[GT_Return_Search_Filters_GET_IMPLEMENT_INSPECTION]    Script Date: 21/09/2017 10:07:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		VijayMD
-- Create date: 31-May-2017
-- Description:	Extract the GET Implement Inspection data.
-- =============================================

ALTER PROCEDURE [dbo].[GT_Return_Search_Filters_GET_IMPLEMENT_INSPECTION] 
	@UserAuto	INT
AS
BEGIN
	-- Obtain the list of implements, equipment, jobsites and customers 
	-- used by existing inspections.
	DECLARE @FilterInspectionList AS TABLE 
	( 
		implement VARCHAR(128),
		implement_eqmt BIGINT,
		equipment VARCHAR(128),
		equipmentid_auto BIGINT,
		jobsite VARCHAR(128),
		crsf_auto BIGINT,
		customer_auto BIGINT
	);
	INSERT INTO @FilterInspectionList (implement, implement_eqmt, 
		equipment, equipmentid_auto, jobsite, crsf_auto, customer_auto)
	SELECT	g.impserial AS [Implement]
			, g.equipmentid_auto AS [equipment_impl]
			, e.unitno AS [Equipment]
			, e.equipmentid_auto
			, c.site_name AS [Jobsite]
			, c.crsf_auto
			, cu.customer_auto
	FROM GET_IMPLEMENT_INSPECTION AS gii
	INNER JOIN [GET] AS g
		ON gii.get_auto = g.get_auto
	INNER JOIN [EQUIPMENT] AS e
		ON g.equipmentid_auto = e.equipmentid_auto
	INNER JOIN [CRSF] AS c
		ON e.crsf_auto = c.crsf_auto
	INNER JOIN [CUSTOMER] AS cu
		ON c.customer_auto = cu.customer_auto;

	-- Obtain the list of user assignments to access equipment, jobsites 
	-- and customer data.
	DECLARE @tblUserAssign AS TABLE 
	(
		[UserAccessMapId]	INT,
		[user_auto]			BIGINT,
		[DealershipId]		INT,
		[customer_auto]		BIGINT,
		[crsf_auto]			BIGINT,
		[equipmentid_auto]	BIGINT,
		[AccessLevelTypeId]	INT
	);
	INSERT INTO @tblUserAssign (UserAccessMapId, user_auto, DealershipId, 
		customer_auto, crsf_auto, equipmentid_auto, AccessLevelTypeId)
	SELECT	[UserAccessMapId]
			,[user_auto]
			,[DealershipId]
			,[customer_auto]
			,[crsf_auto]
			,[equipmentid_auto]
			,[AccessLevelTypeId]
	FROM	dbo.UserAccessMaps
	WHERE	user_auto = @UserAuto;

	-- List of Customers accessible to the user.
	DECLARE @tblUserAssign_Customer AS TABLE 
	(
		customer_auto BIGINT
	);
	INSERT INTO @tblUserAssign_Customer (customer_auto)
	SELECT	C.[customer_auto]
	FROM	CUSTOMER AS C
	WHERE	(
				SELECT COUNT(*) FROM @tblUserAssign AS t 
				INNER JOIN AccessLevelTypes AS a
				ON a.AccessLevelTypesId = t.AccessLevelTypeId
				WHERE a.Name = 'Global Administrator'
			) > 0

	UNION 

	SELECT	C.[customer_auto]
	FROM	CUSTOMER AS C
	INNER JOIN	@tblUserAssign AS t
		ON	C.DealershipId = t.DealershipId
	INNER JOIN AccessLevelTypes AS a
		ON a.AccessLevelTypesId = t.AccessLevelTypeId 
	WHERE	t.DealershipId IS NOT NULL
		AND (a.Name = 'Dealership Administrator'
			OR	a.Name = 'Dealership User')
			
	UNION
	
	SELECT	t.customer_auto
	FROM	@tblUserAssign AS t
	INNER JOIN AccessLevelTypes AS a
		ON a.AccessLevelTypesId = t.AccessLevelTypeId
	WHERE	t.customer_auto IS NOT NULL
		AND (a.Name = 'Customer Administrator'
			OR	a.Name = 'Customer User');

	-- List of Jobsites accessible to the user.
	DECLARE @tblUserAssign_Jobsite AS TABLE 
	(
		crsf_auto BIGINT
	);
	INSERT INTO @tblUserAssign_Jobsite (crsf_auto)
	SELECT [crsf_auto] 
	FROM CRSF AS cr 
	INNER JOIN @tblUserAssign_Customer AS cu
		ON cr.customer_auto = cu.customer_auto;
	
	-- List of equipment accessible to the user.
	DECLARE @tblUserAssign_Equipment AS TABLE 
	(
		equipmentid_auto BIGINT
	);
	INSERT INTO @tblUserAssign_Equipment (equipmentid_auto)
	SELECT [equipmentid_auto]
	FROM EQUIPMENT AS eq
	INNER JOIN @tblUserAssign_Jobsite AS cr
		ON eq.crsf_auto = cr.crsf_auto;


	-- Implement filter
	SELECT DISTINCT implement 
	FROM @FilterInspectionList AS f
	INNER JOIN dbo.[GET] AS g
		ON g.equipmentid_auto = f.equipmentid_auto
	INNER JOIN @tblUserAssign_Equipment AS eq
		ON f.equipmentid_auto = eq.equipmentid_auto;


	-- Equipment filter
	SELECT DISTINCT equipment
	FROM @FilterInspectionList AS f
	INNER JOIN @tblUserAssign_Equipment AS ec
		ON ec.equipmentid_auto = f.equipmentid_auto;


	-- Jobsite filter
	SELECT DISTINCT f.jobsite 
	FROM @FilterInspectionList AS f
	INNER JOIN @tblUserAssign_Jobsite AS j
		ON j.crsf_auto = f.crsf_auto;

END





";

       
    }
}
