namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixMissingRecordStatusColumn : DbMigration
    {
        public override void Up()
        {
            Sql(addColumnQuery);
        }
        
        public override void Down()
        {
        }

        public const string addColumnQuery = @"
  ALTER TABLE [GET_EVENTS_COMPONENT] ADD recordStatus INT NOT NULL DEFAULT(0);
";
    }
}
