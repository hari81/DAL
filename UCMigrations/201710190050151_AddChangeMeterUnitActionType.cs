namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChangeMeterUnitActionType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TRACK_ACTION_TYPE VALUES(40, 'Change Meter Unit', NULL)");
        }
        
        public override void Down()
        {
        }

    }
}
