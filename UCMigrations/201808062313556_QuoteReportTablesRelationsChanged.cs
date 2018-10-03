namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuoteReportTablesRelationsChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DealershipQuoteReports", "DealershipId", "dbo.DealershipReports");
            DropIndex("dbo.DealershipQuoteReports", new[] { "DealershipId" });
            DropIndex("dbo.DealershipQuoteReports", new[] { "QuoteReportId" });
            //AddColumn("dbo.DealershipQuoteReports", "DealershipReports_Id", c => c.Int());
            CreateIndex("dbo.DealershipQuoteReports", new[] { "DealershipId", "QuoteReportId" }, unique: true, name: "IX_DealershipQuoteReport");
            //CreateIndex("dbo.DealershipQuoteReports", "DealershipReports_Id");
            //AddForeignKey("dbo.DealershipQuoteReports", "DealershipReports_Id", "dbo.DealershipReports", "Id");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.DealershipQuoteReports", "DealershipReports_Id", "dbo.DealershipReports");
            //DropIndex("dbo.DealershipQuoteReports", new[] { "DealershipReports_Id" });
            DropIndex("dbo.DealershipQuoteReports", "IX_DealershipQuoteReport");
            //DropColumn("dbo.DealershipQuoteReports", "DealershipReports_Id");
            CreateIndex("dbo.DealershipQuoteReports", "QuoteReportId");
            CreateIndex("dbo.DealershipQuoteReports", "DealershipId");
            AddForeignKey("dbo.DealershipQuoteReports", "DealershipId", "dbo.DealershipReports", "Id", cascadeDelete: true);
        }
    }
}
