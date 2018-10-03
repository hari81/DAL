namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NextInspectionSMUColumnAddedInEquipmentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EQUIPMENT", "NextInspectionSMU", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EQUIPMENT", "NextInspectionSMU");
        }
    }
}
