namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_repairer_workshop1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.GET_REPAIRER", name: "customer", newName: "customer_auto");
            RenameColumn(table: "dbo.GET_WORKSHOP", name: "repairer", newName: "repairer_auto");
            RenameIndex(table: "dbo.GET_REPAIRER", name: "IX_customer", newName: "IX_customer_auto");
            RenameIndex(table: "dbo.GET_WORKSHOP", name: "IX_repairer", newName: "IX_repairer_auto");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.GET_WORKSHOP", name: "IX_repairer_auto", newName: "IX_repairer");
            RenameIndex(table: "dbo.GET_REPAIRER", name: "IX_customer_auto", newName: "IX_customer");
            RenameColumn(table: "dbo.GET_WORKSHOP", name: "repairer_auto", newName: "repairer");
            RenameColumn(table: "dbo.GET_REPAIRER", name: "customer_auto", newName: "customer");
        }
    }
}
