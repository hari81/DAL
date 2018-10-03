namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForeignKeysGET1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.GET_COMPONENT", "make_auto");
            CreateIndex("dbo.GET_COMPONENT", "get_auto");
            CreateIndex("dbo.GET_COMPONENT", "schematic_component_auto");
            AddForeignKey("dbo.GET_COMPONENT", "schematic_component_auto", "dbo.GET_SCHEMATIC_COMPONENT", "schematic_component_auto");
            AddForeignKey("dbo.GET_COMPONENT", "get_auto", "dbo.GET", "get_auto", cascadeDelete: true);
            AddForeignKey("dbo.GET_COMPONENT", "make_auto", "dbo.MAKE", "make_auto");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GET_COMPONENT", "make_auto", "dbo.MAKE");
            DropForeignKey("dbo.GET_COMPONENT", "get_auto", "dbo.GET");
            DropForeignKey("dbo.GET_COMPONENT", "schematic_component_auto", "dbo.GET_SCHEMATIC_COMPONENT");
            DropIndex("dbo.GET_COMPONENT", new[] { "schematic_component_auto" });
            DropIndex("dbo.GET_COMPONENT", new[] { "get_auto" });
            DropIndex("dbo.GET_COMPONENT", new[] { "make_auto" });
        }
    }
}
