namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNewChainOrFrameFromMenu : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE MENU_L2 WHERE menu_L2_auto = 17 AND targetpath = 'track/tracksetup.aspx'");
        }
        
        public override void Down()
        {
        }
    }
}
