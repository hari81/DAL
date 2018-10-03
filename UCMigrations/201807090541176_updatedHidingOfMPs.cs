namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedHidingOfMPs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", "hideReadings", c => c.Boolean(nullable: false));
            AddColumn("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", "hideAll", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", "hideAll");
            DropColumn("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", "hideReadings");
        }
    }
}
