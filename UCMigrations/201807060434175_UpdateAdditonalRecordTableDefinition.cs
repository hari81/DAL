namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAdditonalRecordTableDefinition : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD", "CompartTypeRecordId", "dbo.INSPECTION_COMPARTTYPE_RECORD");
            DropIndex("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD", new[] { "CompartTypeRecordId" });
            AddColumn("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD", "CompartTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD", "CompartTypeId");
            AddForeignKey("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD", "CompartTypeId", "dbo.LU_COMPART_TYPE", "comparttype_auto", cascadeDelete: true);
            DropColumn("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD", "CompartTypeRecordId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD", "CompartTypeRecordId", c => c.Int(nullable: false));
            DropForeignKey("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD", "CompartTypeId", "dbo.LU_COMPART_TYPE");
            DropIndex("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD", new[] { "CompartTypeId" });
            DropColumn("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD", "CompartTypeId");
            CreateIndex("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD", "CompartTypeRecordId");
            AddForeignKey("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD", "CompartTypeRecordId", "dbo.INSPECTION_COMPARTTYPE_RECORD", "Id", cascadeDelete: true);
        }
    }
}
