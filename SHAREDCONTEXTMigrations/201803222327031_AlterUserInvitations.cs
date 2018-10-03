namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterUserInvitations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInvitations", "name", c => c.String());
            AddColumn("dbo.UserInvitations", "username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInvitations", "username");
            DropColumn("dbo.UserInvitations", "name");
        }
    }
}
