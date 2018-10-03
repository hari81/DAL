namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForeignKeysGET2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GET_EVENTS_COMPONENT", "get_component_auto", c => c.Int(nullable: false));
            AlterColumn("dbo.GET_EVENTS_IMPLEMENT", "get_auto", c => c.Int(nullable: false));
            CreateIndex("dbo.GET_EVENTS", "action_auto");
            CreateIndex("dbo.GET_EVENTS_COMPONENT", "get_component_auto");
            CreateIndex("dbo.GET_EVENTS_COMPONENT", "events_auto");
            CreateIndex("dbo.GET_EVENTS_EQUIPMENT", "equipment_auto");
            CreateIndex("dbo.GET_EVENTS_IMPLEMENT", "get_auto");
            CreateIndex("dbo.GET_EVENTS_IMPLEMENT", "events_auto");
            AddForeignKey("dbo.GET_EVENTS", "action_auto", "dbo.GET_ACTIONS", "actions_auto", cascadeDelete: true);
            AddForeignKey("dbo.GET_EVENTS_COMPONENT", "events_auto", "dbo.GET_EVENTS", "events_auto", cascadeDelete: true);
            AddForeignKey("dbo.GET_EVENTS_COMPONENT", "get_component_auto", "dbo.GET_COMPONENT", "get_component_auto", cascadeDelete: true);
            AddForeignKey("dbo.GET_EVENTS_EQUIPMENT", "equipment_auto", "dbo.EQUIPMENT", "equipmentid_auto", cascadeDelete: true);
            AddForeignKey("dbo.GET_EVENTS_IMPLEMENT", "events_auto", "dbo.GET_EVENTS", "events_auto", cascadeDelete: true);
            AddForeignKey("dbo.GET_EVENTS_IMPLEMENT", "get_auto", "dbo.GET", "get_auto", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GET_EVENTS_IMPLEMENT", "get_auto", "dbo.GET");
            DropForeignKey("dbo.GET_EVENTS_IMPLEMENT", "events_auto", "dbo.GET_EVENTS");
            DropForeignKey("dbo.GET_EVENTS_EQUIPMENT", "equipment_auto", "dbo.EQUIPMENT");
            DropForeignKey("dbo.GET_EVENTS_COMPONENT", "get_component_auto", "dbo.GET_COMPONENT");
            DropForeignKey("dbo.GET_EVENTS_COMPONENT", "events_auto", "dbo.GET_EVENTS");
            DropForeignKey("dbo.GET_EVENTS", "action_auto", "dbo.GET_ACTIONS");
            DropIndex("dbo.GET_EVENTS_IMPLEMENT", new[] { "events_auto" });
            DropIndex("dbo.GET_EVENTS_IMPLEMENT", new[] { "get_auto" });
            DropIndex("dbo.GET_EVENTS_EQUIPMENT", new[] { "equipment_auto" });
            DropIndex("dbo.GET_EVENTS_COMPONENT", new[] { "events_auto" });
            DropIndex("dbo.GET_EVENTS_COMPONENT", new[] { "get_component_auto" });
            DropIndex("dbo.GET_EVENTS", new[] { "action_auto" });
            AlterColumn("dbo.GET_EVENTS_IMPLEMENT", "get_auto", c => c.Long(nullable: false));
            AlterColumn("dbo.GET_EVENTS_COMPONENT", "get_component_auto", c => c.Long(nullable: false));
        }
    }
}
