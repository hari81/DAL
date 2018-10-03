namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateObservationLists : DbMigration
    {
        public override void Up()
        {
            Sql(alterProc1);
        }
        
        public override void Down()
        {
        }

        public const string alterProc1 = @"
/****** Object:  StoredProcedure [dbo].[GT_Save_GET_OBSERVATION_LIST]    Script Date: 28/09/2017 8:55:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		VijayMD
-- Create date: 02-May-2017
-- Description:	Save the GET_OBSERVATION_LIST table data.
-- =============================================
ALTER PROCEDURE [dbo].[GT_Save_GET_OBSERVATION_LIST]
	@name					VARCHAR(128),
	@create_user			INT,
	@customer_auto			BIGINT,
	@observation_list_auto	INT	OUTPUT
AS
BEGIN
	DECLARE @rows_updated AS INT = 0;

	INSERT INTO GET_OBSERVATION_LIST (name, create_user, customer_auto, create_date, active)
	VALUES (@name, @create_user, @customer_auto, GETDATE(), 1);

	SELECT @rows_updated = @@ROWCOUNT;

	IF @rows_updated = 1
		SET @observation_list_auto = (SELECT SCOPE_IDENTITY());

	ELSE
		SET @observation_list_auto = -1;
END
";
    }
}
