namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_GET_INVENTORY : DbMigration
    {
        public override void Up()
        {
            Sql(alterTable1);
        }
        
        public override void Down()
        {
        }

        public const string alterTable1 = @"
ALTER TABLE GET_INVENTORY
DROP COLUMN modified_user;

ALTER TABLE GET_INVENTORY
ADD modified_user INT NOT NULL;
";
    }
}
