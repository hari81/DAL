namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_GET_EVENT_types : DbMigration
    {
        public override void Up()
        {
            Sql(insertData1);
        }
        
        public override void Down()
        {
        }

        public const string insertData1 = @"
SET IDENTITY_INSERT [dbo].[GET_ACTIONS] ON;

INSERT INTO GET_ACTIONS (actions_auto, action_name)
VALUES  (7, 'Change Implement Jobsite'),
        (8, 'Attach Implement to Equipment');

SET IDENTITY_INSERT [dbo].[GET_ACTIONS] OFF;
";
    }
}
