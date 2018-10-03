namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class set_event_comments_to_nvarchar3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GET_EVENTS", "comment", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GET_EVENTS", "comment", c => c.String());
        }
    }
}
