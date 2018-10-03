namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuoteReportTablesRelationsChanged : DbMigration
    {
        public override void Up()
        {
            /*
            CreateTable(
                "dbo.DealershipQuoteReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DealershipId = c.Int(nullable: false),
                        QuoteReportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dealerships", t => t.DealershipId, cascadeDelete: true)
                .ForeignKey("dbo.LU_QuoteReport", t => t.QuoteReportId, cascadeDelete: true)
                .Index(t => new { t.DealershipId, t.QuoteReportId }, unique: true, name: "IX_DealershipQuoteReport");
            
            CreateTable(
                "dbo.LU_QuoteReport",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuoteReportDesc = c.String(),
                        isDefaultOption = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);*/
            
        }
        
        public override void Down()
        {/*
            DropForeignKey("dbo.DealershipQuoteReports", "QuoteReportId", "dbo.LU_QuoteReport");
            DropForeignKey("dbo.DealershipQuoteReports", "DealershipId", "dbo.Dealerships");
            DropIndex("dbo.DealershipQuoteReports", "IX_DealershipQuoteReport");
            DropTable("dbo.LU_QuoteReport");
            DropTable("dbo.DealershipQuoteReports");*/
        }
    }
}
