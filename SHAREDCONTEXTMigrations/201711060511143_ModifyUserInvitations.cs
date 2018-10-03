namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyUserInvitations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInvitations", "SenderEmail", c => c.String());
            AddColumn("dbo.UserInvitations", "SenderAspUserId", c => c.String());
            AddColumn("dbo.UserInvitations", "InvitationAccepted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInvitations", "InvitationAccepted");
            DropColumn("dbo.UserInvitations", "SenderAspUserId");
            DropColumn("dbo.UserInvitations", "SenderEmail");
        }
    }
}
