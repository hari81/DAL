namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DahsboradSearchHtmlColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DASHBOARD_SEARCH", "Html", c => c.String());
            AddColumn("dbo.DASHBOARD_SEARCH", "Element", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DASHBOARD_SEARCH", "Element");
            DropColumn("dbo.DASHBOARD_SEARCH", "Html");
        }
    }
}
