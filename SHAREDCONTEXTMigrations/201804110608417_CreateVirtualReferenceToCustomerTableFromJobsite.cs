namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateVirtualReferenceToCustomerTableFromJobsite : DbMigration
    {
        public override void Up()
        {
            //CreateIndex("dbo.CRSF", "customer_auto");
            //AddForeignKey("dbo.CRSF", "customer_auto", "dbo.CUSTOMER", "customer_auto", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.CRSF", "customer_auto", "dbo.CUSTOMER");
            //DropIndex("dbo.CRSF", new[] { "customer_auto" });
        }
    }
}
