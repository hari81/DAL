namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixReportTablesMigrationIssue : DbMigration
    {
        public override void Up()
        {
            /* Already ran
            CreateTable(
                "dbo.CustomerReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Long(nullable: false),
                        ReportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUSTOMER", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.FLUID_REPORT_LU_REPORTS", t => t.ReportId, cascadeDelete: true)
                .Index(t => new { t.CustomerId, t.ReportId }, unique: true, name: "IX_CustomerReport");
            
            CreateTable(
                "dbo.FLUID_REPORT_LU_REPORTS",
                c => new
                    {
                        report_auto = c.Int(nullable: false, identity: true),
                        report_display_name = c.String(nullable: false, maxLength: 100),
                        report_tool_name = c.String(nullable: false, maxLength: 100, unicode: false),
                        report_display_desc = c.String(nullable: false, maxLength: 100, unicode: false),
                        language = c.String(nullable: false, maxLength: 50, unicode: false),
                        active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.report_auto);
            
            CreateTable(
                "dbo.DealershipReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DealershipId = c.Int(nullable: false),
                        ReportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dealerships", t => t.DealershipId, cascadeDelete: true)
                .ForeignKey("dbo.FLUID_REPORT_LU_REPORTS", t => t.ReportId, cascadeDelete: true)
                .Index(t => new { t.DealershipId, t.ReportId }, unique: true, name: "IX_DealershipReport");
            
            CreateTable(
                "dbo.FLUID_REPORT_LOGO",
                c => new
                    {
                        logo_auto = c.Int(nullable: false, identity: true),
                        display_name = c.String(nullable: false, maxLength: 100, unicode: false),
                        top_left_logo_img = c.String(maxLength: 50, unicode: false),
                        top_right_logo_img = c.String(maxLength: 50, unicode: false),
                        bottom_mid_logo_img = c.String(maxLength: 50, unicode: false),
                        bottom_right_img = c.String(maxLength: 50, unicode: false),
                        bottom_address_str = c.String(maxLength: 2000, unicode: false),
                        bottom_desc_str = c.String(maxLength: 2000, unicode: false),
                        _default = c.Boolean(name: "default", nullable: false),
                        advertisement = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.logo_auto);
            
            CreateTable(
                "dbo.FLUID_REPORT_LU_SETTINGS",
                c => new
                    {
                        variable_key = c.String(nullable: false, maxLength: 50, unicode: false),
                        value_key = c.String(nullable: false, maxLength: 1000, unicode: false),
                        comment = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.variable_key);
            */
        }
        
        public override void Down()
        {/*
            DropForeignKey("dbo.DealershipReports", "ReportId", "dbo.FLUID_REPORT_LU_REPORTS");
            DropForeignKey("dbo.DealershipReports", "DealershipId", "dbo.Dealerships");
            DropForeignKey("dbo.CustomerReports", "ReportId", "dbo.FLUID_REPORT_LU_REPORTS");
            DropForeignKey("dbo.CustomerReports", "CustomerId", "dbo.CUSTOMER");
            DropIndex("dbo.DealershipReports", "IX_DealershipReport");
            DropIndex("dbo.CustomerReports", "IX_CustomerReport");
            DropTable("dbo.FLUID_REPORT_LU_SETTINGS");
            DropTable("dbo.FLUID_REPORT_LOGO");
            DropTable("dbo.DealershipReports");
            DropTable("dbo.FLUID_REPORT_LU_REPORTS");
            DropTable("dbo.CustomerReports");*/
        }
    }
}
