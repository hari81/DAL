namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InspectionAdditionalTablesAdded : DbMigration
    {
        public override void Up()
        {/*
            CreateTable(
                "dbo.INSPECTION_COMPARTTYPE_RECORD_IMAGES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecordId = c.Int(nullable: false),
                        Data = c.Binary(),
                        Title = c.String(maxLength: 250),
                        Comment = c.String(),
                        InspectionCompartTypeRecord_Id = c.Int(),
                        TRACK_INSPECTION_inspection_auto = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.INSPECTION_COMPARTTYPE_RECORD", t => t.InspectionCompartTypeRecord_Id)
                .ForeignKey("dbo.TRACK_INSPECTION", t => t.TRACK_INSPECTION_inspection_auto)
                .Index(t => t.InspectionCompartTypeRecord_Id)
                .Index(t => t.TRACK_INSPECTION_inspection_auto);
            
            CreateTable(
                "dbo.INSPECTION_COMPARTTYPE_RECORD",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompartTypeAdditionalId = c.Int(nullable: false),
                        Reading = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToolId = c.Int(nullable: false),
                        MeasureNumber = c.Int(nullable: false),
                        InspectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", t => t.CompartTypeAdditionalId, cascadeDelete: true)
                .ForeignKey("dbo.TRACK_INSPECTION", t => t.InspectionId, cascadeDelete: true)
                .ForeignKey("dbo.TRACK_TOOL", t => t.ToolId, cascadeDelete: true)
                .Index(t => t.CompartTypeAdditionalId)
                .Index(t => t.ToolId)
                .Index(t => t.InspectionId);
            
            CreateTable(
                "dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompartTypeId = c.Int(nullable: false),
                        ModelId = c.Int(),
                        CustomerId = c.Long(),
                        AdditionalTypeId = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        DefaultNumberOfReadings = c.Int(nullable: false),
                        DefaultToolId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.COMPARTTYPE_ADDITIONAL_TYPE", t => t.AdditionalTypeId, cascadeDelete: true)
                .ForeignKey("dbo.LU_COMPART_TYPE", t => t.CompartTypeId, cascadeDelete: true)
                .ForeignKey("dbo.CUSTOMER", t => t.CustomerId)
                .ForeignKey("dbo.TRACK_TOOL", t => t.DefaultToolId)
                .ForeignKey("dbo.MODEL", t => t.ModelId)
                .Index(t => t.CompartTypeId)
                .Index(t => t.ModelId)
                .Index(t => t.CustomerId)
                .Index(t => t.AdditionalTypeId)
                .Index(t => t.DefaultToolId);
            
            CreateTable(
                "dbo.COMPARTTYPE_ADDITIONAL_TYPE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.COMPARTTYPE_ADDITIONAL_POSSIBLE_TOOLS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompartTypeAddtionalId = c.Int(nullable: false),
                        ToolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", t => t.CompartTypeAddtionalId, cascadeDelete: true)
                .ForeignKey("dbo.TRACK_TOOL", t => t.ToolId, cascadeDelete: true)
                .Index(t => new { t.CompartTypeAddtionalId, t.ToolId }, unique: true, name: "IX_CompartTypeAddtionalTool");
            */
        }
        
        public override void Down()
        {/*
            DropForeignKey("dbo.INSPECTION_COMPARTTYPE_RECORD_IMAGES", "TRACK_INSPECTION_inspection_auto", "dbo.TRACK_INSPECTION");
            DropForeignKey("dbo.INSPECTION_COMPARTTYPE_RECORD", "ToolId", "dbo.TRACK_TOOL");
            DropForeignKey("dbo.INSPECTION_COMPARTTYPE_RECORD_IMAGES", "InspectionCompartTypeRecord_Id", "dbo.INSPECTION_COMPARTTYPE_RECORD");
            DropForeignKey("dbo.INSPECTION_COMPARTTYPE_RECORD", "InspectionId", "dbo.TRACK_INSPECTION");
            DropForeignKey("dbo.INSPECTION_COMPARTTYPE_RECORD", "CompartTypeAdditionalId", "dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL");
            DropForeignKey("dbo.COMPARTTYPE_ADDITIONAL_POSSIBLE_TOOLS", "ToolId", "dbo.TRACK_TOOL");
            DropForeignKey("dbo.COMPARTTYPE_ADDITIONAL_POSSIBLE_TOOLS", "CompartTypeAddtionalId", "dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL");
            DropForeignKey("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", "ModelId", "dbo.MODEL");
            DropForeignKey("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", "DefaultToolId", "dbo.TRACK_TOOL");
            DropForeignKey("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", "CustomerId", "dbo.CUSTOMER");
            DropForeignKey("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", "CompartTypeId", "dbo.LU_COMPART_TYPE");
            DropForeignKey("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", "AdditionalTypeId", "dbo.COMPARTTYPE_ADDITIONAL_TYPE");
            DropIndex("dbo.COMPARTTYPE_ADDITIONAL_POSSIBLE_TOOLS", "IX_CompartTypeAddtionalTool");
            DropIndex("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", new[] { "DefaultToolId" });
            DropIndex("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", new[] { "AdditionalTypeId" });
            DropIndex("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", new[] { "CustomerId" });
            DropIndex("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", new[] { "ModelId" });
            DropIndex("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", new[] { "CompartTypeId" });
            DropIndex("dbo.INSPECTION_COMPARTTYPE_RECORD", new[] { "InspectionId" });
            DropIndex("dbo.INSPECTION_COMPARTTYPE_RECORD", new[] { "ToolId" });
            DropIndex("dbo.INSPECTION_COMPARTTYPE_RECORD", new[] { "CompartTypeAdditionalId" });
            DropIndex("dbo.INSPECTION_COMPARTTYPE_RECORD_IMAGES", new[] { "TRACK_INSPECTION_inspection_auto" });
            DropIndex("dbo.INSPECTION_COMPARTTYPE_RECORD_IMAGES", new[] { "InspectionCompartTypeRecord_Id" });
            DropTable("dbo.COMPARTTYPE_ADDITIONAL_POSSIBLE_TOOLS");
            DropTable("dbo.COMPARTTYPE_ADDITIONAL_TYPE");
            DropTable("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL");
            DropTable("dbo.INSPECTION_COMPARTTYPE_RECORD");
            DropTable("dbo.INSPECTION_COMPARTTYPE_RECORD_IMAGES");*/
        }
    }
}
