namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLinksInChainForModel : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.MODEL", "LinksInChain", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.MODEL", "LinksInChain");
        }
    }
}
