namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSPSetAllChildPosition : DbMigration
    {
        public override void Up()
        {
            Sql(@"

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mason
-- Create date: 30 Jul 2018
-- Description:	Adding 
-- =============================================
CREATE PROCEDURE [dbo].[SetAllChildPosition] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @SystemId BIGINT
	

	DECLARE SystemCursor CURSOR FORWARD_ONLY FOR
    SELECT Module_sub_auto from LU_Module_Sub
	OPEN SystemCursor;
	FETCH NEXT FROM SystemCursor INTO @SystemId
	WHILE @@FETCH_STATUS = 0 
	BEGIN

	DECLARE @ComponentId BIGINT
	DECLARE @CompartId BIGINT
	DECLARE @Pos INT

	DECLARE ComponentCursor CURSOR FORWARD_ONLY FOR
	SELECT equnit_auto, compartid_auto, pos FROM GENERAL_EQ_UNIT WHERE module_ucsub_auto = @SystemId
	OPEN ComponentCursor;
	Fetch next from ComponentCursor INTO @ComponentId, @CompartId, @Pos
	WHILE @@FETCH_STATUS = 0
	BEGIN



	DECLARE @ChildComponentId BIGINT
	DECLARE @ChildCompartId BIGINT
	DECLARE @ChildPosition INT
	SET @ChildPosition = @Pos + 1;
	DECLARE ChildComponentCursor CURSOR FORWARD_ONLY FOR
	SELECT equnit_auto, compartid_auto FROM GENERAL_EQ_UNIT geu
	INNER JOIN COMPART_PARENT_RELATION parentrelation
	on parentrelation.ChildCompartId = geu.compartid_auto
	WHERE module_ucsub_auto = @SystemId and parentrelation.ParentCompartId = @CompartId
	ORDER BY geu.compartid_auto
	OPEN ChildComponentCursor;
	Fetch next from ChildComponentCursor INTO @ChildComponentId, @ChildCompartId
	WHILE @@FETCH_STATUS = 0
	BEGIN

	UPDATE GENERAL_EQ_UNIT SET pos = @ChildPosition WHERE equnit_auto = @ChildComponentId


	SET @ChildPosition = @ChildPosition + 1;
	FETCH NEXT FROM ChildComponentCursor INTO @ChildComponentId, @ChildCompartId
	END
	Close ChildComponentCursor;
	DEALLOCATE ChildComponentCursor;




	FETCH NEXT FROM ComponentCursor INTO @ComponentId, @CompartId, @Pos
	END
	Close ComponentCursor;
	DEALLOCATE ComponentCursor;
	
	FETCH NEXT FROM SystemCursor INTO @SystemId
	END
	CLOSE SystemCursor;
	DEALLOCATE SystemCursor;
END

");
        }
        
        public override void Down()
        {
        }
    }
}
