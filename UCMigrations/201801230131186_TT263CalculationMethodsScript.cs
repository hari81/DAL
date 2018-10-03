namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TT263CalculationMethodsScript : DbMigration
    {
        public override void Up()
        {
            //This script copies all the records from Hitachi to LIEBHERR worn limit table.
            Sql(HitachiCursor);
        }
        
        public override void Down()
        {
        }

        string HitachiCursor = @"
DECLARE @HitachiId BIGINT
DECLARE @CompartId BIGINT
DECLARE @ToolId BIGINT

DECLARE HitachiCursor CURSOR FORWARD_ONLY FOR
SELECT track_compart_worn_limit_hitachi_auto, compartid_auto, track_tools_auto FROM TRACK_COMPART_WORN_LIMIT_HITACHI
OPEN HitachiCursor;
	FETCH NEXT FROM HitachiCursor INTO @HitachiId, @CompartId, @ToolId
	WHILE @@FETCH_STATUS = 0 
	BEGIN

	IF(SELECT COUNT (*) FROM TRACK_COMPART_WORN_LIMIT_LIEBHERR where compartid_auto = @CompartId AND track_tools_auto = @ToolId) = 0
	BEGIN
	INSERT INTO TRACK_COMPART_WORN_LIMIT_LIEBHERR (compartid_auto, track_tools_auto, impact_slope, normal_slope, impact_intercept, normal_intercept) 
	select compartid_auto, track_tools_auto, impact_slope, normal_slope, impact_intercept, normal_intercept FROM TRACK_COMPART_WORN_LIMIT_HITACHI where track_compart_worn_limit_hitachi_auto = @HitachiId
	END

	FETCH NEXT FROM HitachiCursor INTO @HitachiId, @CompartId, @ToolId
	END

CLOSE HitachiCursor;
DEALLOCATE HitachiCursor;

update TRACK_COMPART_EXT SET track_compart_worn_calc_method_auto = 5 where track_compart_worn_calc_method_auto = 4
";

    }
}
