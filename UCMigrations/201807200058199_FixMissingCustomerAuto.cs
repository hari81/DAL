namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixMissingCustomerAuto : DbMigration
    {
        public override void Up()
        {
            // GET-95: Column already exists but wasn't in DAL
            //AddColumn("dbo.GET_OBSERVATION_LIST", "customer_auto", c => c.Long());
        }

        public override void Down()
        {
            //DropColumn("dbo.GET_OBSERVATION_LIST", "customer_auto");
        }
    }
}
