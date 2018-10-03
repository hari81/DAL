namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImportGET_IMPLEMENT_COMPARTTYPETable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LU_IMPLEMENT", "CustomerId", c => c.Long());
            CreateIndex("dbo.LU_IMPLEMENT", "CustomerId");
            AddForeignKey("dbo.LU_IMPLEMENT", "CustomerId", "dbo.CUSTOMER", "customer_auto");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LU_IMPLEMENT", "CustomerId", "dbo.CUSTOMER");
            DropIndex("dbo.LU_IMPLEMENT", new[] { "CustomerId" });
            DropColumn("dbo.LU_IMPLEMENT", "CustomerId");
        }
    }
}
