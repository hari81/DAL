namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Observation_point_tables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GET_OBSERVATION_POINT_IMAGES", "GET_OBSERVATION_POINT_RESULTS_observation_point_results_auto", "dbo.GET_OBSERVATION_POINT_RESULTS");
            DropIndex("dbo.GET_OBSERVATION_POINT_IMAGES", new[] { "GET_OBSERVATION_POINT_RESULTS_observation_point_results_auto" });
            DropColumn("dbo.GET_OBSERVATION_POINT_IMAGES", "results_auto");
            RenameColumn(table: "dbo.GET_OBSERVATION_POINT_IMAGES", name: "GET_OBSERVATION_POINT_RESULTS_observation_point_results_auto", newName: "results_auto");
            DropPrimaryKey("dbo.GET_OBSERVATION_POINT_RESULTS");
            DropPrimaryKey("dbo.GET_OBSERVATION_POINT_INSPECTION");
            DropPrimaryKey("dbo.GET_OBSERVATION_POINTS");
            AlterColumn("dbo.GET_OBSERVATION_POINT_IMAGES", "results_auto", c => c.Int(nullable: false));
            AlterColumn("dbo.GET_OBSERVATION_POINT_RESULTS", "observation_point_results_auto", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.GET_OBSERVATION_POINT_RESULTS", "observation_point_inspection_auto", c => c.Int(nullable: false));
            AlterColumn("dbo.GET_OBSERVATION_POINT_INSPECTION", "observation_point_inspection_auto", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.GET_OBSERVATION_POINT_INSPECTION", "observation_point_auto", c => c.Int(nullable: false));
            AlterColumn("dbo.GET_OBSERVATION_POINTS", "observation_point_auto", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.GET_OBSERVATION_POINT_RESULTS", "observation_point_results_auto");
            AddPrimaryKey("dbo.GET_OBSERVATION_POINT_INSPECTION", "observation_point_inspection_auto");
            AddPrimaryKey("dbo.GET_OBSERVATION_POINTS", "observation_point_auto");
            CreateIndex("dbo.GET_OBSERVATION_POINT_IMAGES", "results_auto");
            AddForeignKey("dbo.GET_OBSERVATION_POINT_IMAGES", "results_auto", "dbo.GET_OBSERVATION_POINT_RESULTS", "observation_point_results_auto", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GET_OBSERVATION_POINT_IMAGES", "results_auto", "dbo.GET_OBSERVATION_POINT_RESULTS");
            DropIndex("dbo.GET_OBSERVATION_POINT_IMAGES", new[] { "results_auto" });
            DropPrimaryKey("dbo.GET_OBSERVATION_POINTS");
            DropPrimaryKey("dbo.GET_OBSERVATION_POINT_INSPECTION");
            DropPrimaryKey("dbo.GET_OBSERVATION_POINT_RESULTS");
            AlterColumn("dbo.GET_OBSERVATION_POINTS", "observation_point_auto", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.GET_OBSERVATION_POINT_INSPECTION", "observation_point_auto", c => c.Long(nullable: false));
            AlterColumn("dbo.GET_OBSERVATION_POINT_INSPECTION", "observation_point_inspection_auto", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.GET_OBSERVATION_POINT_RESULTS", "observation_point_inspection_auto", c => c.Long(nullable: false));
            AlterColumn("dbo.GET_OBSERVATION_POINT_RESULTS", "observation_point_results_auto", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.GET_OBSERVATION_POINT_IMAGES", "results_auto", c => c.Long());
            AddPrimaryKey("dbo.GET_OBSERVATION_POINTS", "observation_point_auto");
            AddPrimaryKey("dbo.GET_OBSERVATION_POINT_INSPECTION", "observation_point_inspection_auto");
            AddPrimaryKey("dbo.GET_OBSERVATION_POINT_RESULTS", "observation_point_results_auto");
            RenameColumn(table: "dbo.GET_OBSERVATION_POINT_IMAGES", name: "results_auto", newName: "GET_OBSERVATION_POINT_RESULTS_observation_point_results_auto");
            AddColumn("dbo.GET_OBSERVATION_POINT_IMAGES", "results_auto", c => c.Int(nullable: false));
            CreateIndex("dbo.GET_OBSERVATION_POINT_IMAGES", "GET_OBSERVATION_POINT_RESULTS_observation_point_results_auto");
            AddForeignKey("dbo.GET_OBSERVATION_POINT_IMAGES", "GET_OBSERVATION_POINT_RESULTS_observation_point_results_auto", "dbo.GET_OBSERVATION_POINT_RESULTS", "observation_point_results_auto");
        }
    }
}
