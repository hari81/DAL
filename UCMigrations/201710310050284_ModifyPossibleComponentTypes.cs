namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyPossibleComponentTypes : DbMigration
    {
        public override void Up()
        {
            Sql(return_possible_component_types_for_equnit_auto);
        }
        
        public override void Down()
        {
        }
        string return_possible_component_types_for_equnit_auto = @"
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Thomas V
-- Create date: 22/03/2017
-- Description:	Returns a list of possible component types that can replace a given equnit_auto
-- =============================================
ALTER PROCEDURE [dbo].[return_possible_component_types_for_equnit_auto] 
	-- Add the parameters for the stored procedure here
	@equnit_auto int
AS
BEGIN
	DECLARE @model_auto int,@comparttype_auto int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	select @model_auto= model.model_auto, @comparttype_auto= compart.comparttype_auto from GENERAL_EQ_UNIT geq
	inner join LU_Module_Sub ms ON ms.Module_sub_auto = geq.module_ucsub_auto
	inner join MODEL model on ms.model_auto = model.model_auto
	inner join LU_COMPART compart on geq.compartid_auto = compart.compartid_auto
	where equnit_auto=@equnit_auto

	select compartid, compart, cmp.compartid_auto from TRACK_COMPART_MODEL_MAPPING mm
	inner join LU_COMPART cmp on mm.compartid_auto = cmp.compartid_auto 
	where model_auto=@model_auto and cmp.comparttype_auto=@comparttype_auto
END
";
    }
}
