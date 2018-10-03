namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReportIntroductionTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MININGSHOVEL_REPORT_INTRODUCTION", "CoverImage", "dbo.INSPECTION_MANDATORY_IMAGES");
            DropIndex("dbo.MININGSHOVEL_REPORT_INTRODUCTION", new[] { "CoverImage" });
            AlterColumn("dbo.MININGSHOVEL_REPORT_INTRODUCTION", "CoverImage", c => c.Int());
            CreateIndex("dbo.MININGSHOVEL_REPORT_INTRODUCTION", "CoverImage");
            AddForeignKey("dbo.MININGSHOVEL_REPORT_INTRODUCTION", "CoverImage", "dbo.INSPECTION_MANDATORY_IMAGES", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MININGSHOVEL_REPORT_INTRODUCTION", "CoverImage", "dbo.INSPECTION_MANDATORY_IMAGES");
            DropIndex("dbo.MININGSHOVEL_REPORT_INTRODUCTION", new[] { "CoverImage" });
            AlterColumn("dbo.MININGSHOVEL_REPORT_INTRODUCTION", "CoverImage", c => c.Int(nullable: false));
            CreateIndex("dbo.MININGSHOVEL_REPORT_INTRODUCTION", "CoverImage");
            AddForeignKey("dbo.MININGSHOVEL_REPORT_INTRODUCTION", "CoverImage", "dbo.INSPECTION_MANDATORY_IMAGES", "Id", cascadeDelete: true);
        }
    }
}
