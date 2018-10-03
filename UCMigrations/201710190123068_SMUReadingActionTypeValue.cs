namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMUReadingActionTypeValue : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TRACK_ACTION_TYPE VALUES(41, 'SMU Reading Action', NULL)");
        }
        
        public override void Down()
        {
        }
    }
}
