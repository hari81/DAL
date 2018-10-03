namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGETUrlMenuItem : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO USER_OBJECT (object_auto ,object_name ,actual_name	, object_type, webformname , comment) VALUES (64,'Switch App', 'Switch App', 'page', null, null)");
            Sql("INSERT INTO MENU_L2(menu_L1_auto , moduleid	, label , targetpath , object_auto, sorder , active, tooltip, new_window) VALUES (7, 0, 'Switch App', 'http://get.tracktreads.local',64,2,1,null,1)");
            Sql("UPDATE MENU_L2 set sorder =3 where menu_L2_auto = 32");

        }
        
        public override void Down()
        {
        }
    }
}
