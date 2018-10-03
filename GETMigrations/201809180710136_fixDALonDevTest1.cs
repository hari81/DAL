namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixDALonDevTest1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GET_COMPONENT", "make_auto", "dbo.MAKE");
            DropIndex("dbo.GET_COMPONENT", new[] { "make_auto" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.GET_COMPONENT", "make_auto");
            AddForeignKey("dbo.GET_COMPONENT", "make_auto", "dbo.MAKE", "make_auto");
        }
    }
}
