namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccessManagementTablesAdded : DbMigration
    {
        public override void Up()
        {/*
            DropForeignKey("dbo.UserAccessMaps", "user_auto", "dbo.USER_TABLE");
            DropForeignKey("dbo.Dealerships", "Owner", "dbo.USER_TABLE");
            DropIndex("dbo.UserAccessMaps", new[] { "user_auto" });
            DropIndex("dbo.Dealerships", new[] { "Owner" });
            CreateTable(
                "dbo.DEALERGROUP_CUSTOMER_RELATION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DealerGroupId = c.Int(nullable: false),
                        CustomerId = c.Long(nullable: false),
                        AddedByUserId = c.Long(),
                        AddedDate = c.DateTime(),
                        ModifiedByUserId = c.Long(),
                        ModifiedDate = c.DateTime(),
                        RecordStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USER_TABLE", t => t.AddedByUserId)
                .ForeignKey("dbo.CUSTOMER", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.DEALER_GROUP", t => t.DealerGroupId, cascadeDelete: true)
                .ForeignKey("dbo.USER_TABLE", t => t.ModifiedByUserId)
                .Index(t => t.DealerGroupId)
                .Index(t => t.CustomerId)
                .Index(t => t.AddedByUserId)
                .Index(t => t.ModifiedByUserId);
            
            CreateTable(
                "dbo.USER_EQUIPMENT_RELATION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EquipmentId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        AddedByUserId = c.Long(),
                        AddedDate = c.DateTime(),
                        ModifiedByUserId = c.Long(),
                        ModifiedDate = c.DateTime(),
                        RecordStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USER_TABLE", t => t.AddedByUserId)
                .ForeignKey("dbo.EQUIPMENT", t => t.EquipmentId, cascadeDelete: true)
                .ForeignKey("dbo.USER_TABLE", t => t.ModifiedByUserId)
                .ForeignKey("dbo.USER_TABLE", t => t.UserId, cascadeDelete: true)
                .Index(t => t.EquipmentId)
                .Index(t => t.UserId)
                .Index(t => t.AddedByUserId)
                .Index(t => t.ModifiedByUserId);
            
            CreateTable(
                "dbo.USER_CUSTOMER_RELATION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        AddedByUserId = c.Long(),
                        AddedDate = c.DateTime(),
                        ModifiedByUserId = c.Long(),
                        ModifiedDate = c.DateTime(),
                        RecordStatus = c.Int(nullable: false),
                        USER_TABLE_user_auto = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USER_TABLE", t => t.AddedByUserId)
                .ForeignKey("dbo.CUSTOMER", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.USER_TABLE", t => t.ModifiedByUserId)
                .ForeignKey("dbo.USER_TABLE", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.USER_TABLE", t => t.USER_TABLE_user_auto)
                .Index(t => t.CustomerId)
                .Index(t => t.UserId)
                .Index(t => t.AddedByUserId)
                .Index(t => t.ModifiedByUserId)
                .Index(t => t.USER_TABLE_user_auto);
            
            CreateTable(
                "dbo.USER_DEALERGROUP_RELATION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DealerGroupId = c.Int(nullable: false),
                        UserId = c.Long(nullable: false),
                        AddedByUserId = c.Long(),
                        AddedDate = c.DateTime(),
                        ModifiedByUserId = c.Long(),
                        ModifiedDate = c.DateTime(),
                        RecordStatus = c.Int(nullable: false),
                        USER_TABLE_user_auto = c.Long(),
                        USER_TABLE_user_auto1 = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USER_TABLE", t => t.AddedByUserId)
                .ForeignKey("dbo.DEALER_GROUP", t => t.DealerGroupId, cascadeDelete: true)
                .ForeignKey("dbo.USER_TABLE", t => t.ModifiedByUserId)
                .ForeignKey("dbo.USER_TABLE", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.USER_TABLE", t => t.USER_TABLE_user_auto)
                .ForeignKey("dbo.USER_TABLE", t => t.USER_TABLE_user_auto1)
                .Index(t => t.DealerGroupId)
                .Index(t => t.UserId)
                .Index(t => t.AddedByUserId)
                .Index(t => t.ModifiedByUserId)
                .Index(t => t.USER_TABLE_user_auto)
                .Index(t => t.USER_TABLE_user_auto1);
            
            CreateTable(
                "dbo.DEALER_GROUP",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DEALERGROUP_DEALER_RELATION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DealerGroupId = c.Int(nullable: false),
                        DealerId = c.Int(nullable: false),
                        AddedByUserId = c.Long(),
                        AddedDate = c.DateTime(),
                        ModifiedByUserId = c.Long(),
                        ModifiedDate = c.DateTime(),
                        RecordStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USER_TABLE", t => t.AddedByUserId)
                .ForeignKey("dbo.Dealerships", t => t.DealerId, cascadeDelete: true)
                .ForeignKey("dbo.DEALER_GROUP", t => t.DealerGroupId, cascadeDelete: true)
                .ForeignKey("dbo.USER_TABLE", t => t.ModifiedByUserId)
                .Index(t => t.DealerGroupId)
                .Index(t => t.DealerId)
                .Index(t => t.AddedByUserId)
                .Index(t => t.ModifiedByUserId);
            
            CreateTable(
                "dbo.DEALER_CUSTOMER_RELATION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DealerId = c.Int(nullable: false),
                        CustomerId = c.Long(nullable: false),
                        AddedByUserId = c.Long(),
                        AddedDate = c.DateTime(),
                        ModifiedByUserId = c.Long(),
                        ModifiedDate = c.DateTime(),
                        RecordStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USER_TABLE", t => t.AddedByUserId)
                .ForeignKey("dbo.CUSTOMER", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Dealerships", t => t.DealerId, cascadeDelete: true)
                .ForeignKey("dbo.USER_TABLE", t => t.ModifiedByUserId)
                .Index(t => t.DealerId)
                .Index(t => t.CustomerId)
                .Index(t => t.AddedByUserId)
                .Index(t => t.ModifiedByUserId);
            
            CreateTable(
                "dbo.DEALER_JOBSITE_RELATION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DealerId = c.Int(nullable: false),
                        JobsiteId = c.Long(nullable: false),
                        AddedByUserId = c.Long(),
                        AddedDate = c.DateTime(),
                        ModifiedByUserId = c.Long(),
                        ModifiedDate = c.DateTime(),
                        RecordStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USER_TABLE", t => t.AddedByUserId)
                .ForeignKey("dbo.Dealerships", t => t.DealerId, cascadeDelete: true)
                .ForeignKey("dbo.CRSF", t => t.JobsiteId, cascadeDelete: true)
                .ForeignKey("dbo.USER_TABLE", t => t.ModifiedByUserId)
                .Index(t => t.DealerId)
                .Index(t => t.JobsiteId)
                .Index(t => t.AddedByUserId)
                .Index(t => t.ModifiedByUserId);
            
            CreateTable(
                "dbo.USER_SUPPORTTEAM_RELATION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupportTeamId = c.Int(nullable: false),
                        UserId = c.Long(nullable: false),
                        AddedByUserId = c.Long(),
                        AddedDate = c.DateTime(),
                        ModifiedByUserId = c.Long(),
                        ModifiedDate = c.DateTime(),
                        RecordStatus = c.Int(nullable: false),
                        Dealership_DealershipId = c.Int(),
                        USER_TABLE_user_auto = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USER_TABLE", t => t.AddedByUserId)
                .ForeignKey("dbo.USER_TABLE", t => t.ModifiedByUserId)
                .ForeignKey("dbo.SUPPORT_TEAM", t => t.SupportTeamId, cascadeDelete: true)
                .ForeignKey("dbo.USER_TABLE", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Dealerships", t => t.Dealership_DealershipId)
                .ForeignKey("dbo.USER_TABLE", t => t.USER_TABLE_user_auto)
                .Index(t => t.SupportTeamId)
                .Index(t => t.UserId)
                .Index(t => t.AddedByUserId)
                .Index(t => t.ModifiedByUserId)
                .Index(t => t.Dealership_DealershipId)
                .Index(t => t.USER_TABLE_user_auto);
            
            CreateTable(
                "dbo.SUPPORT_TEAM",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.USER_JOBSITE_RELATION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobsiteId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        AddedByUserId = c.Long(),
                        AddedDate = c.DateTime(),
                        ModifiedByUserId = c.Long(),
                        ModifiedDate = c.DateTime(),
                        RecordStatus = c.Int(nullable: false),
                        USER_TABLE_user_auto = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USER_TABLE", t => t.AddedByUserId)
                .ForeignKey("dbo.CRSF", t => t.JobsiteId, cascadeDelete: true)
                .ForeignKey("dbo.USER_TABLE", t => t.ModifiedByUserId)
                .ForeignKey("dbo.USER_TABLE", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.USER_TABLE", t => t.USER_TABLE_user_auto)
                .Index(t => t.JobsiteId)
                .Index(t => t.UserId)
                .Index(t => t.AddedByUserId)
                .Index(t => t.ModifiedByUserId)
                .Index(t => t.USER_TABLE_user_auto);
            
            AddColumn("dbo.Dealerships", "USER_TABLE_user_auto", c => c.Long());
            AddColumn("dbo.EQUIPMENT", "USER_TABLE_user_auto", c => c.Long());
            AlterColumn("dbo.UserAccessMaps", "user_auto", c => c.Long());
            CreateIndex("dbo.UserAccessMaps", "user_auto");
            CreateIndex("dbo.EQUIPMENT", "USER_TABLE_user_auto");
            CreateIndex("dbo.Dealerships", "USER_TABLE_user_auto");
            AddForeignKey("dbo.EQUIPMENT", "USER_TABLE_user_auto", "dbo.USER_TABLE", "user_auto");
            AddForeignKey("dbo.UserAccessMaps", "user_auto", "dbo.USER_TABLE", "user_auto");
            AddForeignKey("dbo.Dealerships", "USER_TABLE_user_auto", "dbo.USER_TABLE", "user_auto");
        */}
        
        public override void Down()
        {/*
            DropForeignKey("dbo.Dealerships", "USER_TABLE_user_auto", "dbo.USER_TABLE");
            DropForeignKey("dbo.UserAccessMaps", "user_auto", "dbo.USER_TABLE");
            DropForeignKey("dbo.DEALERGROUP_CUSTOMER_RELATION", "ModifiedByUserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.DEALERGROUP_CUSTOMER_RELATION", "DealerGroupId", "dbo.DEALER_GROUP");
            DropForeignKey("dbo.DEALERGROUP_CUSTOMER_RELATION", "CustomerId", "dbo.CUSTOMER");
            DropForeignKey("dbo.DEALERGROUP_CUSTOMER_RELATION", "AddedByUserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_SUPPORTTEAM_RELATION", "USER_TABLE_user_auto", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_JOBSITE_RELATION", "USER_TABLE_user_auto", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_JOBSITE_RELATION", "UserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_JOBSITE_RELATION", "ModifiedByUserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_JOBSITE_RELATION", "JobsiteId", "dbo.CRSF");
            DropForeignKey("dbo.USER_JOBSITE_RELATION", "AddedByUserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.EQUIPMENT", "USER_TABLE_user_auto", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_DEALERGROUP_RELATION", "USER_TABLE_user_auto1", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_DEALERGROUP_RELATION", "USER_TABLE_user_auto", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_DEALERGROUP_RELATION", "UserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_DEALERGROUP_RELATION", "ModifiedByUserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_DEALERGROUP_RELATION", "DealerGroupId", "dbo.DEALER_GROUP");
            DropForeignKey("dbo.DEALERGROUP_DEALER_RELATION", "ModifiedByUserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.DEALERGROUP_DEALER_RELATION", "DealerGroupId", "dbo.DEALER_GROUP");
            DropForeignKey("dbo.DEALERGROUP_DEALER_RELATION", "DealerId", "dbo.Dealerships");
            DropForeignKey("dbo.USER_SUPPORTTEAM_RELATION", "Dealership_DealershipId", "dbo.Dealerships");
            DropForeignKey("dbo.USER_SUPPORTTEAM_RELATION", "UserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_SUPPORTTEAM_RELATION", "SupportTeamId", "dbo.SUPPORT_TEAM");
            DropForeignKey("dbo.USER_SUPPORTTEAM_RELATION", "ModifiedByUserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_SUPPORTTEAM_RELATION", "AddedByUserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.DEALER_JOBSITE_RELATION", "ModifiedByUserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.DEALER_JOBSITE_RELATION", "JobsiteId", "dbo.CRSF");
            DropForeignKey("dbo.DEALER_JOBSITE_RELATION", "DealerId", "dbo.Dealerships");
            DropForeignKey("dbo.DEALER_JOBSITE_RELATION", "AddedByUserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.DEALER_CUSTOMER_RELATION", "ModifiedByUserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.DEALER_CUSTOMER_RELATION", "DealerId", "dbo.Dealerships");
            DropForeignKey("dbo.DEALER_CUSTOMER_RELATION", "CustomerId", "dbo.CUSTOMER");
            DropForeignKey("dbo.DEALER_CUSTOMER_RELATION", "AddedByUserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.DEALERGROUP_DEALER_RELATION", "AddedByUserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_DEALERGROUP_RELATION", "AddedByUserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_CUSTOMER_RELATION", "USER_TABLE_user_auto", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_CUSTOMER_RELATION", "UserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_CUSTOMER_RELATION", "ModifiedByUserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_CUSTOMER_RELATION", "CustomerId", "dbo.CUSTOMER");
            DropForeignKey("dbo.USER_CUSTOMER_RELATION", "AddedByUserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_EQUIPMENT_RELATION", "UserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_EQUIPMENT_RELATION", "ModifiedByUserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_EQUIPMENT_RELATION", "EquipmentId", "dbo.EQUIPMENT");
            DropForeignKey("dbo.USER_EQUIPMENT_RELATION", "AddedByUserId", "dbo.USER_TABLE");
            DropIndex("dbo.USER_JOBSITE_RELATION", new[] { "USER_TABLE_user_auto" });
            DropIndex("dbo.USER_JOBSITE_RELATION", new[] { "ModifiedByUserId" });
            DropIndex("dbo.USER_JOBSITE_RELATION", new[] { "AddedByUserId" });
            DropIndex("dbo.USER_JOBSITE_RELATION", new[] { "UserId" });
            DropIndex("dbo.USER_JOBSITE_RELATION", new[] { "JobsiteId" });
            DropIndex("dbo.USER_SUPPORTTEAM_RELATION", new[] { "USER_TABLE_user_auto" });
            DropIndex("dbo.USER_SUPPORTTEAM_RELATION", new[] { "Dealership_DealershipId" });
            DropIndex("dbo.USER_SUPPORTTEAM_RELATION", new[] { "ModifiedByUserId" });
            DropIndex("dbo.USER_SUPPORTTEAM_RELATION", new[] { "AddedByUserId" });
            DropIndex("dbo.USER_SUPPORTTEAM_RELATION", new[] { "UserId" });
            DropIndex("dbo.USER_SUPPORTTEAM_RELATION", new[] { "SupportTeamId" });
            DropIndex("dbo.DEALER_JOBSITE_RELATION", new[] { "ModifiedByUserId" });
            DropIndex("dbo.DEALER_JOBSITE_RELATION", new[] { "AddedByUserId" });
            DropIndex("dbo.DEALER_JOBSITE_RELATION", new[] { "JobsiteId" });
            DropIndex("dbo.DEALER_JOBSITE_RELATION", new[] { "DealerId" });
            DropIndex("dbo.DEALER_CUSTOMER_RELATION", new[] { "ModifiedByUserId" });
            DropIndex("dbo.DEALER_CUSTOMER_RELATION", new[] { "AddedByUserId" });
            DropIndex("dbo.DEALER_CUSTOMER_RELATION", new[] { "CustomerId" });
            DropIndex("dbo.DEALER_CUSTOMER_RELATION", new[] { "DealerId" });
            DropIndex("dbo.Dealerships", new[] { "USER_TABLE_user_auto" });
            DropIndex("dbo.DEALERGROUP_DEALER_RELATION", new[] { "ModifiedByUserId" });
            DropIndex("dbo.DEALERGROUP_DEALER_RELATION", new[] { "AddedByUserId" });
            DropIndex("dbo.DEALERGROUP_DEALER_RELATION", new[] { "DealerId" });
            DropIndex("dbo.DEALERGROUP_DEALER_RELATION", new[] { "DealerGroupId" });
            DropIndex("dbo.USER_DEALERGROUP_RELATION", new[] { "USER_TABLE_user_auto1" });
            DropIndex("dbo.USER_DEALERGROUP_RELATION", new[] { "USER_TABLE_user_auto" });
            DropIndex("dbo.USER_DEALERGROUP_RELATION", new[] { "ModifiedByUserId" });
            DropIndex("dbo.USER_DEALERGROUP_RELATION", new[] { "AddedByUserId" });
            DropIndex("dbo.USER_DEALERGROUP_RELATION", new[] { "UserId" });
            DropIndex("dbo.USER_DEALERGROUP_RELATION", new[] { "DealerGroupId" });
            DropIndex("dbo.USER_CUSTOMER_RELATION", new[] { "USER_TABLE_user_auto" });
            DropIndex("dbo.USER_CUSTOMER_RELATION", new[] { "ModifiedByUserId" });
            DropIndex("dbo.USER_CUSTOMER_RELATION", new[] { "AddedByUserId" });
            DropIndex("dbo.USER_CUSTOMER_RELATION", new[] { "UserId" });
            DropIndex("dbo.USER_CUSTOMER_RELATION", new[] { "CustomerId" });
            DropIndex("dbo.USER_EQUIPMENT_RELATION", new[] { "ModifiedByUserId" });
            DropIndex("dbo.USER_EQUIPMENT_RELATION", new[] { "AddedByUserId" });
            DropIndex("dbo.USER_EQUIPMENT_RELATION", new[] { "UserId" });
            DropIndex("dbo.USER_EQUIPMENT_RELATION", new[] { "EquipmentId" });
            DropIndex("dbo.EQUIPMENT", new[] { "USER_TABLE_user_auto" });
            DropIndex("dbo.DEALERGROUP_CUSTOMER_RELATION", new[] { "ModifiedByUserId" });
            DropIndex("dbo.DEALERGROUP_CUSTOMER_RELATION", new[] { "AddedByUserId" });
            DropIndex("dbo.DEALERGROUP_CUSTOMER_RELATION", new[] { "CustomerId" });
            DropIndex("dbo.DEALERGROUP_CUSTOMER_RELATION", new[] { "DealerGroupId" });
            DropIndex("dbo.UserAccessMaps", new[] { "user_auto" });
            AlterColumn("dbo.UserAccessMaps", "user_auto", c => c.Long(nullable: false));
            DropColumn("dbo.EQUIPMENT", "USER_TABLE_user_auto");
            DropColumn("dbo.Dealerships", "USER_TABLE_user_auto");
            DropTable("dbo.USER_JOBSITE_RELATION");
            DropTable("dbo.SUPPORT_TEAM");
            DropTable("dbo.USER_SUPPORTTEAM_RELATION");
            DropTable("dbo.DEALER_JOBSITE_RELATION");
            DropTable("dbo.DEALER_CUSTOMER_RELATION");
            DropTable("dbo.DEALERGROUP_DEALER_RELATION");
            DropTable("dbo.DEALER_GROUP");
            DropTable("dbo.USER_DEALERGROUP_RELATION");
            DropTable("dbo.USER_CUSTOMER_RELATION");
            DropTable("dbo.USER_EQUIPMENT_RELATION");
            DropTable("dbo.DEALERGROUP_CUSTOMER_RELATION");
            CreateIndex("dbo.Dealerships", "Owner");
            CreateIndex("dbo.UserAccessMaps", "user_auto");
            AddForeignKey("dbo.Dealerships", "Owner", "dbo.USER_TABLE", "user_auto", cascadeDelete: true);
            AddForeignKey("dbo.UserAccessMaps", "user_auto", "dbo.USER_TABLE", "user_auto", cascadeDelete: true);
        */}
    }
}
