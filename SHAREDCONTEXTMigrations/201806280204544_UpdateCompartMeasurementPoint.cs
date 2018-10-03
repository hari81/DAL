namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCompartMeasurementPoint : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.MEASUREMENT_POSSIBLE_TOOLS",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            MeasurePointId = c.Int(nullable: false),
            //            ToolId = c.Int(nullable: false),
            //            HowToUseImage = c.Binary(),
            //            HowToUseText = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.COMPART_MEASUREMENT_POINT", t => t.MeasurePointId, cascadeDelete: true)
            //    .ForeignKey("dbo.TRACK_TOOL", t => t.ToolId, cascadeDelete: true)
            //    .Index(t => new { t.MeasurePointId, t.ToolId }, unique: true, name: "IX_MeasurePointTool");
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.MEASUREMENT_POSSIBLE_TOOLS", "ToolId", "dbo.TRACK_TOOL");
            //DropForeignKey("dbo.MEASUREMENT_POSSIBLE_TOOLS", "MeasurePointId", "dbo.COMPART_MEASUREMENT_POINT");
            //DropIndex("dbo.MEASUREMENT_POSSIBLE_TOOLS", "IX_MeasurePointTool");
            //DropTable("dbo.MEASUREMENT_POSSIBLE_TOOLS");
        }
    }
}
