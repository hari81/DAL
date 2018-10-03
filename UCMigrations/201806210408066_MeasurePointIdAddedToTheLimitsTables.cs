namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeasurePointIdAddedToTheLimitsTables : DbMigration
    {
        public override void Up()
        {

            Sql(@"

	SET NOCOUNT ON;
	DECLARE @rowId BIGINT
	DECLARE @compartId BIGINT
	DECLARE @toolId BIGINT

	DECLARE myCursor1 CURSOR FORWARD_ONLY FOR
    SELECT wornLimit.track_compart_worn_limit_cat_auto, wornLimit.compartid_auto, wornLimit.track_tools_auto
	FROM TRACK_COMPART_WORN_LIMIT_CAT wornLimit 
	OPEN myCursor1;
	FETCH NEXT FROM myCursor1 INTO @rowId , @compartId, @toolId
	WHILE @@FETCH_STATUS = 0 
	BEGIN

	delete TRACK_COMPART_WORN_LIMIT_CAT where track_compart_worn_limit_cat_auto <> @rowId and compartid_auto = @compartId and track_tools_auto = @toolId


    FETCH NEXT FROM myCursor1 INTO @rowId , @compartId, @toolId
	END
	CLOSE myCursor1;
	DEALLOCATE myCursor1;



	DECLARE myCursor2 CURSOR FORWARD_ONLY FOR
    SELECT wornLimit.track_compart_worn_limit_hitachi_auto, wornLimit.compartid_auto, wornLimit.track_tools_auto
	FROM TRACK_COMPART_WORN_LIMIT_HITACHI wornLimit 
	OPEN myCursor2;
	FETCH NEXT FROM myCursor2 INTO @rowId , @compartId, @toolId
	WHILE @@FETCH_STATUS = 0 
	BEGIN

	delete TRACK_COMPART_WORN_LIMIT_HITACHI where track_compart_worn_limit_hitachi_auto <> @rowId and compartid_auto = @compartId and track_tools_auto = @toolId


    FETCH NEXT FROM myCursor2 INTO @rowId , @compartId, @toolId
	END
	CLOSE myCursor2;
	DEALLOCATE myCursor2;



    DECLARE myCursor3 CURSOR FORWARD_ONLY FOR
    SELECT wornLimit.track_compart_worn_limit_itm_auto, wornLimit.compartid_auto, wornLimit.track_tools_auto
	FROM TRACK_COMPART_WORN_LIMIT_ITM wornLimit 
	OPEN myCursor3;
	FETCH NEXT FROM myCursor3 INTO @rowId , @compartId, @toolId
	WHILE @@FETCH_STATUS = 0 
	BEGIN

	delete TRACK_COMPART_WORN_LIMIT_ITM where track_compart_worn_limit_itm_auto <> @rowId and compartid_auto = @compartId and track_tools_auto = @toolId


    FETCH NEXT FROM myCursor3 INTO @rowId , @compartId, @toolId
	END
	CLOSE myCursor3;
	DEALLOCATE myCursor3;



	DECLARE myCursor4 CURSOR FORWARD_ONLY FOR
    SELECT wornLimit.track_compart_worn_limit_johndeere_auto, wornLimit.compartid_auto, wornLimit.track_tools_auto
	FROM TRACK_COMPART_WORN_LIMIT_JOHNDEERE wornLimit 
	OPEN myCursor4;
	FETCH NEXT FROM myCursor4 INTO @rowId , @compartId, @toolId
	WHILE @@FETCH_STATUS = 0 
	BEGIN

	delete TRACK_COMPART_WORN_LIMIT_JOHNDEERE where track_compart_worn_limit_johndeere_auto <> @rowId and compartid_auto = @compartId and track_tools_auto = @toolId


    FETCH NEXT FROM myCursor4 INTO @rowId , @compartId, @toolId
	END
	CLOSE myCursor4;
	DEALLOCATE myCursor4;


	DECLARE myCursor5 CURSOR FORWARD_ONLY FOR
    SELECT wornLimit.track_compart_worn_limit_komatsu_auto, wornLimit.compartid_auto, wornLimit.track_tools_auto
	FROM TRACK_COMPART_WORN_LIMIT_KOMATSU wornLimit 
	OPEN myCursor5;
	FETCH NEXT FROM myCursor5 INTO @rowId , @compartId, @toolId
	WHILE @@FETCH_STATUS = 0 
	BEGIN

	delete TRACK_COMPART_WORN_LIMIT_KOMATSU where track_compart_worn_limit_komatsu_auto <> @rowId and compartid_auto = @compartId and track_tools_auto = @toolId


    FETCH NEXT FROM myCursor5 INTO @rowId , @compartId, @toolId
	END
	CLOSE myCursor5;
	DEALLOCATE myCursor5;



	DECLARE myCursor6 CURSOR FORWARD_ONLY FOR
    SELECT wornLimit.track_compart_worn_limit_liebherr_auto, wornLimit.compartid_auto, wornLimit.track_tools_auto
	FROM TRACK_COMPART_WORN_LIMIT_LIEBHERR wornLimit 
	OPEN myCursor6;
	FETCH NEXT FROM myCursor6 INTO @rowId , @compartId, @toolId
	WHILE @@FETCH_STATUS = 0 
	BEGIN

	delete TRACK_COMPART_WORN_LIMIT_LIEBHERR where track_compart_worn_limit_liebherr_auto <> @rowId and compartid_auto = @compartId and track_tools_auto = @toolId


    FETCH NEXT FROM myCursor6 INTO @rowId , @compartId, @toolId
	END
	CLOSE myCursor6;
	DEALLOCATE myCursor6;

");

            DropIndex("dbo.TRACK_COMPART_WORN_LIMIT_CAT", new[] { "compartid_auto" });
            DropIndex("dbo.TRACK_COMPART_WORN_LIMIT_CAT", new[] { "track_tools_auto" });
            DropIndex("dbo.TRACK_COMPART_WORN_LIMIT_ITM", new[] { "compartid_auto" });
            DropIndex("dbo.TRACK_COMPART_WORN_LIMIT_ITM", new[] { "track_tools_auto" });
            AddColumn("dbo.TRACK_COMPART_WORN_LIMIT_CAT", "MeasurePointId", c => c.Int());
            AddColumn("dbo.TRACK_COMPART_WORN_LIMIT_ITM", "MeasurePointId", c => c.Int());
            AddColumn("dbo.MEASUREMENT_POINT_RECORD", "Worn", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.MEASUREMENT_POINT_RECORD", "Eval", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TRACK_COMPART_WORN_LIMIT_HITACHI", "MeasurePointId", c => c.Int());
            AddColumn("dbo.TRACK_COMPART_WORN_LIMIT_KOMATSU", "MeasurePointId", c => c.Int());
            AddColumn("dbo.TRACK_COMPART_WORN_LIMIT_LIEBHERR", "MeasurePointId", c => c.Int());
            CreateIndex("dbo.TRACK_COMPART_WORN_LIMIT_CAT", new[] { "compartid_auto", "track_tools_auto", "MeasurePointId" }, unique: true, name: "IX_CATCompartMeasurementTool");
            CreateIndex("dbo.TRACK_COMPART_WORN_LIMIT_ITM", new[] { "compartid_auto", "track_tools_auto", "MeasurePointId" }, unique: true, name: "IX_ITMCompartMeasurementTool");
            CreateIndex("dbo.TRACK_COMPART_WORN_LIMIT_HITACHI", new[] { "compartid_auto", "track_tools_auto", "MeasurePointId" }, unique: true, name: "IX_HITACHICompartMeasurementTool");
            CreateIndex("dbo.TRACK_COMPART_WORN_LIMIT_KOMATSU", new[] { "compartid_auto", "track_tools_auto", "MeasurePointId" }, unique: true, name: "IX_KOMATSUCompartMeasurementTool");
            CreateIndex("dbo.TRACK_COMPART_WORN_LIMIT_LIEBHERR", new[] { "compartid_auto", "track_tools_auto", "MeasurePointId" }, unique: true, name: "IX_LIEBHERRCompartMeasurementTool");
            AddForeignKey("dbo.TRACK_COMPART_WORN_LIMIT_CAT", "MeasurePointId", "dbo.COMPART_MEASUREMENT_POINT", "Id");
            AddForeignKey("dbo.TRACK_COMPART_WORN_LIMIT_ITM", "MeasurePointId", "dbo.COMPART_MEASUREMENT_POINT", "Id");
            AddForeignKey("dbo.TRACK_COMPART_WORN_LIMIT_HITACHI", "MeasurePointId", "dbo.COMPART_MEASUREMENT_POINT", "Id");
            AddForeignKey("dbo.TRACK_COMPART_WORN_LIMIT_KOMATSU", "MeasurePointId", "dbo.COMPART_MEASUREMENT_POINT", "Id");
            AddForeignKey("dbo.TRACK_COMPART_WORN_LIMIT_LIEBHERR", "MeasurePointId", "dbo.COMPART_MEASUREMENT_POINT", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TRACK_COMPART_WORN_LIMIT_LIEBHERR", "MeasurePointId", "dbo.COMPART_MEASUREMENT_POINT");
            DropForeignKey("dbo.TRACK_COMPART_WORN_LIMIT_KOMATSU", "MeasurePointId", "dbo.COMPART_MEASUREMENT_POINT");
            DropForeignKey("dbo.TRACK_COMPART_WORN_LIMIT_HITACHI", "MeasurePointId", "dbo.COMPART_MEASUREMENT_POINT");
            DropForeignKey("dbo.TRACK_COMPART_WORN_LIMIT_ITM", "MeasurePointId", "dbo.COMPART_MEASUREMENT_POINT");
            DropForeignKey("dbo.TRACK_COMPART_WORN_LIMIT_CAT", "MeasurePointId", "dbo.COMPART_MEASUREMENT_POINT");
            DropIndex("dbo.TRACK_COMPART_WORN_LIMIT_LIEBHERR", "IX_LIEBHERRCompartMeasurementTool");
            DropIndex("dbo.TRACK_COMPART_WORN_LIMIT_KOMATSU", "IX_KOMATSUCompartMeasurementTool");
            DropIndex("dbo.TRACK_COMPART_WORN_LIMIT_HITACHI", "IX_HITACHICompartMeasurementTool");
            DropIndex("dbo.TRACK_COMPART_WORN_LIMIT_ITM", "IX_ITMCompartMeasurementTool");
            DropIndex("dbo.TRACK_COMPART_WORN_LIMIT_CAT", "IX_CATCompartMeasurementTool");
            DropColumn("dbo.TRACK_COMPART_WORN_LIMIT_LIEBHERR", "MeasurePointId");
            DropColumn("dbo.TRACK_COMPART_WORN_LIMIT_KOMATSU", "MeasurePointId");
            DropColumn("dbo.TRACK_COMPART_WORN_LIMIT_HITACHI", "MeasurePointId");
            DropColumn("dbo.MEASUREMENT_POINT_RECORD", "Eval");
            DropColumn("dbo.MEASUREMENT_POINT_RECORD", "Worn");
            DropColumn("dbo.TRACK_COMPART_WORN_LIMIT_ITM", "MeasurePointId");
            DropColumn("dbo.TRACK_COMPART_WORN_LIMIT_CAT", "MeasurePointId");
            CreateIndex("dbo.TRACK_COMPART_WORN_LIMIT_ITM", "track_tools_auto");
            CreateIndex("dbo.TRACK_COMPART_WORN_LIMIT_ITM", "compartid_auto");
            CreateIndex("dbo.TRACK_COMPART_WORN_LIMIT_CAT", "track_tools_auto");
            CreateIndex("dbo.TRACK_COMPART_WORN_LIMIT_CAT", "compartid_auto");
        }
    }
}
