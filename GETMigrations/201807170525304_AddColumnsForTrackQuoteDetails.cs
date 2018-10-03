namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsForTrackQuoteDetails : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.TRACK_QUOTE_DETAIL", "LabourCost", c => c.Decimal(storeType: "money"));
            //AddColumn("dbo.TRACK_QUOTE_DETAIL", "PartsCost", c => c.Decimal(storeType: "money"));
            //AddColumn("dbo.TRACK_QUOTE_DETAIL", "MiscCost", c => c.Decimal(storeType: "money"));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.TRACK_QUOTE_DETAIL", "MiscCost");
            //DropColumn("dbo.TRACK_QUOTE_DETAIL", "PartsCost");
            //DropColumn("dbo.TRACK_QUOTE_DETAIL", "LabourCost");
        }
    }
}
