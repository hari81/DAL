namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMenuUrl : DbMigration
    {
        public override void Up()
        {
            Sql("update menu_l2 set targetpath='/preferences' where menu_l2_auto=31");
        }
        
        public override void Down()
        {
        }
    }
}
