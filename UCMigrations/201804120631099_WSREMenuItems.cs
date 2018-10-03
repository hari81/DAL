namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WSREMenuItems : DbMigration
    {
        public override void Up()
        {
            Sql(@"insert into USER_OBJECT VALUES (58,'Repair Estimate', 'Repair-Estimate', 'page', null,null)");
            Sql(@"insert into USER_OBJECT VALUES (59,'Find Repair Estimate', 'Find Repair Estimate', 'page', null,null)");
            Sql(@"insert into MENU_L2 VALUES (2,0,'Find Repair Estimate','/find-repair-estimate',59,1,1,null,0)");
            Sql(@"insert into MENU_L3 VALUES (43,0,'Repair Estimate','/repair-estimate/:id',58,1,1,null,0)");
        }
        
        public override void Down()
        {
        }
    }
}
