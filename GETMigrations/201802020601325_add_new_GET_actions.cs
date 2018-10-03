namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_new_GET_actions : DbMigration
    {
        public override void Up()
        {
            Sql(insertQuery1);
        }
        
        public override void Down()
        {
        }

        public const string insertQuery1 = @"
SET IDENTITY_INSERT GET_ACTIONS ON;

INSERT INTO GET_ACTIONS (actions_auto, action_name)
VALUES (9, 'Move Implement to Inventory'), (10, 'Change Implement Status');

SET IDENTITY_INSERT GET_ACTIONS ON;
";
    }
}
