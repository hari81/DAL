namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeasurePointIdAddedToTheLimitsTables : DbMigration
    {
        public override void Up()
        {/*
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
            */
        }
        
        public override void Down()
        {/*
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
            CreateIndex("dbo.TRACK_COMPART_WORN_LIMIT_CAT", "compartid_auto");*/
        }
    }
}
