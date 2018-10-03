namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class spGetUCSystemSerials : DbMigration
    {
        public override void Up()
        {
            Sql(spGetUCSystemSerialsSql);
        }
        
        public override void Down()
        {
        }
        string spGetUCSystemSerialsSql = @"
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spGetUCSystemSerials] 
	@crsf_auto			INT,
	@compart			VARCHAR(6),
	@equipmentid_auto	INT
AS
BEGIN
	DECLARE @model_auto INT

	SELECT @model_auto = mmta.model_auto FROM EQUIPMENT e 
		INNER JOIN LU_MMTA mmta ON e.mmtaid_auto = mmta.mmtaid_auto 
	WHERE e.equipmentid_auto = @equipmentid_auto 

	SELECT DISTINCT lms.Module_sub_auto,lms.Serialno FROM LU_Module_Sub lms
		INNER JOIN GENERAL_EQ_UNIT geu ON lms.Module_sub_auto = geu.module_ucsub_auto
		INNER JOIN LU_COMPART lc ON lc.compartid_auto = geu.compartid_auto
		INNER JOIN LU_COMPART_TYPE lct ON lc.comparttype_auto = lct.comparttype_auto

	WHERE lms.equipmentid_auto IS NULL AND lct.comparttype = @compart AND lms.model_auto = @model_auto and lms.crsf_auto = @crsf_auto
END
";
    }
}
