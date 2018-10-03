namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableTrackInspectionNewFields : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.TRACK_INSPECTION", "ForwardTravelKm", c => c.Int(nullable: false));
            //AddColumn("dbo.TRACK_INSPECTION", "ReverseTravelKm", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.TRACK_INSPECTION", "ReverseTravelKm");
            //DropColumn("dbo.TRACK_INSPECTION", "ForwardTravelKm");
        }
    }
}
