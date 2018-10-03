namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComponentAndOPImages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GET_COMPONENT_INSPECTION_IMAGES",
                c => new
                    {
                        image_auto = c.Int(nullable: false, identity: true),
                        component_inspection_auto = c.Int(nullable: false),
                        component_photo = c.Binary(),
                    })
                .PrimaryKey(t => t.image_auto)
                .ForeignKey("dbo.GET_COMPONENT_INSPECTION", t => t.component_inspection_auto, cascadeDelete: true)
                .Index(t => t.component_inspection_auto);
            
            CreateTable(
                "dbo.GET_OBSERVATION_POINT_INSPECTION_IMAGES",
                c => new
                    {
                        image_auto = c.Int(nullable: false, identity: true),
                        observation_point_inspection_auto = c.Int(nullable: false),
                        observation_point_photo = c.Binary(),
                    })
                .PrimaryKey(t => t.image_auto)
                .ForeignKey("dbo.GET_OBSERVATION_POINT_INSPECTION", t => t.observation_point_inspection_auto, cascadeDelete: true)
                .Index(t => t.observation_point_inspection_auto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GET_OBSERVATION_POINT_INSPECTION_IMAGES", "observation_point_inspection_auto", "dbo.GET_OBSERVATION_POINT_INSPECTION");
            DropForeignKey("dbo.GET_COMPONENT_INSPECTION_IMAGES", "component_inspection_auto", "dbo.GET_COMPONENT_INSPECTION");
            DropIndex("dbo.GET_OBSERVATION_POINT_INSPECTION_IMAGES", new[] { "observation_point_inspection_auto" });
            DropIndex("dbo.GET_COMPONENT_INSPECTION_IMAGES", new[] { "component_inspection_auto" });
            DropTable("dbo.GET_OBSERVATION_POINT_INSPECTION_IMAGES");
            DropTable("dbo.GET_COMPONENT_INSPECTION_IMAGES");
        }
    }
}
