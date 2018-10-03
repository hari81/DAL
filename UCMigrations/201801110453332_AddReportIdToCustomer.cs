namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReportIdToCustomer : DbMigration
    {
        public override void Up()
        {
            /*
            AddColumn("dbo.CUSTOMER", "SelectedReportId", c => c.Int());
            CreateIndex("dbo.CUSTOMER", "SelectedReportId");
            AddForeignKey("dbo.CUSTOMER", "SelectedReportId", "dbo.FLUID_REPORT_LU_REPORTS", "report_auto");
            */
        }
        
        public override void Down()
        {
            /*
            DropForeignKey("dbo.CUSTOMER", "SelectedReportId", "dbo.FLUID_REPORT_LU_REPORTS");
            DropIndex("dbo.CUSTOMER", new[] { "SelectedReportId" });
            DropColumn("dbo.CUSTOMER", "SelectedReportId");
            */
        }
    }
}
