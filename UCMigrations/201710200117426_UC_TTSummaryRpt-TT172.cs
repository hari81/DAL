namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UC_TTSummaryRptTT172 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO FLUID_REPORT_LU_REPORTS(report_display_name, report_tool_name, report_display_desc, language, active) VALUES
('TrackTreads Default Report', 'rtTTUndercarriageReport', 'UC_TTSummary.rpt', 'en', 1)
                ");
        }
        
        public override void Down()
        {
        }
    }
}
