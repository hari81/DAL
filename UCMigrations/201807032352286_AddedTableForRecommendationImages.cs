namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTableForRecommendationImages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MININGSHOVEL_REPORT_IMAGE_CATEGORIES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comparttype_Mandatory_Image = c.Int(),
                        Comparttype_Additional_Image = c.Int(),
                        Inspection_Mandatory_Image = c.Int(),
                        Measurement_Point_Image = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.INSPECTION_COMPARTTYPE_IMAGES", t => t.Comparttype_Mandatory_Image)
                .ForeignKey("dbo.INSPECTION_COMPARTTYPE_RECORD_IMAGES", t => t.Comparttype_Additional_Image)
                .ForeignKey("dbo.INSPECTION_MANDATORY_IMAGES", t => t.Inspection_Mandatory_Image)
                .ForeignKey("dbo.MEASUREPOINT_RECORD_IMAGES", t => t.Measurement_Point_Image)
                .Index(t => t.Comparttype_Mandatory_Image)
                .Index(t => t.Comparttype_Additional_Image)
                .Index(t => t.Inspection_Mandatory_Image)
                .Index(t => t.Measurement_Point_Image);
            
            CreateTable(
                "dbo.MININGSHOVEL_REPORT_RECOMMENDATION_IMAGES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecommendationId = c.Int(nullable: false),
                        ImageCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MININGSHOVEL_REPORT_IMAGE_CATEGORIES", t => t.ImageCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.MININGSHOVEL_REPORT_RECOMMENDATIONS", t => t.RecommendationId, cascadeDelete: true)
                .Index(t => t.RecommendationId)
                .Index(t => t.ImageCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MININGSHOVEL_REPORT_RECOMMENDATION_IMAGES", "RecommendationId", "dbo.MININGSHOVEL_REPORT_RECOMMENDATIONS");
            DropForeignKey("dbo.MININGSHOVEL_REPORT_RECOMMENDATION_IMAGES", "ImageCategoryId", "dbo.MININGSHOVEL_REPORT_IMAGE_CATEGORIES");
            DropForeignKey("dbo.MININGSHOVEL_REPORT_IMAGE_CATEGORIES", "Measurement_Point_Image", "dbo.MEASUREPOINT_RECORD_IMAGES");
            DropForeignKey("dbo.MININGSHOVEL_REPORT_IMAGE_CATEGORIES", "Inspection_Mandatory_Image", "dbo.INSPECTION_MANDATORY_IMAGES");
            DropForeignKey("dbo.MININGSHOVEL_REPORT_IMAGE_CATEGORIES", "Comparttype_Additional_Image", "dbo.INSPECTION_COMPARTTYPE_RECORD_IMAGES");
            DropForeignKey("dbo.MININGSHOVEL_REPORT_IMAGE_CATEGORIES", "Comparttype_Mandatory_Image", "dbo.INSPECTION_COMPARTTYPE_IMAGES");
            DropIndex("dbo.MININGSHOVEL_REPORT_RECOMMENDATION_IMAGES", new[] { "ImageCategoryId" });
            DropIndex("dbo.MININGSHOVEL_REPORT_RECOMMENDATION_IMAGES", new[] { "RecommendationId" });
            DropIndex("dbo.MININGSHOVEL_REPORT_IMAGE_CATEGORIES", new[] { "Measurement_Point_Image" });
            DropIndex("dbo.MININGSHOVEL_REPORT_IMAGE_CATEGORIES", new[] { "Inspection_Mandatory_Image" });
            DropIndex("dbo.MININGSHOVEL_REPORT_IMAGE_CATEGORIES", new[] { "Comparttype_Additional_Image" });
            DropIndex("dbo.MININGSHOVEL_REPORT_IMAGE_CATEGORIES", new[] { "Comparttype_Mandatory_Image" });
            DropTable("dbo.MININGSHOVEL_REPORT_RECOMMENDATION_IMAGES");
            DropTable("dbo.MININGSHOVEL_REPORT_IMAGE_CATEGORIES");
        }
    }
}
