namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdditionalActionColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ACTION_TAKEN_HISTORY", "LabourCost", c => c.Decimal(nullable: false, precision: 18, scale: 2, defaultValue: 0));
            AddColumn("dbo.ACTION_TAKEN_HISTORY", "PartsCost", c => c.Decimal(nullable: false, precision: 18, scale: 2, defaultValue: 0));
            AddColumn("dbo.ACTION_TAKEN_HISTORY", "MiscCost", c => c.Decimal(nullable: false, precision: 18, scale: 2, defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ACTION_TAKEN_HISTORY", "MiscCost");
            DropColumn("dbo.ACTION_TAKEN_HISTORY", "PartsCost");
            DropColumn("dbo.ACTION_TAKEN_HISTORY", "LabourCost");
        }
    }
}
