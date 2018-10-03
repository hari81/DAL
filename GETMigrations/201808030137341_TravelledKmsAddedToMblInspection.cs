namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TravelledKmsAddedToMblInspection : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Mbl_Track_Inspection", "TravelledKms", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.Mbl_Track_Inspection", "TravelledKms");
        }
    }
}
