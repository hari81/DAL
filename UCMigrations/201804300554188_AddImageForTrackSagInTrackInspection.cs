namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageForTrackSagInTrackInspection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TRACK_INSPECTION", "LeftTrackSagComment", c => c.String());
            AddColumn("dbo.TRACK_INSPECTION", "LeftTrackSagImage", c => c.Binary());
            AddColumn("dbo.TRACK_INSPECTION", "RightTrackSagComment", c => c.String());
            AddColumn("dbo.TRACK_INSPECTION", "RightTrackSagImage", c => c.Binary());
            AddColumn("dbo.TRACK_INSPECTION", "LeftCannonExtensionComment", c => c.String());
            AddColumn("dbo.TRACK_INSPECTION", "LeftCannonExtensionImage", c => c.Binary());
            AddColumn("dbo.TRACK_INSPECTION", "RightCannonExtensionComment", c => c.String());
            AddColumn("dbo.TRACK_INSPECTION", "RightCannonExtensionImage", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TRACK_INSPECTION", "RightCannonExtensionImage");
            DropColumn("dbo.TRACK_INSPECTION", "RightCannonExtensionComment");
            DropColumn("dbo.TRACK_INSPECTION", "LeftCannonExtensionImage");
            DropColumn("dbo.TRACK_INSPECTION", "LeftCannonExtensionComment");
            DropColumn("dbo.TRACK_INSPECTION", "RightTrackSagImage");
            DropColumn("dbo.TRACK_INSPECTION", "RightTrackSagComment");
            DropColumn("dbo.TRACK_INSPECTION", "LeftTrackSagImage");
            DropColumn("dbo.TRACK_INSPECTION", "LeftTrackSagComment");
        }
    }
}
