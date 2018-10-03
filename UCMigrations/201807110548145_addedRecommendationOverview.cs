namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRecommendationOverview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MININGSHOVEL_REPORT_SUMMARY", "RecommendationOverview", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MININGSHOVEL_REPORT_SUMMARY", "RecommendationOverview");
        }
    }
}
