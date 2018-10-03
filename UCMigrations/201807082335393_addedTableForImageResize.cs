namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTableForImageResize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MININGSHOVEL_REPORT_IMAGE_RESIZED",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReportId = c.Int(nullable: false),
                        ReportImageId = c.Int(),
                        RecommendationImageId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MININGSHOVEL_REPORT_IMAGE_CATEGORIES", t => t.ReportImageId)
                .ForeignKey("dbo.MININGSHOVEL_REPORT", t => t.ReportId, cascadeDelete: true)
                .ForeignKey("dbo.MININGSHOVEL_REPORT_RECOMMENDATION_IMAGES", t => t.RecommendationImageId)
                .Index(t => t.ReportId)
                .Index(t => t.ReportImageId)
                .Index(t => t.RecommendationImageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MININGSHOVEL_REPORT_IMAGE_RESIZED", "RecommendationImageId", "dbo.MININGSHOVEL_REPORT_RECOMMENDATION_IMAGES");
            DropForeignKey("dbo.MININGSHOVEL_REPORT_IMAGE_RESIZED", "ReportId", "dbo.MININGSHOVEL_REPORT");
            DropForeignKey("dbo.MININGSHOVEL_REPORT_IMAGE_RESIZED", "ReportImageId", "dbo.MININGSHOVEL_REPORT_IMAGE_CATEGORIES");
            DropIndex("dbo.MININGSHOVEL_REPORT_IMAGE_RESIZED", new[] { "RecommendationImageId" });
            DropIndex("dbo.MININGSHOVEL_REPORT_IMAGE_RESIZED", new[] { "ReportImageId" });
            DropIndex("dbo.MININGSHOVEL_REPORT_IMAGE_RESIZED", new[] { "ReportId" });
            DropTable("dbo.MININGSHOVEL_REPORT_IMAGE_RESIZED");
        }
    }
}
