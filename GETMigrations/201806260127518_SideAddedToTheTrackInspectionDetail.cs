namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SideAddedToTheTrackInspectionDetail : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.TRACK_INSPECTION_DETAIL", "Side", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.TRACK_INSPECTION_DETAIL", "Side");
        }
    }
}
