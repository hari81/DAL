namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerToObservations : DbMigration
    {
        public override void Up()
        {
            Sql(alterTable1);
        }
        
        public override void Down()
        {
        }

        public const string alterTable1 = @"
ALTER TABLE GET_OBSERVATION_LIST
ADD [customer_auto] BIGINT NULL;
";
    }
}
