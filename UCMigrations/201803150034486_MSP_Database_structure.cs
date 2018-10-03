namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MSP_Database_structure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MeasurePointTools",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MeasurePointTypeID = c.Int(nullable: false),
                        ToolID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MeasurePointTypes", t => t.MeasurePointTypeID, cascadeDelete: true)
                .ForeignKey("dbo.TRACK_TOOL", t => t.ToolID, cascadeDelete: true)
                .Index(t => t.MeasurePointTypeID)
                .Index(t => t.ToolID);
            
            CreateTable(
                "dbo.MeasurePointTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MeasurePointTypeDescription = c.String(),
                        LUCompartTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ModelCommentMaps",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CommentTypeID = c.Int(nullable: false),
                        ModelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MODEL", t => t.ModelID, cascadeDelete: true)
                .ForeignKey("dbo.TrackInspectionCommentTypes", t => t.CommentTypeID, cascadeDelete: true)
                .Index(t => t.CommentTypeID)
                .Index(t => t.ModelID);
            
            CreateTable(
                "dbo.TrackInspectionCommentTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CommentDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TrackInspectionCommentImages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CommentID = c.Int(nullable: false),
                        ImageData = c.Binary(),
                        ImageComment = c.String(),
                        ImageTitle = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TrackInspectionComments", t => t.CommentID, cascadeDelete: true)
                .Index(t => t.CommentID);
            
            CreateTable(
                "dbo.TrackInspectionComments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InspectionID = c.Int(nullable: false),
                        CommentTypeID = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TRACK_INSPECTION", t => t.InspectionID, cascadeDelete: true)
                .ForeignKey("dbo.TrackInspectionCommentTypes", t => t.CommentTypeID, cascadeDelete: true)
                .Index(t => t.InspectionID)
                .Index(t => t.CommentTypeID);
            
            CreateTable(
                "dbo.TrackInspectionImagesMains",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InspectionID = c.Int(nullable: false),
                        ImageData = c.Binary(),
                        ImageComment = c.String(),
                        ImageTitle = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TRACK_INSPECTION", t => t.InspectionID, cascadeDelete: true)
                .Index(t => t.InspectionID);
            
            CreateTable(
                "dbo.TrackInspectionImagesRecords",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RecordID = c.Int(nullable: false),
                        ImageData = c.Binary(),
                        ImageComment = c.String(),
                        ImageTitle = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TrackInspectionRecords", t => t.RecordID, cascadeDelete: true)
                .Index(t => t.RecordID);
            
            CreateTable(
                "dbo.TrackInspectionRecords",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TrackInspectionMeasurePointID = c.Int(nullable: false),
                        InboardOutboard = c.Boolean(nullable: false),
                        ToolID = c.Int(nullable: false),
                        Reading = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TrackInspectionMeasurePoints", t => t.TrackInspectionMeasurePointID, cascadeDelete: true)
                .Index(t => t.TrackInspectionMeasurePointID);
            
            CreateTable(
                "dbo.TrackInspectionMeasurePoints",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InspectionDetailID = c.Int(nullable: false),
                        MeasurePointID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MeasurePointTypes", t => t.MeasurePointID, cascadeDelete: true)
                .ForeignKey("dbo.TRACK_INSPECTION_DETAIL", t => t.InspectionDetailID, cascadeDelete: true)
                .Index(t => t.InspectionDetailID)
                .Index(t => t.MeasurePointID);
            
            AddColumn("dbo.TRACK_INSPECTION_IMAGES", "image_title", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrackInspectionImagesRecords", "RecordID", "dbo.TrackInspectionRecords");
            DropForeignKey("dbo.TrackInspectionRecords", "TrackInspectionMeasurePointID", "dbo.TrackInspectionMeasurePoints");
            DropForeignKey("dbo.TrackInspectionMeasurePoints", "InspectionDetailID", "dbo.TRACK_INSPECTION_DETAIL");
            DropForeignKey("dbo.TrackInspectionMeasurePoints", "MeasurePointID", "dbo.MeasurePointTypes");
            DropForeignKey("dbo.TrackInspectionImagesMains", "InspectionID", "dbo.TRACK_INSPECTION");
            DropForeignKey("dbo.TrackInspectionCommentImages", "CommentID", "dbo.TrackInspectionComments");
            DropForeignKey("dbo.TrackInspectionComments", "CommentTypeID", "dbo.TrackInspectionCommentTypes");
            DropForeignKey("dbo.TrackInspectionComments", "InspectionID", "dbo.TRACK_INSPECTION");
            DropForeignKey("dbo.ModelCommentMaps", "CommentTypeID", "dbo.TrackInspectionCommentTypes");
            DropForeignKey("dbo.ModelCommentMaps", "ModelID", "dbo.MODEL");
            DropForeignKey("dbo.MeasurePointTools", "ToolID", "dbo.TRACK_TOOL");
            DropForeignKey("dbo.MeasurePointTools", "MeasurePointTypeID", "dbo.MeasurePointTypes");
            DropIndex("dbo.TrackInspectionMeasurePoints", new[] { "MeasurePointID" });
            DropIndex("dbo.TrackInspectionMeasurePoints", new[] { "InspectionDetailID" });
            DropIndex("dbo.TrackInspectionRecords", new[] { "TrackInspectionMeasurePointID" });
            DropIndex("dbo.TrackInspectionImagesRecords", new[] { "RecordID" });
            DropIndex("dbo.TrackInspectionImagesMains", new[] { "InspectionID" });
            DropIndex("dbo.TrackInspectionComments", new[] { "CommentTypeID" });
            DropIndex("dbo.TrackInspectionComments", new[] { "InspectionID" });
            DropIndex("dbo.TrackInspectionCommentImages", new[] { "CommentID" });
            DropIndex("dbo.ModelCommentMaps", new[] { "ModelID" });
            DropIndex("dbo.ModelCommentMaps", new[] { "CommentTypeID" });
            DropIndex("dbo.MeasurePointTools", new[] { "ToolID" });
            DropIndex("dbo.MeasurePointTools", new[] { "MeasurePointTypeID" });
            DropColumn("dbo.TRACK_INSPECTION_IMAGES", "image_title");
            DropTable("dbo.TrackInspectionMeasurePoints");
            DropTable("dbo.TrackInspectionRecords");
            DropTable("dbo.TrackInspectionImagesRecords");
            DropTable("dbo.TrackInspectionImagesMains");
            DropTable("dbo.TrackInspectionComments");
            DropTable("dbo.TrackInspectionCommentImages");
            DropTable("dbo.TrackInspectionCommentTypes");
            DropTable("dbo.ModelCommentMaps");
            DropTable("dbo.MeasurePointTypes");
            DropTable("dbo.MeasurePointTools");
        }
    }
}
