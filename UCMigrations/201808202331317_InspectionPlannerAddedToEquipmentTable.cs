namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InspectionPlannerAddedToEquipmentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EQUIPMENT", "EnableAutoInspectionPlanner", c => c.Boolean(nullable: false));
            AddColumn("dbo.EQUIPMENT", "NextInspectionDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EQUIPMENT", "NextInspectionDate");
            DropColumn("dbo.EQUIPMENT", "EnableAutoInspectionPlanner");
        }
    }
}
