namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShoeSizeTable : DbMigration
    {
        public override void Up()
        {
            /*Already added in UC Migrations
            CreateTable(
                "dbo.SHOE_SIZE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Size = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.GENERAL_EQ_UNIT", "ShoeSizeId", c => c.Int());
            CreateIndex("dbo.GENERAL_EQ_UNIT", "ShoeSizeId");
            AddForeignKey("dbo.GENERAL_EQ_UNIT", "ShoeSizeId", "dbo.SHOE_SIZE", "Id");
            */
        }

        public override void Down()
        {
            /*
            DropForeignKey("dbo.GENERAL_EQ_UNIT", "ShoeSizeId", "dbo.SHOE_SIZE");
            DropIndex("dbo.GENERAL_EQ_UNIT", new[] { "ShoeSizeId" });
            DropColumn("dbo.GENERAL_EQ_UNIT", "ShoeSizeId");
            DropTable("dbo.SHOE_SIZE");
            */
        }
    }
}
