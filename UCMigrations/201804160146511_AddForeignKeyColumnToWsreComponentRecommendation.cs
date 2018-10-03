namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyColumnToWsreComponentRecommendation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WSREComponentRecommendations", "ValidComponentTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.WSREComponentRecommendations", "ValidComponentTypeId");
            AddForeignKey("dbo.WSREComponentRecommendations", "ValidComponentTypeId", "dbo.LU_COMPART_TYPE", "comparttype_auto", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WSREComponentRecommendations", "ValidComponentTypeId", "dbo.LU_COMPART_TYPE");
            DropIndex("dbo.WSREComponentRecommendations", new[] { "ValidComponentTypeId" });
            DropColumn("dbo.WSREComponentRecommendations", "ValidComponentTypeId");
        }
    }
}
