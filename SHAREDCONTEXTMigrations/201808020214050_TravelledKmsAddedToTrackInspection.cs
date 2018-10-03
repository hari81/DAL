namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TravelledKmsAddedToTrackInspection : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.TRACK_INSPECTION", "TravelledKms", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.TRACK_INSPECTION", "TravelledKms");
        }
    }
}
