namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class set_jobsite_nullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GET_EVENTS", "jobsite", "dbo.CRSF");
            DropIndex("dbo.GET_EVENTS", new[] { "jobsite" });
            AlterColumn("dbo.GET_EVENTS", "jobsite", c => c.Long());
            CreateIndex("dbo.GET_EVENTS", "jobsite");
            AddForeignKey("dbo.GET_EVENTS", "jobsite", "dbo.CRSF", "crsf_auto");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GET_EVENTS", "jobsite", "dbo.CRSF");
            DropIndex("dbo.GET_EVENTS", new[] { "jobsite" });
            AlterColumn("dbo.GET_EVENTS", "jobsite", c => c.Long(nullable: false));
            CreateIndex("dbo.GET_EVENTS", "jobsite");
            AddForeignKey("dbo.GET_EVENTS", "jobsite", "dbo.CRSF", "crsf_auto", cascadeDelete: true);
        }
    }
}
