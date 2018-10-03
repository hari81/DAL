namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class return_track_report_recommendationsTT464 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                ALTER PROCEDURE[dbo].[return_track_report_recommendations]
        @quote_auto INT,
   @position VARCHAR(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
    SET NOCOUNT ON;
        DECLARE @pos INT
        SELECT @pos = CASE @position WHEN 'L' THEN 1 ELSE 2 END

        SELECT  tu.equnit_auto as CompId, lct.comparttype + ': ' +comp.compart AS[Component],
                tot.action_description AS[Action],
                isnull(tqd.start_smu, 0) AS[StartSMU],
			tqd.price[Cost]
    FROM  TRACK_QUOTE_DETAIL tqd

    INNER JOIN TRACK_ACTION_TYPE tot ON tqd.op_type_auto = tot.action_type_auto
    INNER JOIN GENERAL_EQ_UNIT tu ON tqd.track_unit_auto = tu.equnit_auto

    INNER JOIN LU_COMPART comp ON tu.compartid_auto = comp.compartid_auto

    INNER JOIN LU_COMPART_TYPE lct ON comp.comparttype_auto = lct.comparttype_auto

    INNER JOIN TRACK_QUOTE tq ON tq.quote_auto = tqd.quote_auto

    WHERE tqd.quote_auto = @quote_auto AND tu.side = @pos
    --ORDER BY comp.compart
END

                ");
        }
        
        public override void Down()
        {
            Sql(@"

ALTER PROCEDURE [dbo].[return_track_report_recommendations] 
	@quote_auto INT,
	@position VARCHAR(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @pos INT
	SELECT @pos = CASE @position WHEN 'L' THEN 1 ELSE 2 END

    SELECT	comp.compart AS [Component], 
			tot.action_description AS [Action],  
			isnull(tqd.start_smu,0) AS [StartSMU]
	FROM  TRACK_QUOTE_DETAIL tqd 
	INNER JOIN TRACK_ACTION_TYPE tot ON tqd.op_type_auto = tot.action_type_auto
	INNER JOIN GENERAL_EQ_UNIT tu ON tqd.track_unit_auto = tu.equnit_auto
	INNER JOIN LU_COMPART comp ON tu.compartid_auto = comp.compartid_auto
	WHERE tqd.quote_auto = @quote_auto AND tu.side = @pos
	--ORDER BY comp.compart
END


");
        }
    }
}
