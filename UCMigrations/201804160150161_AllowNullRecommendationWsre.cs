namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowNullRecommendationWsre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WSREComponentRecords", "RecommendationId", "dbo.WSREComponentRecommendations");
            DropIndex("dbo.WSREComponentRecords", new[] { "RecommendationId" });
            AlterColumn("dbo.WSREComponentRecords", "RecommendationId", c => c.Int());
            CreateIndex("dbo.WSREComponentRecords", "RecommendationId");
            AddForeignKey("dbo.WSREComponentRecords", "RecommendationId", "dbo.WSREComponentRecommendations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WSREComponentRecords", "RecommendationId", "dbo.WSREComponentRecommendations");
            DropIndex("dbo.WSREComponentRecords", new[] { "RecommendationId" });
            AlterColumn("dbo.WSREComponentRecords", "RecommendationId", c => c.Int(nullable: false));
            CreateIndex("dbo.WSREComponentRecords", "RecommendationId");
            AddForeignKey("dbo.WSREComponentRecords", "RecommendationId", "dbo.WSREComponentRecommendations", "Id", cascadeDelete: true);
        }
    }
}
