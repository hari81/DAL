namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuoteReportsTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DealershipQuoteReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DealershipId = c.Int(nullable: false),
                        QuoteReportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DealershipReports", t => t.DealershipId, cascadeDelete: true)
                .ForeignKey("dbo.LU_QuoteReport", t => t.QuoteReportId, cascadeDelete: true)
                .Index(t => t.DealershipId)
                .Index(t => t.QuoteReportId);
            
            CreateTable(
                "dbo.LU_QuoteReport",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuoteReportDesc = c.String(),
                        isDefaultOption = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CUSTOMER", "QuoteReportStyle", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DealershipQuoteReports", "QuoteReportId", "dbo.LU_QuoteReport");
            DropForeignKey("dbo.DealershipQuoteReports", "DealershipId", "dbo.DealershipReports");
            DropIndex("dbo.DealershipQuoteReports", new[] { "QuoteReportId" });
            DropIndex("dbo.DealershipQuoteReports", new[] { "DealershipId" });
            DropColumn("dbo.CUSTOMER", "QuoteReportStyle");
            DropTable("dbo.LU_QuoteReport");
            DropTable("dbo.DealershipQuoteReports");
        }
    }
}
