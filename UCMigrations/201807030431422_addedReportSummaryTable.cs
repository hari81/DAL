namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedReportSummaryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MININGSHOVEL_REPORT_SUMMARY",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MiningShovelReportId = c.Int(nullable: false),
                        SummaryText = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MININGSHOVEL_REPORT", t => t.MiningShovelReportId, cascadeDelete: true)
                .Index(t => t.MiningShovelReportId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MININGSHOVEL_REPORT_SUMMARY", "MiningShovelReportId", "dbo.MININGSHOVEL_REPORT");
            DropIndex("dbo.MININGSHOVEL_REPORT_SUMMARY", new[] { "MiningShovelReportId" });
            DropTable("dbo.MININGSHOVEL_REPORT_SUMMARY");
        }
    }
}
