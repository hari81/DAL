namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedWSRELookupData : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO WSREStatusTypes VALUES ('New')");
            Sql(@"INSERT INTO WSREStatusTypes VALUES ('Sent')");
            Sql(@"INSERT INTO WSREInitialImageTypes VALUES ('Old Tag')");
            Sql(@"INSERT INTO WSREInitialImageTypes VALUES ('Customer Reference')");
            Sql(@"INSERT INTO WSREInitialImageTypes VALUES ('Arrival')");
            Sql(@"INSERT INTO WSREDipTestConditions VALUES ('Good')");
            Sql(@"INSERT INTO WSREDipTestConditions VALUES ('Dry')");
            Sql(@"INSERT INTO WSREDipTestConditions VALUES ('Contaminated')");
            Sql(@"INSERT INTO WSREDipTestConditions VALUES ('Pressurised')");
        }
        
        public override void Down()
        {
        }
    }
}
