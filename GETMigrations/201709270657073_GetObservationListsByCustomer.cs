namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetObservationListsByCustomer : DbMigration
    {
        public override void Up()
        {
            Sql(alterProc1);
        }
        
        public override void Down()
        {
        }

        public const string alterProc1 = @"
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		VijayMD
-- Create date: 02-May-2017
-- Description:	Retrive the Observation lists.
-- =============================================
ALTER PROCEDURE [dbo].[GT_Load_observation_lists]
	@customer_auto BIGINT = 0
AS
BEGIN

	WITH count_observations AS
	(
		SELECT observation_list_auto, COUNT(*) AS numObservations
		FROM GET_OBSERVATIONS
		WHERE active = 1
		GROUP BY observation_list_auto
	)
	SELECT gol.observation_list_auto, gol.name, co.numObservations
	FROM GET_OBSERVATION_LIST AS gol
	INNER JOIN count_observations AS co
		ON co.observation_list_auto = gol.observation_list_auto
	WHERE gol.active = 1 AND gol.customer_auto = @customer_auto;

	SELECT (g.impserial + ' : ' + lct.comparttype) AS componenttype, gc.observation_list_auto
	FROM GET_COMPONENT AS gc
	INNER JOIN [GET] AS g
		ON g.get_auto = gc.get_auto
	INNER JOIN [GET_SCHEMATIC_COMPONENT] AS gsc
		ON gc.schematic_component_auto = gsc.schematic_component_auto
	INNER JOIN [LU_COMPART_TYPE] AS lct
		ON gsc.comparttype_auto = lct.comparttype_auto
	WHERE gc.observation_list_auto > 0 
	ORDER BY gc.observation_list_auto;

END

";
    }
}
