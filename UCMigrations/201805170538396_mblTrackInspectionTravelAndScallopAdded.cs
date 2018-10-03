namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mblTrackInspectionTravelAndScallopAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mbl_Track_Inspection", "ForwardTravelHours", c => c.Int(nullable: false));
            AddColumn("dbo.Mbl_Track_Inspection", "ReverseTravelHours", c => c.Int(nullable: false));
            AddColumn("dbo.Mbl_Track_Inspection", "LeftScallopMeasurement", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mbl_Track_Inspection", "RightScallopMeasurement", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mbl_Track_Inspection", "RightScallopMeasurement");
            DropColumn("dbo.Mbl_Track_Inspection", "LeftScallopMeasurement");
            DropColumn("dbo.Mbl_Track_Inspection", "ReverseTravelHours");
            DropColumn("dbo.Mbl_Track_Inspection", "ForwardTravelHours");
        }
    }
}
