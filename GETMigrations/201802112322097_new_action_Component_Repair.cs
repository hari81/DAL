namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_action_Component_Repair : DbMigration
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

INSERT INTO GET_ACTIONS (actions_auto, action_name)
VALUES (11, 'Component Repair');

SET IDENTITY_INSERT [dbo].[GET_ACTIONS] OFF;
";
    }
}
