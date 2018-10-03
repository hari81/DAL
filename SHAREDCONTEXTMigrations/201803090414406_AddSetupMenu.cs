namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddSetupMenu : DbMigration
    {
        public override void Up()
        {
            /*Sql(@"
                INSERT INTO MENU_L2(menu_L1_auto, moduleid, label, targetpath, object_auto, sorder, active, tooltip, new_window) 
			                VALUES (2, 0, 'Setup Undercarriage', '/setup-undercarriage', 19, 8, 1, 'Setup Undercarriage', 0)

                INSERT INTO MENU_L3(menu_L2_auto, moduleid, label, targetpath, object_auto, sorder, active, tooltip, new_window) 
			                VALUES (42, 0, 'On Equipment', '/setup-undercarriage/on-equipment', 48, 1, 1, 'Setup Undercarriage on equipment', 0)

                INSERT INTO MENU_L3(menu_L2_auto, moduleid, label, targetpath, object_auto, sorder, active, tooltip, new_window) 
			                VALUES (42, 0, 'In Inventory', '/setup-undercarriage/in-inventory', 49, 2, 1, 'Setup Undercarriage in inventory', 0)");*/
        }

        public override void Down()
        {
        }
    }
}
