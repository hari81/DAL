namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateInterpretationAuditLogTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InterpretationAudits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventTime = c.DateTime(nullable: false),
                        Message = c.String(),
                        UserId = c.Long(nullable: false),
                        InspectionId = c.Int(nullable: false),
                        Inspection_inspection_auto = c.Int(),
                        User_user_auto = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TRACK_INSPECTION", t => t.Inspection_inspection_auto)
                .ForeignKey("dbo.USER_TABLE", t => t.User_user_auto)
                .Index(t => t.Inspection_inspection_auto)
                .Index(t => t.User_user_auto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InterpretationAudits", "User_user_auto", "dbo.USER_TABLE");
            DropForeignKey("dbo.InterpretationAudits", "Inspection_inspection_auto", "dbo.TRACK_INSPECTION");
            DropIndex("dbo.InterpretationAudits", new[] { "User_user_auto" });
            DropIndex("dbo.InterpretationAudits", new[] { "Inspection_inspection_auto" });
            DropTable("dbo.InterpretationAudits");
        }
    }
}
