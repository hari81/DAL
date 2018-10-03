namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixAheadofMaster : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DealershipQuoteReports", "DealershipReports_Id", "dbo.DealershipReports");
            DropIndex("dbo.DealershipQuoteReports", new[] { "DealershipReports_Id" });
            //DropColumn("dbo.DealershipQuoteReports", "DealershipReports_Id");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.DealershipQuoteReports", "DealershipReports_Id", c => c.Int());
            CreateIndex("dbo.DealershipQuoteReports", "DealershipReports_Id");
            AddForeignKey("dbo.DealershipQuoteReports", "DealershipReports_Id", "dbo.DealershipReports", "Id");
        }
    }
}
