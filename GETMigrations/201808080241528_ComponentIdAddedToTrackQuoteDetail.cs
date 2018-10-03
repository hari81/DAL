namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComponentIdAddedToTrackQuoteDetail : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.TRACK_QUOTE_DETAIL", "ComponentId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.TRACK_QUOTE_DETAIL", "ComponentId");
        }
    }
}
