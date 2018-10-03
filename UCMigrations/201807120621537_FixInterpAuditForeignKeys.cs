namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixInterpAuditForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InterpretationAudits", "Inspection_inspection_auto", "dbo.TRACK_INSPECTION");
            DropForeignKey("dbo.InterpretationAudits", "User_user_auto", "dbo.USER_TABLE");
            DropIndex("dbo.InterpretationAudits", new[] { "Inspection_inspection_auto" });
            DropIndex("dbo.InterpretationAudits", new[] { "User_user_auto" });
            DropColumn("dbo.InterpretationAudits", "InspectionId");
            DropColumn("dbo.InterpretationAudits", "UserId");
            RenameColumn(table: "dbo.InterpretationAudits", name: "Inspection_inspection_auto", newName: "InspectionId");
            RenameColumn(table: "dbo.InterpretationAudits", name: "User_user_auto", newName: "UserId");
            AlterColumn("dbo.InterpretationAudits", "InspectionId", c => c.Int(nullable: false));
            AlterColumn("dbo.InterpretationAudits", "UserId", c => c.Long(nullable: false));
            CreateIndex("dbo.InterpretationAudits", "UserId");
            CreateIndex("dbo.InterpretationAudits", "InspectionId");
            AddForeignKey("dbo.InterpretationAudits", "InspectionId", "dbo.TRACK_INSPECTION", "inspection_auto", cascadeDelete: true);
            AddForeignKey("dbo.InterpretationAudits", "UserId", "dbo.USER_TABLE", "user_auto", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InterpretationAudits", "UserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.InterpretationAudits", "InspectionId", "dbo.TRACK_INSPECTION");
            DropIndex("dbo.InterpretationAudits", new[] { "InspectionId" });
            DropIndex("dbo.InterpretationAudits", new[] { "UserId" });
            AlterColumn("dbo.InterpretationAudits", "UserId", c => c.Long());
            AlterColumn("dbo.InterpretationAudits", "InspectionId", c => c.Int());
            RenameColumn(table: "dbo.InterpretationAudits", name: "UserId", newName: "User_user_auto");
            RenameColumn(table: "dbo.InterpretationAudits", name: "InspectionId", newName: "Inspection_inspection_auto");
            AddColumn("dbo.InterpretationAudits", "UserId", c => c.Long(nullable: false));
            AddColumn("dbo.InterpretationAudits", "InspectionId", c => c.Int(nullable: false));
            CreateIndex("dbo.InterpretationAudits", "User_user_auto");
            CreateIndex("dbo.InterpretationAudits", "Inspection_inspection_auto");
            AddForeignKey("dbo.InterpretationAudits", "User_user_auto", "dbo.USER_TABLE", "user_auto");
            AddForeignKey("dbo.InterpretationAudits", "Inspection_inspection_auto", "dbo.TRACK_INSPECTION", "inspection_auto");
        }
    }
}
