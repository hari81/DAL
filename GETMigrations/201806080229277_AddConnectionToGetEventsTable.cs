namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConnectionToGetEventsTable : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.GET_EVENTS_EQUIPMENT", "events_auto");
            AddForeignKey("dbo.GET_EVENTS_EQUIPMENT", "events_auto", "dbo.GET_EVENTS", "events_auto", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GET_EVENTS_EQUIPMENT", "events_auto", "dbo.GET_EVENTS");
            DropIndex("dbo.GET_EVENTS_EQUIPMENT", new[] { "events_auto" });
        }
    }
}
