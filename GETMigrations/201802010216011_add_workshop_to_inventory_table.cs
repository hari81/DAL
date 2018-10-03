namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_workshop_to_inventory_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GET_INVENTORY", "workshop_auto", c => c.Int(nullable: false));
            AlterColumn("dbo.GET_INVENTORY", "jobsite_auto", c => c.Long(nullable: false));
            CreateIndex("dbo.GET_INVENTORY", "get_auto");
            CreateIndex("dbo.GET_INVENTORY", "jobsite_auto");
            CreateIndex("dbo.GET_INVENTORY", "status_auto");
            CreateIndex("dbo.GET_INVENTORY", "workshop_auto");
            AddForeignKey("dbo.GET_INVENTORY", "jobsite_auto", "dbo.CRSF", "crsf_auto", cascadeDelete: true);
            AddForeignKey("dbo.GET_INVENTORY", "get_auto", "dbo.GET", "get_auto", cascadeDelete: true);
            AddForeignKey("dbo.GET_INVENTORY", "status_auto", "dbo.GET_INVENTORY_STATUS", "status_auto", cascadeDelete: true);
            AddForeignKey("dbo.GET_INVENTORY", "workshop_auto", "dbo.GET_WORKSHOP", "workshop_auto", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GET_INVENTORY", "workshop_auto", "dbo.GET_WORKSHOP");
            DropForeignKey("dbo.GET_INVENTORY", "status_auto", "dbo.GET_INVENTORY_STATUS");
            DropForeignKey("dbo.GET_INVENTORY", "get_auto", "dbo.GET");
            DropForeignKey("dbo.GET_INVENTORY", "jobsite_auto", "dbo.CRSF");
            DropIndex("dbo.GET_INVENTORY", new[] { "workshop_auto" });
            DropIndex("dbo.GET_INVENTORY", new[] { "status_auto" });
            DropIndex("dbo.GET_INVENTORY", new[] { "jobsite_auto" });
            DropIndex("dbo.GET_INVENTORY", new[] { "get_auto" });
            AlterColumn("dbo.GET_INVENTORY", "jobsite_auto", c => c.Int(nullable: false));
            DropColumn("dbo.GET_INVENTORY", "workshop_auto");
        }
    }
}
