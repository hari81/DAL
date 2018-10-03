namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReportIdToCustomer : DbMigration
    {
        public override void Up()
        {
            /* Already exist
            CreateTable(
                "dbo.FLUID_REPORT_LU_REPORTS",
                c => new
                    {
                        report_auto = c.Int(nullable: false, identity: true),
                        report_display_name = c.String(nullable: false, maxLength: 100),
                        report_tool_name = c.String(nullable: false, maxLength: 100),
                        report_display_desc = c.String(nullable: false, maxLength: 100),
                        language = c.String(nullable: false, maxLength: 50),
                        active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.report_auto);
            */
            AddColumn("dbo.CUSTOMER", "SelectedReportId", c => c.Int());
            CreateIndex("dbo.CUSTOMER", "SelectedReportId");
            AddForeignKey("dbo.CUSTOMER", "SelectedReportId", "dbo.FLUID_REPORT_LU_REPORTS", "report_auto");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CUSTOMER", "SelectedReportId", "dbo.FLUID_REPORT_LU_REPORTS");
            DropIndex("dbo.CUSTOMER", new[] { "SelectedReportId" });
            DropColumn("dbo.CUSTOMER", "SelectedReportId");
            DropTable("dbo.FLUID_REPORT_LU_REPORTS");
        }
    }
}
