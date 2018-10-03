namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationToDelaershipQuoteReport : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.DealershipQuoteReports", "DealershipId", "dbo.Dealerships", "DealershipId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DealershipQuoteReports", "DealershipId", "dbo.Dealerships");
        }
    }
}
