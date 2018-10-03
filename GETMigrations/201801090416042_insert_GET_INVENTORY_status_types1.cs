namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insert_GET_INVENTORY_status_types1 : DbMigration
    {
        public override void Up()
        {
            Sql(insertData1);
        }
        
        public override void Down()
        {
        }

        public const string insertData1 = @"
SET IDENTITY_INSERT [dbo].[GET_INVENTORY_STATUS] ON;

DELETE FROM [dbo].[GET_INVENTORY_STATUS];

INSERT INTO [dbo].[GET_INVENTORY_STATUS] (status_auto, status_desc)
VALUES	(1, 'On Equipment'),
        (2, 'Awaiting Repair'),
		(3, 'Undergoing Repair'),
		(4, 'Ready for Use'),
		(5, 'Scrapped');

SET IDENTITY_INSERT [dbo].[GET_INVENTORY_STATUS] OFF;
";
    }
}
