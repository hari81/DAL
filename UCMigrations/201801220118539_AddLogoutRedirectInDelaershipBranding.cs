namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLogoutRedirectInDelaershipBranding : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DealershipBranding", "LogoutRedirectUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DealershipBranding", "LogoutRedirectUrl");
        }
    }
}
