namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Record_status : DbMigration
    {
        public override void Up()
        {
            // GET-59 - Already added in GETContext
            //AddColumn("dbo.GET_EVENTS_COMPONENT", "recordStatus", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            //DropColumn("dbo.GET_EVENTS_COMPONENT", "recordStatus");
        }
    }
}
