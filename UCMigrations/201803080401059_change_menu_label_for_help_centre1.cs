namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_menu_label_for_help_centre1 : DbMigration
    {
        public override void Up()
        {
            Sql(updateSql1);
        }
        
        public override void Down()
        {
        }

        public const string updateSql1 = @"
UPDATE MENU_L2
SET label = 'Help'
WHERE label = 'TrackTreads help Centre';
";
    }
}
