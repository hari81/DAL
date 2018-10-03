namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTableRelationFixed : DbMigration
    {
        public override void Up()
        {/*
            DropIndex("dbo.USER_DEALERGROUP_RELATION", new[] { "USER_TABLE_user_auto1" });
            RenameColumn(table: "dbo.USER_DEALER_RELATION", name: "USER_TABLE_user_auto1", newName: "USER_TABLE_user_auto");
            CreateTable(
                "dbo.USER_DEALER_RELATION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DealerId = c.Int(nullable: false),
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
                .ForeignKey("dbo.Dealerships", t => t.DealerId, cascadeDelete: true)
                .ForeignKey("dbo.USER_TABLE", t => t.ModifiedByUserId)
                .ForeignKey("dbo.USER_TABLE", t => t.UserId, cascadeDelete: true)
                .Index(t => t.DealerId)
                .Index(t => t.UserId)
                .Index(t => t.AddedByUserId)
                .Index(t => t.ModifiedByUserId)
                .Index(t => t.USER_TABLE_user_auto);
            
            DropColumn("dbo.USER_DEALERGROUP_RELATION", "USER_TABLE_user_auto1");*/
        }
        
        public override void Down()
        {/*
            AddColumn("dbo.USER_DEALERGROUP_RELATION", "USER_TABLE_user_auto1", c => c.Long());
            DropForeignKey("dbo.USER_DEALER_RELATION", "UserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_DEALER_RELATION", "ModifiedByUserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.USER_DEALER_RELATION", "DealerId", "dbo.Dealerships");
            DropForeignKey("dbo.USER_DEALER_RELATION", "AddedByUserId", "dbo.USER_TABLE");
            DropIndex("dbo.USER_DEALER_RELATION", new[] { "USER_TABLE_user_auto" });
            DropIndex("dbo.USER_DEALER_RELATION", new[] { "ModifiedByUserId" });
            DropIndex("dbo.USER_DEALER_RELATION", new[] { "AddedByUserId" });
            DropIndex("dbo.USER_DEALER_RELATION", new[] { "UserId" });
            DropIndex("dbo.USER_DEALER_RELATION", new[] { "DealerId" });
            DropTable("dbo.USER_DEALER_RELATION");
            RenameColumn(table: "dbo.USER_DEALER_RELATION", name: "USER_TABLE_user_auto", newName: "USER_TABLE_user_auto1");
            CreateIndex("dbo.USER_DEALERGROUP_RELATION", "USER_TABLE_user_auto1");*/
        }
    }
}
