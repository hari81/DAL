namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnableGETToBeSetupInInventory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GET", "equipmentid_auto", e => e.Long(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GET", "equipmentid_auto", e => e.Long());
        }
    }
}
