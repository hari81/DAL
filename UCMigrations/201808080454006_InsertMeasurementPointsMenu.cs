namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertMeasurementPointsMenu : DbMigration
    {
        public override void Up()
        {
            Sql(@"insert into USER_OBJECT VALUES (63,'Measurement Points', 'Measurement Points', 'page', null,null)");
            Sql(@"insert into MENU_L3 VALUES (27,0,'Measurement Points','/measurement-points',63,5,1,null,0)");


        }
        
        public override void Down()
        {
        }
    }
}
