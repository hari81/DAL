namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccessLevelChanges1 : DbMigration
    {
        public override void Up()
        {
            Sql(alterProc2);
        }
        
        public override void Down()
        {
        }

        public const string alterProc2 = @"
/****** Object:  StoredProcedure [dbo].[GT_Return_Filtered_GET_IMPLEMENT_INSPECTION]    Script Date: 21/09/2017 10:17:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		VijayMD
-- Create date: 29-May-2017
-- Description:	Return the filtered list of GET Implement Inspections.
-- =============================================
ALTER PROCEDURE [dbo].[GT_Return_Filtered_GET_IMPLEMENT_INSPECTION] 
	@EquipmentFilter AS VARCHAR(MAX),
	@ImplementFilter AS VARCHAR(MAX),
	@JobsiteFilter AS VARCHAR(MAX),
	@currentPage AS INT = 0,
	@currentUser AS INT,
	@ImplementCategory AS INT = 0,
	@SortColumn AS VARCHAR(MAX),
	@SortDescending AS BIT
AS
BEGIN

	DECLARE @currentDate AS DATE = GETDATE();
	DECLARE @maxAgeForNewStatus_config AS INT;
	SELECT @maxAgeForNewStatus_config = value_key FROM dbo.GET_CONFIG WHERE variable_key = 'MaxAgeForNewStatus';

	DECLARE @emptyEquipmentStr AS BIT = 0;
	DECLARE @emptyImplementStr AS BIT = 0;
	DECLARE @emptyJobsiteStr AS BIT = 0;

	DECLARE @tblEquipment AS TABLE ( equipment VARCHAR(128) );
	DECLARE @tblImplement AS TABLE ( implement VARCHAR(128) );
	DECLARE @tblJobsite AS TABLE ( jobsite VARCHAR(128) );

	DECLARE @equipmentXML AS XML;
	DECLARE @implementXML AS XML;
	DECLARE @jobsiteXML AS XML;

	IF @EquipmentFilter = ''
		SET @emptyEquipmentStr = 1;

	IF @ImplementFilter = ''
		SET @emptyImplementStr = 1;

	IF @JobsiteFilter = ''
		SET @emptyJobsiteStr = 1;

	SELECT @equipmentXML = CAST('<E>' + REPLACE(@EquipmentFilter, ',', '</E><E>') + '</E>' AS XML);
	SELECT @implementXML = CAST('<I>' + REPLACE(@ImplementFilter, ',', '</I><I>') + '</I>' AS XML);
	SELECT @jobsiteXML = CAST('<J>' + REPLACE(@JobsiteFilter, ',', '</J><J>') + '</J>' AS XML);

	-- Parse the comma-separated list of equipment.
	WITH equipmentXMLStringSplit_CTE AS
	(
		SELECT t.value('.', 'varchar(128)') AS equipment
		FROM @equipmentXML.nodes('/E') AS e(t)
	)
	INSERT INTO @tblEquipment (equipment)
	SELECT eXML.equipment
	FROM equipmentXMLStringSplit_CTE AS eXML;

	-- Parse the comma-separated list of implements.
	WITH implementXMLStringSplit_CTE AS
	(
		SELECT t.value('.', 'varchar(128)') AS implement
		FROM @implementXML.nodes('/I') AS i(t)
	)
	INSERT INTO @tblImplement (implement)
	SELECT iXML.implement
	FROM implementXMLStringSplit_CTE AS iXML;

	-- Parse the comma-separated list of jobsites.
	WITH jobsiteXMLStringSplit_CTE AS
	(
		SELECT t.value('.', 'varchar(128)') AS jobsite
		FROM @jobsiteXML.nodes('/J') AS j(t)
	)
	INSERT INTO @tblJobsite (jobsite)
	SELECT jXML.jobsite
	FROM jobsiteXMLStringSplit_CTE AS jXML;


	DECLARE @tblInspection AS TABLE
	(
		inspection_auto		INT,
		InspectionDate		DATE,
		get_auto			INT,
		Implement			VARCHAR(128),
		equipmentid_auto	INT,
		Equipment			VARCHAR(128),
		Model				VARCHAR(128),
		crsf_auto			INT,
		Jobsite				VARCHAR(128),
		Customer			VARCHAR(128),
		Eval				INT,
		Flag				BIT,
		InspectionViewed	BIT
	);

	-- Obtain the most recent GET Implement Inspections
	WITH GetImplementInspection_CTE AS
	(
		SELECT gii2.inspection_auto, ROW_NUMBER() OVER (PARTITION BY gii2.get_auto 
			ORDER BY gii2.inspection_date DESC, gii2.inspection_auto DESC) AS rowNumber
		FROM GET_IMPLEMENT_INSPECTION AS gii2
	), FilteredInspections_CTE AS
	(
		SELECT g2.inspection_auto FROM GetImplementInspection_CTE AS g2 WHERE g2.rowNumber = 1
	), 
	-- Obtain the user assignments for customers, jobsites and equipment.
	userAssign_CTE AS 
	(
		SELECT	[UserAccessMapId]
			    ,[user_auto]
			    ,[DealershipId]
			    ,[customer_auto]
			    ,[crsf_auto]
			    ,[equipmentid_auto]
			    ,[AccessLevelTypeId]
		FROM	dbo.UserAccessMaps
		WHERE	user_auto = @currentUser

	), userAssign_GlobalAdmin_CTE AS
	(
		SELECT	ua.[crsf_auto], ua.[equipmentid_auto]
		FROM	userAssign_CTE AS ua
		INNER JOIN [dbo].[AccessLevelTypes] AS alt
			ON	alt.AccessLevelTypesId = ua.AccessLevelTypeId
		WHERE	alt.Name = 'Global Administrator'

	), userAssign_Dealership_CTE AS
	(
		SELECT	ua.[crsf_auto], ua.[equipmentid_auto], ua.[customer_auto], ua.[DealershipId]
		FROM	userAssign_CTE AS ua
		INNER JOIN [dbo].[AccessLevelTypes] AS alt
			ON	alt.AccessLevelTypesId = ua.AccessLevelTypeId
		WHERE	ua.DealershipId IS NOT NULL
			AND	(alt.Name = 'Dealership Administrator'
				OR	alt.Name = 'Dealership User')

	), userAssign_Customer_CTE AS
	(
		SELECT	ua.[crsf_auto], ua.[equipmentid_auto], ua.[customer_auto]
		FROM	userAssign_CTE AS ua
		INNER JOIN [dbo].[AccessLevelTypes] AS alt
			ON	alt.AccessLevelTypesId = ua.AccessLevelTypeId
		WHERE	ua.customer_auto IS NOT NULL
			AND	(alt.Name = 'Customer Administrator'
				OR	alt.Name = 'Customer User')
	),
	userAssign_Equipment_CTE AS
	(
		-- Select all equipment if the user is a Global admin.
		SELECT GL.equipmentid_auto, GL.crsf_auto 
		FROM EQUIPMENT AS GL 
		WHERE (SELECT COUNT(*) FROM userAssign_GlobalAdmin_CTE) > 0

		UNION

		-- Select all equipment and jobsites for a specific dealership.
		SELECT eqmt.equipmentid_auto, eqmt.crsf_auto 
		FROM userAssign_Dealership_CTE AS DL
		INNER JOIN CUSTOMER AS cust
			ON cust.DealershipId = DL.DealershipId
		INNER JOIN CRSF AS crsf
			ON crsf.customer_auto = cust.customer_auto
		INNER JOIN EQUIPMENT AS eqmt
			ON eqmt.crsf_auto = crsf.crsf_auto

		UNION

		-- Select only equipment and jobsites for a specific customer.
		SELECT eqmt.equipmentid_auto, eqmt.crsf_auto 
		FROM userAssign_Customer_CTE AS CU 
		INNER JOIN CRSF AS crsf
			ON crsf.customer_auto = CU.customer_auto
		INNER JOIN EQUIPMENT AS eqmt
			ON eqmt.crsf_auto = crsf.crsf_auto
	)

	-- Extract the GET Implement Inspection data.
	INSERT INTO @tblInspection (inspection_auto, InspectionDate, get_auto, Implement,
		equipmentid_auto, Equipment, Model, crsf_auto, Jobsite, Customer, Eval, Flag, InspectionViewed)
	SELECT	gii.inspection_auto
			, CAST(gii.inspection_date AS DATE) AS [InspectionDate]
			, gii.get_auto
			, g.impserial AS [Implement]
			, e.equipmentid_auto
			, e.unitno AS [Equipment]
			, mdl.modelid AS [Model]
			, c.crsf_auto
			, c.site_name AS [Jobsite]
			, cu.cust_name AS [Customer]
			, gii.eval AS [Eval]
			, gii.flag AS [Flag]
			,(
				CASE WHEN (giv.inspections_viewed_auto IS NOT NULL) 
						OR (DATEDIFF(DAY, CAST(gii.inspection_date AS DATE), @currentDate) > @maxAgeForNewStatus_config)
					THEN 1	-- viewed
					ELSE  	--not viewed
					(
						CASE WHEN NOT EXISTS (SELECT * FROM FilteredInspections_CTE AS fc WHERE fc.inspection_auto = gii.inspection_auto)
							THEN 1
							ELSE 0
						END
					)
				END
			) AS [InspectionViewed]
	FROM GET_IMPLEMENT_INSPECTION AS gii
	INNER JOIN [GET] AS g
		ON gii.get_auto = g.get_auto
	INNER JOIN [LU_IMPLEMENT] AS lui
		ON g.implement_auto = lui.implement_auto
	INNER JOIN [EQUIPMENT] AS e
		ON g.equipmentid_auto = e.equipmentid_auto
	INNER JOIN [LU_MMTA] AS mm
		ON e.mmtaid_auto = mm.mmtaid_auto
	INNER JOIN [MODEL] AS mdl
		ON mm.model_auto = mdl.model_auto
	INNER JOIN [CRSF] AS c
		ON e.crsf_auto = c.crsf_auto
	INNER JOIN [CUSTOMER] AS cu
		ON c.customer_auto = cu.customer_auto
	LEFT JOIN [GET_INSPECTIONS_VIEWED] AS giv
		ON gii.inspection_auto = giv.inspection_auto AND giv.user_auto = @currentUser
	INNER JOIN userAssign_Equipment_CTE AS tua
		ON g.equipmentid_auto = tua.equipmentid_auto
	WHERE	(EXISTS (SELECT te.equipment FROM @tblEquipment AS te WHERE e.unitno LIKE ('%' + te.equipment + '%')) OR (@emptyEquipmentStr = 1))
		AND	(EXISTS (SELECT ti.implement FROM @tblImplement AS ti WHERE g.impserial LIKE ('%' + ti.implement + '%')) OR (@emptyImplementStr = 1))
		AND (EXISTS (SELECT tj.jobsite FROM @tblJobsite AS tj WHERE c.site_name LIKE ('%' + tj.jobsite + '%')) OR (@emptyJobsiteStr = 1))
		AND lui.implement_category_auto = @ImplementCategory
	ORDER BY gii.inspection_date;

	-- Process data pages to be returned from stored proc.
	DECLARE @rowsPerPage AS INT = 10;
	DECLARE @pageCount AS INT = 0;
	DECLARE @totalInspections AS INT = 0;
	DECLARE @maxPagesToDisplay AS INT = 10;

	BEGIN TRY
		DECLARE @rowsPerPage_config AS INT;
		SELECT @rowsPerPage_config = value_key FROM [dbo].[GET_CONFIG] WHERE variable_key = 'RowsPerPage';

		IF @rowsPerPage_config IS NOT NULL
			SET @rowsPerPage = @rowsPerPage_config;
	END TRY

	BEGIN CATCH
		SET @rowsPerPage = 10;
	END CATCH

	BEGIN TRY
		DECLARE @maxPagesToDisplay_config AS INT;
		SELECT @maxPagesToDisplay_config = value_key FROM [dbo].[GET_CONFIG] WHERE variable_key = 'MaxPagesToDisplay';

		IF @maxPagesToDisplay_config IS NOT NULL
			SET @maxPagesToDisplay = @maxPagesToDisplay_config;
	END TRY

	BEGIN CATCH
		SET @maxPagesToDisplay = 10
	END CATCH

	-- Return the inspection counts.
	SELECT @totalInspections = COUNT(*), @pageCount = CEILING(COUNT(*) / (@rowsPerPage * 1.0))
	FROM @tblInspection;

	SELECT	@totalInspections AS TotalInspections
			, @pageCount AS TotalPages
			, @rowsPerPage AS RowsPerPage
			, @currentPage AS CurrentPage
			, @maxPagesToDisplay AS MaxPagesToDisplay;

	-- Return the inspection table data, sorted based on the specified column.
	IF @SortColumn = 'DATE'
	BEGIN
		IF @SortDescending = 1
		BEGIN
			WITH SortedInspectionsCTE AS
			(
				SELECT *, ROW_NUMBER() OVER (ORDER BY InspectionDate DESC, inspection_auto DESC) AS RowNumber
				FROM @tblInspection
			)
			SELECT * FROM SortedInspectionsCTE
			WHERE	RowNumber > (@currentPage * @rowsPerPage) 
				AND RowNumber <= ((@currentPage+1) * @rowsPerPage)
				AND @currentPage < @pageCount;
		END
	
		ELSE
		BEGIN
			WITH SortedInspectionsCTE AS
			(
				SELECT *, ROW_NUMBER() OVER (ORDER BY InspectionDate) AS RowNumber
				FROM @tblInspection
			)
			SELECT * FROM SortedInspectionsCTE
			WHERE	RowNumber > (@currentPage * @rowsPerPage) 
				AND RowNumber <= ((@currentPage+1) * @rowsPerPage)
				AND @currentPage < @pageCount;
		END
	END

	IF @SortColumn = 'EVAL'
	BEGIN
		IF @SortDescending = 1
		BEGIN
			WITH SortedInspectionsCTE AS
			(
				SELECT *, ROW_NUMBER() OVER (ORDER BY Eval DESC, inspection_auto DESC) AS RowNumber
				FROM @tblInspection
			)
			SELECT * FROM SortedInspectionsCTE
			WHERE	RowNumber > (@currentPage * @rowsPerPage) 
				AND RowNumber <= ((@currentPage+1) * @rowsPerPage)
				AND @currentPage < @pageCount;
		END
	
		ELSE
		BEGIN
			WITH SortedInspectionsCTE AS
			(
				SELECT *, ROW_NUMBER() OVER (ORDER BY Eval) AS RowNumber
				FROM @tblInspection
			)
			SELECT * FROM SortedInspectionsCTE
			WHERE	RowNumber > (@currentPage * @rowsPerPage) 
				AND RowNumber <= ((@currentPage+1) * @rowsPerPage)
				AND @currentPage < @pageCount;
		END
	END

	IF @SortColumn = 'EQUIPMENT'
	BEGIN
		IF @SortDescending = 1
		BEGIN
			WITH SortedInspectionsCTE AS
			(
				SELECT *, ROW_NUMBER() OVER (ORDER BY Equipment DESC, inspection_auto DESC) AS RowNumber
				FROM @tblInspection
			)
			SELECT * FROM SortedInspectionsCTE
			WHERE	RowNumber > (@currentPage * @rowsPerPage) 
				AND RowNumber <= ((@currentPage+1) * @rowsPerPage)
				AND @currentPage < @pageCount;
		END
	
		ELSE
		BEGIN
			WITH SortedInspectionsCTE AS
			(
				SELECT *, ROW_NUMBER() OVER (ORDER BY Equipment) AS RowNumber
				FROM @tblInspection
			)
			SELECT * FROM SortedInspectionsCTE
			WHERE	RowNumber > (@currentPage * @rowsPerPage) 
				AND RowNumber <= ((@currentPage+1) * @rowsPerPage)
				AND @currentPage < @pageCount;
		END
	END

	IF @SortColumn = 'MODEL'
	BEGIN
		IF @SortDescending = 1
		BEGIN
			WITH SortedInspectionsCTE AS
			(
				SELECT *, ROW_NUMBER() OVER (ORDER BY Model DESC, inspection_auto DESC) AS RowNumber
				FROM @tblInspection
			)
			SELECT * FROM SortedInspectionsCTE
			WHERE	RowNumber > (@currentPage * @rowsPerPage) 
				AND RowNumber <= ((@currentPage+1) * @rowsPerPage)
				AND @currentPage < @pageCount;
		END
	
		ELSE
		BEGIN
			WITH SortedInspectionsCTE AS
			(
				SELECT *, ROW_NUMBER() OVER (ORDER BY Model) AS RowNumber
				FROM @tblInspection
			)
			SELECT * FROM SortedInspectionsCTE
			WHERE	RowNumber > (@currentPage * @rowsPerPage) 
				AND RowNumber <= ((@currentPage+1) * @rowsPerPage)
				AND @currentPage < @pageCount;
		END
	END

	IF @SortColumn = 'IMPLEMENT'
	BEGIN
		IF @SortDescending = 1
		BEGIN
			WITH SortedInspectionsCTE AS
			(
				SELECT *, ROW_NUMBER() OVER (ORDER BY Implement DESC, inspection_auto DESC) AS RowNumber
				FROM @tblInspection
			)
			SELECT * FROM SortedInspectionsCTE
			WHERE	RowNumber > (@currentPage * @rowsPerPage) 
				AND RowNumber <= ((@currentPage+1) * @rowsPerPage)
				AND @currentPage < @pageCount;
		END
	
		ELSE
		BEGIN
			WITH SortedInspectionsCTE AS
			(
				SELECT *, ROW_NUMBER() OVER (ORDER BY Implement) AS RowNumber
				FROM @tblInspection
			)
			SELECT * FROM SortedInspectionsCTE
			WHERE	RowNumber > (@currentPage * @rowsPerPage) 
				AND RowNumber <= ((@currentPage+1) * @rowsPerPage)
				AND @currentPage < @pageCount;
		END
	END

	IF @SortColumn = 'JOBSITE'
	BEGIN
		IF @SortDescending = 1
		BEGIN
			WITH SortedInspectionsCTE AS
			(
				SELECT *, ROW_NUMBER() OVER (ORDER BY Jobsite DESC, inspection_auto DESC) AS RowNumber
				FROM @tblInspection
			)
			SELECT * FROM SortedInspectionsCTE
			WHERE	RowNumber > (@currentPage * @rowsPerPage) 
				AND RowNumber <= ((@currentPage+1) * @rowsPerPage)
				AND @currentPage < @pageCount;
		END
	
		ELSE
		BEGIN
			WITH SortedInspectionsCTE AS
			(
				SELECT *, ROW_NUMBER() OVER (ORDER BY Jobsite) AS RowNumber
				FROM @tblInspection
			)
			SELECT * FROM SortedInspectionsCTE
			WHERE	RowNumber > (@currentPage * @rowsPerPage) 
				AND RowNumber <= ((@currentPage+1) * @rowsPerPage)
				AND @currentPage < @pageCount;
		END
	END

	IF @SortColumn = 'CUSTOMER'
	BEGIN
		IF @SortDescending = 1
		BEGIN
			WITH SortedInspectionsCTE AS
			(
				SELECT *, ROW_NUMBER() OVER (ORDER BY Customer DESC, inspection_auto DESC) AS RowNumber
				FROM @tblInspection
			)
			SELECT * FROM SortedInspectionsCTE
			WHERE	RowNumber > (@currentPage * @rowsPerPage) 
				AND RowNumber <= ((@currentPage+1) * @rowsPerPage)
				AND @currentPage < @pageCount;
		END
	
		ELSE
		BEGIN
			WITH SortedInspectionsCTE AS
			(
				SELECT *, ROW_NUMBER() OVER (ORDER BY Customer) AS RowNumber
				FROM @tblInspection
			)
			SELECT * FROM SortedInspectionsCTE
			WHERE	RowNumber > (@currentPage * @rowsPerPage) 
				AND RowNumber <= ((@currentPage+1) * @rowsPerPage)
				AND @currentPage < @pageCount;
		END
	END
END


";
    }
}
