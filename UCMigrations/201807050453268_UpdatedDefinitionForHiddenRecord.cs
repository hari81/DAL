namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDefinitionForHiddenRecord : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", "MeasurementPointRecordId", "dbo.MEASUREMENT_POINT_RECORD");
            DropIndex("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", new[] { "MeasurementPointRecordId" });
            RenameColumn(table: "dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", name: "MeasurementPointRecordId", newName: "MEASUREMENT_POINT_RECORD_Id");
            AddColumn("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", "CompartMeasurementPointId", c => c.Int(nullable: false));
            AlterColumn("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", "MEASUREMENT_POINT_RECORD_Id", c => c.Int());
            CreateIndex("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", "CompartMeasurementPointId");
            CreateIndex("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", "MEASUREMENT_POINT_RECORD_Id");
            AddForeignKey("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", "CompartMeasurementPointId", "dbo.COMPART_MEASUREMENT_POINT", "Id", cascadeDelete: true);
            AddForeignKey("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", "MEASUREMENT_POINT_RECORD_Id", "dbo.MEASUREMENT_POINT_RECORD", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", "MEASUREMENT_POINT_RECORD_Id", "dbo.MEASUREMENT_POINT_RECORD");
            DropForeignKey("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", "CompartMeasurementPointId", "dbo.COMPART_MEASUREMENT_POINT");
            DropIndex("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", new[] { "MEASUREMENT_POINT_RECORD_Id" });
            DropIndex("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", new[] { "CompartMeasurementPointId" });
            AlterColumn("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", "MEASUREMENT_POINT_RECORD_Id", c => c.Int(nullable: false));
            DropColumn("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", "CompartMeasurementPointId");
            RenameColumn(table: "dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", name: "MEASUREMENT_POINT_RECORD_Id", newName: "MeasurementPointRecordId");
            CreateIndex("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", "MeasurementPointRecordId");
            AddForeignKey("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", "MeasurementPointRecordId", "dbo.MEASUREMENT_POINT_RECORD", "Id", cascadeDelete: true);
        }
    }
}
