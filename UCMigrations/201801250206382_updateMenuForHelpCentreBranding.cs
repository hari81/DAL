namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMenuForHelpCentreBranding : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                update MENU_L2 
                SET targetpath = '/HelpCentre/'
                where menu_L2_auto = 36

                update MENU_L2 
                SET targetpath = '/HelpCentre/Index/?LinkId=2'
                where menu_L2_auto = 37
                ");
        }
        
        public override void Down()
        {
        }
    }
}
