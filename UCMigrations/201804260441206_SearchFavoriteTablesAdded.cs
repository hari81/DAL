namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SearchFavoriteTablesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SearchFavorite",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        BackgroundColor = c.String(maxLength: 20),
                        TextColor = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USER_TABLE", t => t.UserId, cascadeDelete: true)
                .Index(t => new { t.UserId, t.Name }, unique: true, name: "IX_UserIdName");
            
            CreateTable(
                "dbo.SearchFavoriteItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SearchFavoriteId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        SearchId = c.Int(nullable: false),
                        SearchStr = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SearchFavorite", t => t.SearchFavoriteId, cascadeDelete: true)
                .Index(t => t.SearchFavoriteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SearchFavorite", "UserId", "dbo.USER_TABLE");
            DropForeignKey("dbo.SearchFavoriteItems", "SearchFavoriteId", "dbo.SearchFavorite");
            DropIndex("dbo.SearchFavoriteItems", new[] { "SearchFavoriteId" });
            DropIndex("dbo.SearchFavorite", "IX_UserIdName");
            DropTable("dbo.SearchFavoriteItems");
            DropTable("dbo.SearchFavorite");
        }
    }
}
