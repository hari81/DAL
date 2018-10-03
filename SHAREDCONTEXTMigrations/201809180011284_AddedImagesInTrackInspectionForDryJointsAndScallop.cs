namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImagesInTrackInspectionForDryJointsAndScallop : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.TRACK_INSPECTION", "DryJointsLeftImage", c => c.Binary());
            //AddColumn("dbo.TRACK_INSPECTION", "DryJointsRightImage", c => c.Binary());
            //AddColumn("dbo.TRACK_INSPECTION", "LeftScallopImage", c => c.Binary());
            //AddColumn("dbo.TRACK_INSPECTION", "RightScallopImage", c => c.Binary());
        }
        
        public override void Down()
        {
            //DropColumn("dbo.TRACK_INSPECTION", "RightScallopImage");
            //DropColumn("dbo.TRACK_INSPECTION", "LeftScallopImage");
            //DropColumn("dbo.TRACK_INSPECTION", "DryJointsRightImage");
            //DropColumn("dbo.TRACK_INSPECTION", "DryJointsLeftImage");
        }
    }
}
