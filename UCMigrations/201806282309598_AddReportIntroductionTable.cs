namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReportIntroductionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MININGSHOVEL_REPORT_INTRODUCTION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MiningShovelReportId = c.Int(nullable: false),
                        CoverImage = c.Int(nullable: false),
                        IntroText1 = c.String(),
                        IntroText2 = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.INSPECTION_MANDATORY_IMAGES", t => t.CoverImage, cascadeDelete: true)
                .ForeignKey("dbo.MININGSHOVEL_REPORT", t => t.MiningShovelReportId, cascadeDelete: true)
                .Index(t => t.MiningShovelReportId)
                .Index(t => t.CoverImage);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MININGSHOVEL_REPORT_INTRODUCTION", "MiningShovelReportId", "dbo.MININGSHOVEL_REPORT");
            DropForeignKey("dbo.MININGSHOVEL_REPORT_INTRODUCTION", "CoverImage", "dbo.INSPECTION_MANDATORY_IMAGES");
            DropIndex("dbo.MININGSHOVEL_REPORT_INTRODUCTION", new[] { "CoverImage" });
            DropIndex("dbo.MININGSHOVEL_REPORT_INTRODUCTION", new[] { "MiningShovelReportId" });
            DropTable("dbo.MININGSHOVEL_REPORT_INTRODUCTION");
        }
    }
}
