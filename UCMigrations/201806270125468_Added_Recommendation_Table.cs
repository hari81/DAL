namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Recommendation_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MININGSHOVEL_REPORT_RECOMMENDATIONS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MiningShovelReportId = c.Int(nullable: false),
                        RecommendationTitle = c.String(),
                        RecommendationText = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MININGSHOVEL_REPORT", t => t.MiningShovelReportId, cascadeDelete: true)
                .Index(t => t.MiningShovelReportId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MININGSHOVEL_REPORT_RECOMMENDATIONS", "MiningShovelReportId", "dbo.MININGSHOVEL_REPORT");
            DropIndex("dbo.MININGSHOVEL_REPORT_RECOMMENDATIONS", new[] { "MiningShovelReportId" });
            DropTable("dbo.MININGSHOVEL_REPORT_RECOMMENDATIONS");
        }
    }
}
