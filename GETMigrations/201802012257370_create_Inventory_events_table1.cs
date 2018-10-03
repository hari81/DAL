namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_Inventory_events_table1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GET_EVENTS_INVENTORY", "workshop_auto", "dbo.GET_WORKSHOP");
            DropIndex("dbo.GET_EVENTS_INVENTORY", new[] { "workshop_auto" });
            AlterColumn("dbo.GET_EVENTS_INVENTORY", "workshop_auto", c => c.Int());
            CreateIndex("dbo.GET_EVENTS_INVENTORY", "workshop_auto");
            AddForeignKey("dbo.GET_EVENTS_INVENTORY", "workshop_auto", "dbo.GET_WORKSHOP", "workshop_auto");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GET_EVENTS_INVENTORY", "workshop_auto", "dbo.GET_WORKSHOP");
            DropIndex("dbo.GET_EVENTS_INVENTORY", new[] { "workshop_auto" });
            AlterColumn("dbo.GET_EVENTS_INVENTORY", "workshop_auto", c => c.Int(nullable: false));
            CreateIndex("dbo.GET_EVENTS_INVENTORY", "workshop_auto");
            AddForeignKey("dbo.GET_EVENTS_INVENTORY", "workshop_auto", "dbo.GET_WORKSHOP", "workshop_auto", cascadeDelete: true);
        }
    }
}
