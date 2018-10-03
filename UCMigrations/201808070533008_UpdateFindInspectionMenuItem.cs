namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFindInspectionMenuItem : DbMigration
    {
        public override void Up()
        {
            Sql("update menu_l2 set targetpath='/inspection' where menu_L2_auto=2");
        }
        
        public override void Down()
        {
        }
    }
}
