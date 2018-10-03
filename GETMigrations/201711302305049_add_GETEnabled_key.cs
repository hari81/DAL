namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_GETEnabled_key : DbMigration
    {
        public override void Up()
        {
            Sql(addKey1);
        }
        
        public override void Down()
        {
        }

        public const string addKey1 = @"
INSERT INTO [dbo].[APPLICATION_LU_CONFIG] ([variable_key], [value_key], [description])
VALUES	('GETEnabled', 0, 'This key is used to toggle GET on or off.');
";
    }
}
