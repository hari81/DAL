namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DASHBOARDSEARCHTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DASHBOARD_SEARCH",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ViewId = c.Int(nullable: false),
                        PageNo = c.Int(nullable: false),
                        PageSize = c.Int(nullable: false),
                        _clientReqId = c.Int(nullable: false),
                        memberName = c.String(),
                        sortName = c.String(),
                        ascendingOrder = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SEARCH_ITEM",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DashboradSearchId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Title = c.String(),
                        SearchId = c.Int(nullable: false),
                        SearchStr = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DASHBOARD_SEARCH", t => t.DashboradSearchId, cascadeDelete: true)
                .Index(t => t.DashboradSearchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SEARCH_ITEM", "DashboradSearchId", "dbo.DASHBOARD_SEARCH");
            DropIndex("dbo.SEARCH_ITEM", new[] { "DashboradSearchId" });
            DropTable("dbo.SEARCH_ITEM");
            DropTable("dbo.DASHBOARD_SEARCH");
        }
    }
}
