namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixSchematicAutoMultiple : DbMigration
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
-- Create date: 18-Apr-2017
-- Description:	Update the 'Schematic Auto Multiple' column when adding a new schematic. 
-- =============================================
ALTER PROCEDURE [dbo].[GT_Update_LU_IMPLEMENT_schematic_auto_multiple]
	@implement_auto bigint,
	@schematic_auto bigint
AS
BEGIN
	BEGIN TRAN

	UPDATE LU_IMPLEMENT
	SET schematic_auto_multiple = COALESCE(
		(CASE WHEN LEN(schematic_auto_multiple) = 0
			THEN CAST(@schematic_auto AS VARCHAR)
			ELSE (schematic_auto_multiple + '_' + CAST(@schematic_auto AS VARCHAR))
		END), CAST(@schematic_auto AS VARCHAR))
	WHERE implement_auto = @implement_auto;

	IF @@ROWCOUNT > 1
		ROLLBACK TRAN

	COMMIT TRAN

END


";
    }
}
