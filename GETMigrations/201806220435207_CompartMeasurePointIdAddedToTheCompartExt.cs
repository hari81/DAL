namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompartMeasurePointIdAddedToTheCompartExt : DbMigration
    {
        public override void Up()
        {/*
            DropIndex("dbo.TRACK_COMPART_EXT", new[] { "compartid_auto" });
            DropIndex("dbo.TRACK_COMPART_EXT", new[] { "tools_auto" });
            AddColumn("dbo.TRACK_COMPART_EXT", "CompartMeasurePointId", c => c.Int());
            CreateIndex("dbo.TRACK_COMPART_EXT", new[] { "compartid_auto", "CompartMeasurePointId", "tools_auto" }, unique: true, name: "IX_CompartMeasurementToolExt");
            AddForeignKey("dbo.TRACK_COMPART_EXT", "CompartMeasurePointId", "dbo.COMPART_MEASUREMENT_POINT", "Id");*/
        }
        
        public override void Down()
        {/*
            DropForeignKey("dbo.TRACK_COMPART_EXT", "CompartMeasurePointId", "dbo.COMPART_MEASUREMENT_POINT");
            DropIndex("dbo.TRACK_COMPART_EXT", "IX_CompartMeasurementToolExt");
            DropColumn("dbo.TRACK_COMPART_EXT", "CompartMeasurePointId");
            CreateIndex("dbo.TRACK_COMPART_EXT", "tools_auto");
            CreateIndex("dbo.TRACK_COMPART_EXT", "compartid_auto");*/
        }
    }
}
