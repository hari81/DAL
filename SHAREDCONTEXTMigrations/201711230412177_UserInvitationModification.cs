namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserInvitationModification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInvitations", "EnableUndercarriage", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserInvitations", "EnableGET", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInvitations", "EnableGET");
            DropColumn("dbo.UserInvitations", "EnableUndercarriage");
        }
    }
}
