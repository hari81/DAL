namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_Inventory_events_table : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.GET_EVENTS", "jobsite", "dbo.CRSF");
            //DropIndex("dbo.GET_EVENTS", new[] { "jobsite" });
            //DropColumn("dbo.GET_EVENTS", "jobsite");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.GET_EVENTS", "jobsite", c => c.Long());
            //CreateIndex("dbo.GET_EVENTS", "jobsite");
            //AddForeignKey("dbo.GET_EVENTS", "jobsite", "dbo.CRSF", "crsf_auto");
        }
    }
}
