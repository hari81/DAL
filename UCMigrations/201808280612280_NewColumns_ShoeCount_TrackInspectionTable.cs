namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumns_ShoeCount_TrackInspectionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TRACK_INSPECTION", "LeftShoeNo", c => c.Int());
            AddColumn("dbo.TRACK_INSPECTION", "RightShoeNo", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TRACK_INSPECTION", "RightShoeNo");
            DropColumn("dbo.TRACK_INSPECTION", "LeftShoeNo");
        }
    }
}
