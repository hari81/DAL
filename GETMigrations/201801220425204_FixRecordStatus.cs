namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRecordStatus : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.GET_EVENTS_COMPONENT", "recordStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.GET_EVENTS_COMPONENT", "recordStatus");
        }
    }
}
