namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Implement_Updated_action : DbMigration
    {
        public override void Up()
        {
            Sql(insertSql1);
        }
        
        public override void Down()
        {
        }

        public const string insertSql1 = @"
SET IDENTITY_INSERT [dbo].[GET_ACTIONS] ON;
INSERT INTO [dbo].[GET_ACTIONS] (actions_auto, action_name)
VALUES (13, 'Implement Updated');
SET IDENTITY_INSERT [dbo].[GET_ACTIONS] OFF;
";
    }
}
