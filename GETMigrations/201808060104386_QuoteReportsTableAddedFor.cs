namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuoteReportsTableAddedFor : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.CUSTOMER", "QuoteReportStyle", c => c.Int());
        }
        
        public override void Down()
        {
            //DropColumn("dbo.CUSTOMER", "QuoteReportStyle");
        }
    }
}
