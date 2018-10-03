namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_new_GET_action : DbMigration
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
VALUES (12, 'Equipment SMU Changed');

SET IDENTITY_INSERT [dbo].[GET_ACTIONS] OFF;
";
    }
}
