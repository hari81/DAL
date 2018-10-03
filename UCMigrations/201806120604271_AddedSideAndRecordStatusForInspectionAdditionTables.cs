namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSideAndRecordStatusForInspectionAdditionTables : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.INSPECTION_COMPARTTYPE_RECORD", "Side", c => c.Int(nullable: false));
            AddColumn("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", "RecordStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.INSPECTION_COMPARTTYPE_IMAGES", "InspectionId", "dbo.TRACK_INSPECTION");
            DropForeignKey("dbo.INSPECTION_COMPARTTYPE_IMAGES", "CompartTypeMandatoryImageId", "dbo.CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE");
            DropForeignKey("dbo.CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE", "ModelId", "dbo.MODEL");
            DropForeignKey("dbo.CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE", "CustomerId", "dbo.CUSTOMER");
            DropForeignKey("dbo.CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE", "CompartTypeId", "dbo.LU_COMPART_TYPE");
            DropIndex("dbo.INSPECTION_COMPARTTYPE_IMAGES", new[] { "InspectionId" });
            DropIndex("dbo.INSPECTION_COMPARTTYPE_IMAGES", new[] { "CompartTypeMandatoryImageId" });
            DropIndex("dbo.CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE", new[] { "CustomerId" });
            DropIndex("dbo.CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE", new[] { "ModelId" });
            DropIndex("dbo.CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE", new[] { "CompartTypeId" });
            DropColumn("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", "RecordStatus");
            DropColumn("dbo.INSPECTION_COMPARTTYPE_RECORD", "Side");
            DropTable("dbo.INSPECTION_COMPARTTYPE_IMAGES");
            DropTable("dbo.CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE");
        }
    }
}
