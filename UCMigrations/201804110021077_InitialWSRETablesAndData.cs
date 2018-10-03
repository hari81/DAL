namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialWSRETablesAndData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WSREs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        SystemId = c.Long(nullable: false),
                        JobsiteId = c.Long(nullable: false),
                        InspectorId = c.Long(nullable: false),
                        JobNumber = c.String(),
                        OldTagNumber = c.String(),
                        OverallComment = c.String(),
                        OverallRecommendation = c.String(),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USER_TABLE", t => t.InspectorId, cascadeDelete: false)
                .ForeignKey("dbo.CRSF", t => t.JobsiteId, cascadeDelete: false)
                .ForeignKey("dbo.WSREStatusTypes", t => t.StatusId, cascadeDelete: false)
                .ForeignKey("dbo.LU_Module_Sub", t => t.SystemId, cascadeDelete: false)
                .Index(t => t.SystemId)
                .Index(t => t.JobsiteId)
                .Index(t => t.InspectorId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.WSREStatusTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WSREComponentImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComponentRecordId = c.Int(nullable: false),
                        Title = c.String(),
                        Comment = c.String(),
                        Data = c.Binary(),
                        IncludeInReport = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WSREComponentRecords", t => t.ComponentRecordId, cascadeDelete: false)
                .Index(t => t.ComponentRecordId);
            
            CreateTable(
                "dbo.WSREComponentRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WSREId = c.Int(nullable: false),
                        ComponentId = c.Long(nullable: false),
                        Measurement = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RecommendationId = c.Int(nullable: false),
                        MeasurementToolId = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GENERAL_EQ_UNIT", t => t.ComponentId, cascadeDelete: false)
                .ForeignKey("dbo.TRACK_TOOL", t => t.MeasurementToolId, cascadeDelete: false)
                .ForeignKey("dbo.WSREComponentRecommendations", t => t.RecommendationId, cascadeDelete: false)
                .ForeignKey("dbo.WSREs", t => t.WSREId, cascadeDelete: false)
                .Index(t => t.WSREId)
                .Index(t => t.ComponentId)
                .Index(t => t.RecommendationId)
                .Index(t => t.MeasurementToolId);
            
            CreateTable(
                "dbo.WSREComponentRecommendations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WSREContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WSREId = c.Int(nullable: false),
                        UserId = c.Long(nullable: false),
                        EmailSent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USER_TABLE", t => t.UserId, cascadeDelete: false)
                .ForeignKey("dbo.WSREs", t => t.WSREId, cascadeDelete: false)
                .Index(t => t.WSREId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.WSRECrackTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WSREId = c.Int(nullable: false),
                        TestPassed = c.Boolean(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WSREs", t => t.WSREId, cascadeDelete: false)
                .Index(t => t.WSREId);
            
            CreateTable(
                "dbo.WSRECrackTestImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CrackTestId = c.Int(nullable: false),
                        Title = c.String(),
                        Comment = c.String(),
                        Data = c.Binary(),
                        IncludeInReport = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WSRECrackTests", t => t.CrackTestId, cascadeDelete: false)
                .Index(t => t.CrackTestId);
            
            CreateTable(
                "dbo.WSREDipTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WSREId = c.Int(nullable: false),
                        Measurement = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ConditionId = c.Int(nullable: false),
                        Comment = c.String(),
                        Recommendation = c.String(),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WSREDipTestConditions", t => t.ConditionId, cascadeDelete: false)
                .ForeignKey("dbo.WSREs", t => t.WSREId, cascadeDelete: false)
                .Index(t => t.WSREId)
                .Index(t => t.ConditionId);
            
            CreateTable(
                "dbo.WSREDipTestConditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WSREDipTestImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DipTestId = c.Int(nullable: false),
                        Title = c.String(),
                        Comment = c.String(),
                        Data = c.Binary(),
                        IncludeInReport = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WSREDipTests", t => t.DipTestId, cascadeDelete: false)
                .Index(t => t.DipTestId);
            
            CreateTable(
                "dbo.WSREInitialImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WSREId = c.Int(nullable: false),
                        Title = c.String(),
                        Comment = c.String(),
                        Data = c.Binary(),
                        IncludeInReport = c.Boolean(nullable: false),
                        ImageTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WSREInitialImageTypes", t => t.ImageTypeId, cascadeDelete: false)
                .ForeignKey("dbo.WSREs", t => t.WSREId, cascadeDelete: false)
                .Index(t => t.WSREId)
                .Index(t => t.ImageTypeId);
            
            CreateTable(
                "dbo.WSREInitialImageTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WSREInitialImages", "WSREId", "dbo.WSREs");
            DropForeignKey("dbo.WSREInitialImages", "ImageTypeId", "dbo.WSREInitialImageTypes");
            DropForeignKey("dbo.WSREDipTestImages", "DipTestId", "dbo.WSREDipTests");
            DropForeignKey("dbo.WSREDipTests", "WSREId", "dbo.WSREs");
            DropForeignKey("dbo.WSREDipTests", "ConditionId", "dbo.WSREDipTestConditions");
            DropForeignKey("dbo.WSRECrackTestImages", "CrackTestId", "dbo.WSRECrackTests");
            DropForeignKey("dbo.WSRECrackTests", "WSREId", "dbo.WSREs");
            DropForeignKey("dbo.WSREContacts", "WSREId", "dbo.WSREs");
            DropForeignKey("dbo.WSREContacts", "UserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.WSREComponentImages", "ComponentRecordId", "dbo.WSREComponentRecords");
            DropForeignKey("dbo.WSREComponentRecords", "WSREId", "dbo.WSREs");
            DropForeignKey("dbo.WSREComponentRecords", "RecommendationId", "dbo.WSREComponentRecommendations");
            DropForeignKey("dbo.WSREComponentRecords", "MeasurementToolId", "dbo.TRACK_TOOL");
            DropForeignKey("dbo.WSREComponentRecords", "ComponentId", "dbo.GENERAL_EQ_UNIT");
            DropForeignKey("dbo.WSREs", "SystemId", "dbo.LU_Module_Sub");
            DropForeignKey("dbo.WSREs", "StatusId", "dbo.WSREStatusTypes");
            DropForeignKey("dbo.WSREs", "JobsiteId", "dbo.CRSF");
            DropForeignKey("dbo.WSREs", "InspectorId", "dbo.USER_TABLE");
            DropIndex("dbo.WSREInitialImages", new[] { "ImageTypeId" });
            DropIndex("dbo.WSREInitialImages", new[] { "WSREId" });
            DropIndex("dbo.WSREDipTestImages", new[] { "DipTestId" });
            DropIndex("dbo.WSREDipTests", new[] { "ConditionId" });
            DropIndex("dbo.WSREDipTests", new[] { "WSREId" });
            DropIndex("dbo.WSRECrackTestImages", new[] { "CrackTestId" });
            DropIndex("dbo.WSRECrackTests", new[] { "WSREId" });
            DropIndex("dbo.WSREContacts", new[] { "UserId" });
            DropIndex("dbo.WSREContacts", new[] { "WSREId" });
            DropIndex("dbo.WSREComponentRecords", new[] { "MeasurementToolId" });
            DropIndex("dbo.WSREComponentRecords", new[] { "RecommendationId" });
            DropIndex("dbo.WSREComponentRecords", new[] { "ComponentId" });
            DropIndex("dbo.WSREComponentRecords", new[] { "WSREId" });
            DropIndex("dbo.WSREComponentImages", new[] { "ComponentRecordId" });
            DropIndex("dbo.WSREs", new[] { "StatusId" });
            DropIndex("dbo.WSREs", new[] { "InspectorId" });
            DropIndex("dbo.WSREs", new[] { "JobsiteId" });
            DropIndex("dbo.WSREs", new[] { "SystemId" });
            DropTable("dbo.WSREInitialImageTypes");
            DropTable("dbo.WSREInitialImages");
            DropTable("dbo.WSREDipTestImages");
            DropTable("dbo.WSREDipTestConditions");
            DropTable("dbo.WSREDipTests");
            DropTable("dbo.WSRECrackTestImages");
            DropTable("dbo.WSRECrackTests");
            DropTable("dbo.WSREContacts");
            DropTable("dbo.WSREComponentRecommendations");
            DropTable("dbo.WSREComponentRecords");
            DropTable("dbo.WSREComponentImages");
            DropTable("dbo.WSREStatusTypes");
            DropTable("dbo.WSREs");
        }
    }
}
