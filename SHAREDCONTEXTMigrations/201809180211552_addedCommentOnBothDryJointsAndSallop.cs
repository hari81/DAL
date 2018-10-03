namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCommentOnBothDryJointsAndSallop : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.TRACK_INSPECTION", "LeftDryJointComments", c => c.String());
            //AddColumn("dbo.TRACK_INSPECTION", "RightDryJointComments", c => c.String());
            //AddColumn("dbo.TRACK_INSPECTION", "LeftScallopComments", c => c.String());
            //AddColumn("dbo.TRACK_INSPECTION", "RightScallopComments", c => c.String());
        }
        
        public override void Down()
        {
            //DropColumn("dbo.TRACK_INSPECTION", "RightScallopComments");
            //DropColumn("dbo.TRACK_INSPECTION", "LeftScallopComments");
            //DropColumn("dbo.TRACK_INSPECTION", "RightDryJointComments");
            //DropColumn("dbo.TRACK_INSPECTION", "LeftDryJointComments");
        }
    }
}
