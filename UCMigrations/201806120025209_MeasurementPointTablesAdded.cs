namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeasurementPointTablesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MEASUREMENT_POINT_RECORD",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InspectionDetailId = c.Int(nullable: false),
                        CompartMeasurePointId = c.Int(nullable: false),
                        InboardOutborad = c.Int(nullable: false),
                        ToolId = c.Int(nullable: false),
                        Reading = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MeasureNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.COMPART_MEASUREMENT_POINT", t => t.CompartMeasurePointId, cascadeDelete: true)
                .ForeignKey("dbo.TRACK_INSPECTION_DETAIL", t => t.InspectionDetailId, cascadeDelete: true)
                .ForeignKey("dbo.TRACK_TOOL", t => t.ToolId, cascadeDelete: true)
                .Index(t => t.InspectionDetailId)
                .Index(t => t.CompartMeasurePointId)
                .Index(t => t.ToolId);
            
            CreateTable(
                "dbo.COMPART_MEASUREMENT_POINT",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompartId = c.Int(nullable: false),
                        Name = c.String(maxLength: 250),
                        Order = c.Int(nullable: false),
                        DefaultNumberOfMeasurements = c.Int(nullable: false),
                        DefaultToolId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LU_COMPART", t => t.CompartId, cascadeDelete: true)
                .ForeignKey("dbo.TRACK_TOOL", t => t.DefaultToolId)
                .Index(t => t.CompartId)
                .Index(t => t.DefaultToolId);
            
            CreateTable(
                "dbo.MEASUREMENT_POSSIBLE_TOOLS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeasurePointId = c.Int(nullable: false),
                        ToolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.COMPART_MEASUREMENT_POINT", t => t.MeasurePointId, cascadeDelete: true)
                .ForeignKey("dbo.TRACK_TOOL", t => t.ToolId, cascadeDelete: true)
                .Index(t => new { t.MeasurePointId, t.ToolId }, unique: true, name: "IX_MeasurePointTool");
            
            CreateTable(
                "dbo.MEASUREPOINT_RECORD_IMAGES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeasurePointRecordId = c.Int(nullable: false),
                        Data = c.Binary(),
                        Title = c.String(maxLength: 250),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MEASUREMENT_POINT_RECORD", t => t.MeasurePointRecordId, cascadeDelete: true)
                .Index(t => t.MeasurePointRecordId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MEASUREPOINT_RECORD_IMAGES", "MeasurePointRecordId", "dbo.MEASUREMENT_POINT_RECORD");
            DropForeignKey("dbo.MEASUREMENT_POSSIBLE_TOOLS", "ToolId", "dbo.TRACK_TOOL");
            DropForeignKey("dbo.MEASUREMENT_POSSIBLE_TOOLS", "MeasurePointId", "dbo.COMPART_MEASUREMENT_POINT");
            DropForeignKey("dbo.MEASUREMENT_POINT_RECORD", "ToolId", "dbo.TRACK_TOOL");
            DropForeignKey("dbo.MEASUREMENT_POINT_RECORD", "InspectionDetailId", "dbo.TRACK_INSPECTION_DETAIL");
            DropForeignKey("dbo.MEASUREMENT_POINT_RECORD", "CompartMeasurePointId", "dbo.COMPART_MEASUREMENT_POINT");
            DropForeignKey("dbo.COMPART_MEASUREMENT_POINT", "DefaultToolId", "dbo.TRACK_TOOL");
            DropForeignKey("dbo.COMPART_MEASUREMENT_POINT", "CompartId", "dbo.LU_COMPART");
            DropIndex("dbo.MEASUREPOINT_RECORD_IMAGES", new[] { "MeasurePointRecordId" });
            DropIndex("dbo.MEASUREMENT_POSSIBLE_TOOLS", "IX_MeasurePointTool");
            DropIndex("dbo.COMPART_MEASUREMENT_POINT", new[] { "DefaultToolId" });
            DropIndex("dbo.COMPART_MEASUREMENT_POINT", new[] { "CompartId" });
            DropIndex("dbo.MEASUREMENT_POINT_RECORD", new[] { "ToolId" });
            DropIndex("dbo.MEASUREMENT_POINT_RECORD", new[] { "CompartMeasurePointId" });
            DropIndex("dbo.MEASUREMENT_POINT_RECORD", new[] { "InspectionDetailId" });
            DropTable("dbo.MEASUREPOINT_RECORD_IMAGES");
            DropTable("dbo.MEASUREMENT_POSSIBLE_TOOLS");
            DropTable("dbo.COMPART_MEASUREMENT_POINT");
            DropTable("dbo.MEASUREMENT_POINT_RECORD");
        }
    }
}
