namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTableForOverallComments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MININGSHOVEL_REPORT_OVERALL_COMMENTS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MiningShovelReportId = c.Int(nullable: false),
                        CompartTypeId = c.Int(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LU_COMPART_TYPE", t => t.CompartTypeId, cascadeDelete: true)
                .ForeignKey("dbo.MININGSHOVEL_REPORT", t => t.MiningShovelReportId, cascadeDelete: true)
                .Index(t => t.MiningShovelReportId)
                .Index(t => t.CompartTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MININGSHOVEL_REPORT_OVERALL_COMMENTS", "MiningShovelReportId", "dbo.MININGSHOVEL_REPORT");
            DropForeignKey("dbo.MININGSHOVEL_REPORT_OVERALL_COMMENTS", "CompartTypeId", "dbo.LU_COMPART_TYPE");
            DropIndex("dbo.MININGSHOVEL_REPORT_OVERALL_COMMENTS", new[] { "CompartTypeId" });
            DropIndex("dbo.MININGSHOVEL_REPORT_OVERALL_COMMENTS", new[] { "MiningShovelReportId" });
            DropTable("dbo.MININGSHOVEL_REPORT_OVERALL_COMMENTS");
        }
    }
}
