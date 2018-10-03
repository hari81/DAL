namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEquipmentPhotoColumnAndForecasts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EQUIPMENT", "EquipmentPhoto", c => c.Binary());
            AddColumn("dbo.EQUIPMENT", "UsedMonday", c => c.Boolean(nullable: false));
            AddColumn("dbo.EQUIPMENT", "UsedTuesday", c => c.Boolean(nullable: false));
            AddColumn("dbo.EQUIPMENT", "UsedWednesday", c => c.Boolean(nullable: false));
            AddColumn("dbo.EQUIPMENT", "UsedThursday", c => c.Boolean(nullable: false));
            AddColumn("dbo.EQUIPMENT", "UsedFriday", c => c.Boolean(nullable: false));
            AddColumn("dbo.EQUIPMENT", "UsedSaturday", c => c.Boolean(nullable: false));
            AddColumn("dbo.EQUIPMENT", "UsedSunday", c => c.Boolean(nullable: false));
            AddColumn("dbo.EQUIPMENT", "InspectEvery", c => c.Int(nullable: false));
            AddColumn("dbo.EQUIPMENT", "InspectEveryUnitTypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EQUIPMENT", "InspectEveryUnitTypeId");
            DropColumn("dbo.EQUIPMENT", "InspectEvery");
            DropColumn("dbo.EQUIPMENT", "UsedSunday");
            DropColumn("dbo.EQUIPMENT", "UsedSaturday");
            DropColumn("dbo.EQUIPMENT", "UsedFriday");
            DropColumn("dbo.EQUIPMENT", "UsedThursday");
            DropColumn("dbo.EQUIPMENT", "UsedWednesday");
            DropColumn("dbo.EQUIPMENT", "UsedTuesday");
            DropColumn("dbo.EQUIPMENT", "UsedMonday");
            DropColumn("dbo.EQUIPMENT", "EquipmentPhoto");
        }
    }
}
