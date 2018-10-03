namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_GET_IMPLEMENT_IMAGE_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GET_IMPLEMENT_IMAGE",
                c => new
                    {
                        image_auto = c.Int(nullable: false, identity: true),
                        get_auto = c.Int(nullable: false),
                        attachment = c.Binary(),
                    })
                .PrimaryKey(t => t.image_auto)
                .ForeignKey("dbo.GET", t => t.get_auto, cascadeDelete: true)
                .Index(t => t.get_auto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GET_IMPLEMENT_IMAGE", "get_auto", "dbo.GET");
            DropIndex("dbo.GET_IMPLEMENT_IMAGE", new[] { "get_auto" });
            DropTable("dbo.GET_IMPLEMENT_IMAGE");
        }
    }
}
