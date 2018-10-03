namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_jobsite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GET_EVENTS", "jobsite", c => c.Long(nullable: true));
            CreateIndex("dbo.GET_EVENTS", "jobsite");
            AddForeignKey("dbo.GET_EVENTS", "jobsite", "dbo.CRSF", "crsf_auto", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GET_EVENTS", "jobsite", "dbo.CRSF");
            DropIndex("dbo.GET_EVENTS", new[] { "jobsite" });
            DropColumn("dbo.GET_EVENTS", "jobsite");
        }
    }
}
