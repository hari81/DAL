namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recordStatus : DbMigration
    {
        public override void Up()
        {
            //Updated in Shared Context
            //AddColumn("dbo.ACTION_TAKEN_HISTORY", "recordStatus", c => c.Int(nullable: false));
            //AddColumn("dbo.GET_EVENTS", "recordStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.GET_EVENTS", "recordStatus");
            //DropColumn("dbo.ACTION_TAKEN_HISTORY", "recordStatus");
        }
    }
}
