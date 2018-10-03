namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddScallopAndTravelForInspection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TRACK_INSPECTION", "ForwardTravelHours", c => c.Int(nullable: false));
            AddColumn("dbo.TRACK_INSPECTION", "ReverseTravelHours", c => c.Int(nullable: false));
            AddColumn("dbo.TRACK_INSPECTION", "LeftScallopMeasurement", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TRACK_INSPECTION", "RightScallopMeasurement", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TRACK_INSPECTION", "RightScallopMeasurement");
            DropColumn("dbo.TRACK_INSPECTION", "LeftScallopMeasurement");
            DropColumn("dbo.TRACK_INSPECTION", "ReverseTravelHours");
            DropColumn("dbo.TRACK_INSPECTION", "ForwardTravelHours");
        }
    }
}
