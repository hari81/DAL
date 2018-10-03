namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiningShovelReportTablesAdded : DbMigration
    {
        public override void Up()
        {/*
            CreateTable(
                "dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeasurementPointRecordId = c.Int(nullable: false),
                        ReportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MEASUREMENT_POINT_RECORD", t => t.MeasurementPointRecordId, cascadeDelete: true)
                .ForeignKey("dbo.MININGSHOVEL_REPORT", t => t.ReportId, cascadeDelete: true)
                .Index(t => t.MeasurementPointRecordId)
                .Index(t => t.ReportId);
            
            CreateTable(
                "dbo.MININGSHOVEL_REPORT",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InspectionId = c.Int(nullable: false),
                        CreatedByUserId = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.REPORT_HIDDEN_ADDITIONAL_RECORD_IMAGE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompartTypeRecordImageId = c.Int(nullable: false),
                        ReportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.INSPECTION_COMPARTTYPE_RECORD_IMAGES", t => t.CompartTypeRecordImageId, cascadeDelete: true)
                .ForeignKey("dbo.MININGSHOVEL_REPORT", t => t.ReportId, cascadeDelete: true)
                .Index(t => t.CompartTypeRecordImageId)
                .Index(t => t.ReportId);
            
            CreateTable(
                "dbo.REPORT_HIDDEN_ADDITIONAL_RECORD",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompartTypeRecordId = c.Int(nullable: false),
                        ReportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.INSPECTION_COMPARTTYPE_RECORD", t => t.CompartTypeRecordId, cascadeDelete: true)
                .ForeignKey("dbo.MININGSHOVEL_REPORT", t => t.ReportId, cascadeDelete: true)
                .Index(t => t.CompartTypeRecordId)
                .Index(t => t.ReportId);
            
            CreateTable(
                "dbo.REPORT_HIDDEN_COMPARTTYPE_MANDATORY_IMAGE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InspectionCompartTypeImageId = c.Int(nullable: false),
                        ReportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.INSPECTION_COMPARTTYPE_IMAGES", t => t.InspectionCompartTypeImageId, cascadeDelete: true)
                .ForeignKey("dbo.MININGSHOVEL_REPORT", t => t.ReportId, cascadeDelete: true)
                .Index(t => t.InspectionCompartTypeImageId)
                .Index(t => t.ReportId);
            
            CreateTable(
                "dbo.INSPECTION_COMPARTTYPE_IMAGES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompartTypeMandatoryImageId = c.Int(nullable: false),
                        InspectionId = c.Int(nullable: false),
                        Data = c.Binary(),
                        Title = c.String(maxLength: 250),
                        Comment = c.String(),
                        Side = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE", t => t.CompartTypeMandatoryImageId, cascadeDelete: true)
                .ForeignKey("dbo.TRACK_INSPECTION", t => t.InspectionId, cascadeDelete: true)
                .Index(t => t.CompartTypeMandatoryImageId)
                .Index(t => t.InspectionId);
            
            CreateTable(
                "dbo.CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompartTypeId = c.Int(nullable: false),
                        ModelId = c.Int(),
                        CustomerId = c.Long(),
                        Order = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        DefaultNumberOfImages = c.Int(nullable: false),
                        RecordStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LU_COMPART_TYPE", t => t.CompartTypeId, cascadeDelete: true)
                .ForeignKey("dbo.CUSTOMER", t => t.CustomerId)
                .ForeignKey("dbo.MODEL", t => t.ModelId)
                .Index(t => t.CompartTypeId)
                .Index(t => t.ModelId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.REPORT_HIDDEN_INSPECTION_MANDATORY_IMAGES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InspectionMandatoryImageId = c.Int(nullable: false),
                        ReportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.INSPECTION_MANDATORY_IMAGES", t => t.InspectionMandatoryImageId, cascadeDelete: true)
                .ForeignKey("dbo.MININGSHOVEL_REPORT", t => t.ReportId, cascadeDelete: true)
                .Index(t => t.InspectionMandatoryImageId)
                .Index(t => t.ReportId);
            
            CreateTable(
                "dbo.INSPECTION_MANDATORY_IMAGES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerModelMandatoryImageId = c.Int(nullable: false),
                        InspectionId = c.Int(nullable: false),
                        Data = c.Binary(),
                        Title = c.String(maxLength: 250),
                        Comment = c.String(),
                        Side = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUSTOMER_MODEL_MANDATORY_IMAGE", t => t.CustomerModelMandatoryImageId, cascadeDelete: true)
                .ForeignKey("dbo.TRACK_INSPECTION", t => t.InspectionId, cascadeDelete: true)
                .Index(t => t.CustomerModelMandatoryImageId)
                .Index(t => t.InspectionId);
            
            CreateTable(
                "dbo.CUSTOMER_MODEL_MANDATORY_IMAGE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelId = c.Int(),
                        CustomerId = c.Long(),
                        Order = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        DefaultNumberOfImages = c.Int(nullable: false),
                        RecordStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUSTOMER", t => t.CustomerId)
                .ForeignKey("dbo.MODEL", t => t.ModelId)
                .Index(t => t.ModelId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.REPORT_HIDDEN_MEASUREPOINT_RECORD_IMAGES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeasurePointRecordImageId = c.Int(nullable: false),
                        ReportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MEASUREPOINT_RECORD_IMAGES", t => t.MeasurePointRecordImageId, cascadeDelete: true)
                .ForeignKey("dbo.MININGSHOVEL_REPORT", t => t.ReportId, cascadeDelete: true)
                .Index(t => t.MeasurePointRecordImageId)
                .Index(t => t.ReportId);
            
            CreateTable(
                "dbo.MEASUREPOINT_RECORD_IMAGES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeasurePointRecordId = c.Int(nullable: false),
                        Data = c.Binary(),
                        Title = c.String(maxLength: 250),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MEASUREMENT_POINT_RECORD", t => t.MeasurePointRecordId, cascadeDelete: true)
                .Index(t => t.MeasurePointRecordId);
            */
        }
        
        public override void Down()
        {/*
            DropForeignKey("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", "ReportId", "dbo.MININGSHOVEL_REPORT");
            DropForeignKey("dbo.REPORT_HIDDEN_MEASUREPOINT_RECORD_IMAGES", "ReportId", "dbo.MININGSHOVEL_REPORT");
            DropForeignKey("dbo.REPORT_HIDDEN_MEASUREPOINT_RECORD_IMAGES", "MeasurePointRecordImageId", "dbo.MEASUREPOINT_RECORD_IMAGES");
            DropForeignKey("dbo.MEASUREPOINT_RECORD_IMAGES", "MeasurePointRecordId", "dbo.MEASUREMENT_POINT_RECORD");
            DropForeignKey("dbo.REPORT_HIDDEN_INSPECTION_MANDATORY_IMAGES", "ReportId", "dbo.MININGSHOVEL_REPORT");
            DropForeignKey("dbo.REPORT_HIDDEN_INSPECTION_MANDATORY_IMAGES", "InspectionMandatoryImageId", "dbo.INSPECTION_MANDATORY_IMAGES");
            DropForeignKey("dbo.INSPECTION_MANDATORY_IMAGES", "InspectionId", "dbo.TRACK_INSPECTION");
            DropForeignKey("dbo.INSPECTION_MANDATORY_IMAGES", "CustomerModelMandatoryImageId", "dbo.CUSTOMER_MODEL_MANDATORY_IMAGE");
            DropForeignKey("dbo.CUSTOMER_MODEL_MANDATORY_IMAGE", "ModelId", "dbo.MODEL");
            DropForeignKey("dbo.CUSTOMER_MODEL_MANDATORY_IMAGE", "CustomerId", "dbo.CUSTOMER");
            DropForeignKey("dbo.REPORT_HIDDEN_COMPARTTYPE_MANDATORY_IMAGE", "ReportId", "dbo.MININGSHOVEL_REPORT");
            DropForeignKey("dbo.REPORT_HIDDEN_COMPARTTYPE_MANDATORY_IMAGE", "InspectionCompartTypeImageId", "dbo.INSPECTION_COMPARTTYPE_IMAGES");
            DropForeignKey("dbo.INSPECTION_COMPARTTYPE_IMAGES", "InspectionId", "dbo.TRACK_INSPECTION");
            DropForeignKey("dbo.INSPECTION_COMPARTTYPE_IMAGES", "CompartTypeMandatoryImageId", "dbo.CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE");
            DropForeignKey("dbo.CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE", "ModelId", "dbo.MODEL");
            DropForeignKey("dbo.CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE", "CustomerId", "dbo.CUSTOMER");
            DropForeignKey("dbo.CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE", "CompartTypeId", "dbo.LU_COMPART_TYPE");
            DropForeignKey("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD_IMAGE", "ReportId", "dbo.MININGSHOVEL_REPORT");
            DropForeignKey("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD_IMAGE", "CompartTypeRecordImageId", "dbo.INSPECTION_COMPARTTYPE_RECORD_IMAGES");
            DropForeignKey("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD", "ReportId", "dbo.MININGSHOVEL_REPORT");
            DropForeignKey("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD", "CompartTypeRecordId", "dbo.INSPECTION_COMPARTTYPE_RECORD");
            DropForeignKey("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", "MeasurementPointRecordId", "dbo.MEASUREMENT_POINT_RECORD");
            DropIndex("dbo.MEASUREPOINT_RECORD_IMAGES", new[] { "MeasurePointRecordId" });
            DropIndex("dbo.REPORT_HIDDEN_MEASUREPOINT_RECORD_IMAGES", new[] { "ReportId" });
            DropIndex("dbo.REPORT_HIDDEN_MEASUREPOINT_RECORD_IMAGES", new[] { "MeasurePointRecordImageId" });
            DropIndex("dbo.CUSTOMER_MODEL_MANDATORY_IMAGE", new[] { "CustomerId" });
            DropIndex("dbo.CUSTOMER_MODEL_MANDATORY_IMAGE", new[] { "ModelId" });
            DropIndex("dbo.INSPECTION_MANDATORY_IMAGES", new[] { "InspectionId" });
            DropIndex("dbo.INSPECTION_MANDATORY_IMAGES", new[] { "CustomerModelMandatoryImageId" });
            DropIndex("dbo.REPORT_HIDDEN_INSPECTION_MANDATORY_IMAGES", new[] { "ReportId" });
            DropIndex("dbo.REPORT_HIDDEN_INSPECTION_MANDATORY_IMAGES", new[] { "InspectionMandatoryImageId" });
            DropIndex("dbo.CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE", new[] { "CustomerId" });
            DropIndex("dbo.CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE", new[] { "ModelId" });
            DropIndex("dbo.CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE", new[] { "CompartTypeId" });
            DropIndex("dbo.INSPECTION_COMPARTTYPE_IMAGES", new[] { "InspectionId" });
            DropIndex("dbo.INSPECTION_COMPARTTYPE_IMAGES", new[] { "CompartTypeMandatoryImageId" });
            DropIndex("dbo.REPORT_HIDDEN_COMPARTTYPE_MANDATORY_IMAGE", new[] { "ReportId" });
            DropIndex("dbo.REPORT_HIDDEN_COMPARTTYPE_MANDATORY_IMAGE", new[] { "InspectionCompartTypeImageId" });
            DropIndex("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD", new[] { "ReportId" });
            DropIndex("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD", new[] { "CompartTypeRecordId" });
            DropIndex("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD_IMAGE", new[] { "ReportId" });
            DropIndex("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD_IMAGE", new[] { "CompartTypeRecordImageId" });
            DropIndex("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", new[] { "ReportId" });
            DropIndex("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", new[] { "MeasurementPointRecordId" });
            DropTable("dbo.MEASUREPOINT_RECORD_IMAGES");
            DropTable("dbo.REPORT_HIDDEN_MEASUREPOINT_RECORD_IMAGES");
            DropTable("dbo.CUSTOMER_MODEL_MANDATORY_IMAGE");
            DropTable("dbo.INSPECTION_MANDATORY_IMAGES");
            DropTable("dbo.REPORT_HIDDEN_INSPECTION_MANDATORY_IMAGES");
            DropTable("dbo.CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE");
            DropTable("dbo.INSPECTION_COMPARTTYPE_IMAGES");
            DropTable("dbo.REPORT_HIDDEN_COMPARTTYPE_MANDATORY_IMAGE");
            DropTable("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD");
            DropTable("dbo.REPORT_HIDDEN_ADDITIONAL_RECORD_IMAGE");
            DropTable("dbo.MININGSHOVEL_REPORT");
            DropTable("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD");
            */
        }
    }
}
