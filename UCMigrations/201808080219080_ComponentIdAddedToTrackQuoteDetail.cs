namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComponentIdAddedToTrackQuoteDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TRACK_QUOTE_DETAIL", "ComponentId", c => c.Long(nullable: false));
            Sql(@"	DECLARE @Id BIGINT
	DECLARE @ComponentIdStr VARCHAR(10)

	DECLARE ChildComponentCursor CURSOR FORWARD_ONLY FOR
	SELECT quote_detail_auto, track_unit_auto FROM TRACK_QUOTE_DETAIL 

	OPEN ChildComponentCursor;
	Fetch next from ChildComponentCursor INTO @Id, @ComponentIdStr
	WHILE @@FETCH_STATUS = 0
	BEGIN

	UPDATE TRACK_QUOTE_DETAIL SET ComponentId = CONVERT(INT, @ComponentIdStr) WHERE quote_detail_auto = @Id

	FETCH NEXT FROM ChildComponentCursor INTO @Id, @ComponentIdStr
	END
	Close ChildComponentCursor;
	DEALLOCATE ChildComponentCursor;");
        }
        
        public override void Down()
        {
            DropColumn("dbo.TRACK_QUOTE_DETAIL", "ComponentId");
        }
    }
}
