namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterUSerInvitationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInvitationAccessToCustomers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        customerId = c.Long(nullable: false),
                        invitationId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUSTOMER", t => t.customerId, cascadeDelete: true)
                .ForeignKey("dbo.UserInvitations", t => t.invitationId, cascadeDelete: true)
                .Index(t => t.customerId)
                .Index(t => t.invitationId);
            
            CreateTable(
                "dbo.UserInvitationJobRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        jobRoleId = c.Int(nullable: false),
                        invitationId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USER_GROUP", t => t.jobRoleId, cascadeDelete: true)
                .ForeignKey("dbo.UserInvitations", t => t.invitationId, cascadeDelete: true)
                .Index(t => t.jobRoleId)
                .Index(t => t.invitationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInvitationJobRoles", "invitationId", "dbo.UserInvitations");
            DropForeignKey("dbo.UserInvitationJobRoles", "jobRoleId", "dbo.USER_GROUP");
            DropForeignKey("dbo.UserInvitationAccessToCustomers", "invitationId", "dbo.UserInvitations");
            DropForeignKey("dbo.UserInvitationAccessToCustomers", "customerId", "dbo.CUSTOMER");
            DropIndex("dbo.UserInvitationJobRoles", new[] { "invitationId" });
            DropIndex("dbo.UserInvitationJobRoles", new[] { "jobRoleId" });
            DropIndex("dbo.UserInvitationAccessToCustomers", new[] { "invitationId" });
            DropIndex("dbo.UserInvitationAccessToCustomers", new[] { "customerId" });
            DropTable("dbo.UserInvitationJobRoles");
            DropTable("dbo.UserInvitationAccessToCustomers");
        }
    }
}
