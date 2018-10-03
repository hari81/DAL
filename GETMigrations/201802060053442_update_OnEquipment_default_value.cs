namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_OnEquipment_default_value : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GET", "on_equipment", e => e.Boolean(nullable: false, defaultValue: true));
        }
        
        public override void Down()
        {
        }
    }
}
