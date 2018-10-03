namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateVirtualReferenceToCustomerTableFromJobsite : DbMigration
    {
        public override void Up()
        {
            Sql(@"delete from CRSF where customer_auto not in (select distinct customer_auto from CUSTOMER)");
            CreateIndex("dbo.CRSF", "customer_auto");
            AddForeignKey("dbo.CRSF", "customer_auto", "dbo.CUSTOMER", "customer_auto", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CRSF", "customer_auto", "dbo.CUSTOMER");
            DropIndex("dbo.CRSF", new[] { "customer_auto" });
        }
    }
}
