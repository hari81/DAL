namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedMappingTableBetweenWSREComponentRecordsAndRecommendation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WSREComponentRecords", "RecommendationId", "dbo.WSREComponentRecommendations");
            DropIndex("dbo.WSREComponentRecords", new[] { "RecommendationId" });
            CreateTable(
                "dbo.WSREComponentRecordRecommendations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComponentRecordId = c.Int(nullable: false),
                        RecommendationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WSREComponentRecords", t => t.ComponentRecordId, cascadeDelete: true)
                .ForeignKey("dbo.WSREComponentRecommendations", t => t.RecommendationId, cascadeDelete: true)
                .Index(t => t.ComponentRecordId)
                .Index(t => t.RecommendationId);
            
            DropColumn("dbo.WSREComponentRecords", "RecommendationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WSREComponentRecords", "RecommendationId", c => c.Int());
            DropForeignKey("dbo.WSREComponentRecordRecommendations", "RecommendationId", "dbo.WSREComponentRecommendations");
            DropForeignKey("dbo.WSREComponentRecordRecommendations", "ComponentRecordId", "dbo.WSREComponentRecords");
            DropIndex("dbo.WSREComponentRecordRecommendations", new[] { "RecommendationId" });
            DropIndex("dbo.WSREComponentRecordRecommendations", new[] { "ComponentRecordId" });
            DropTable("dbo.WSREComponentRecordRecommendations");
            CreateIndex("dbo.WSREComponentRecords", "RecommendationId");
            AddForeignKey("dbo.WSREComponentRecords", "RecommendationId", "dbo.WSREComponentRecommendations", "Id");
        }
    }
}
