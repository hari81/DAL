namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLabourCostOptionToActionHistory : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.CUSTOMER", "DefaultHourlyRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AddColumn("dbo.ACTION_TAKEN_HISTORY", "LabourCostOptions", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.ACTION_TAKEN_HISTORY", "LabourCostOptions");
            //DropColumn("dbo.CUSTOMER", "DefaultHourlyRate");
        }
    }
}
