namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_Inventory_events_table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GET_EVENTS", "jobsite", "dbo.CRSF");
            DropIndex("dbo.GET_EVENTS", new[] { "jobsite" });
            CreateTable(
                "dbo.GET_EVENTS_INVENTORY",
                c => new
                    {
                        inventory_events_auto = c.Long(nullable: false, identity: true),
                        implement_events_auto = c.Long(nullable: false),
                        jobsite_auto = c.Long(nullable: false),
                        status_auto = c.Int(nullable: false),
                        workshop_auto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.inventory_events_auto)
                .ForeignKey("dbo.CRSF", t => t.jobsite_auto, cascadeDelete: true)
                .ForeignKey("dbo.GET_EVENTS_IMPLEMENT", t => t.implement_events_auto, cascadeDelete: true)
                .ForeignKey("dbo.GET_INVENTORY_STATUS", t => t.status_auto, cascadeDelete: true)
                .ForeignKey("dbo.GET_WORKSHOP", t => t.workshop_auto, cascadeDelete: true)
                .Index(t => t.implement_events_auto)
                .Index(t => t.jobsite_auto)
                .Index(t => t.status_auto)
                .Index(t => t.workshop_auto);
            
            DropColumn("dbo.GET_EVENTS", "jobsite");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GET_EVENTS", "jobsite", c => c.Long());
            DropForeignKey("dbo.GET_EVENTS_INVENTORY", "workshop_auto", "dbo.GET_WORKSHOP");
            DropForeignKey("dbo.GET_EVENTS_INVENTORY", "status_auto", "dbo.GET_INVENTORY_STATUS");
            DropForeignKey("dbo.GET_EVENTS_INVENTORY", "implement_events_auto", "dbo.GET_EVENTS_IMPLEMENT");
            DropForeignKey("dbo.GET_EVENTS_INVENTORY", "jobsite_auto", "dbo.CRSF");
            DropIndex("dbo.GET_EVENTS_INVENTORY", new[] { "workshop_auto" });
            DropIndex("dbo.GET_EVENTS_INVENTORY", new[] { "status_auto" });
            DropIndex("dbo.GET_EVENTS_INVENTORY", new[] { "jobsite_auto" });
            DropIndex("dbo.GET_EVENTS_INVENTORY", new[] { "implement_events_auto" });
            DropTable("dbo.GET_EVENTS_INVENTORY");
            CreateIndex("dbo.GET_EVENTS", "jobsite");
            AddForeignKey("dbo.GET_EVENTS", "jobsite", "dbo.CRSF", "crsf_auto");
        }
    }
}
