namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewEqSetupMenuItem : DbMigration
    {
        public override void Up()
        {
            Sql("update menu_l2 set targetpath = '/setup-equipment' where label = 'Setup New Equipment'");
        }
        
        public override void Down()
        {
        }
    }
}
