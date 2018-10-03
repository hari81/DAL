namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Table_GET_OBSERVATION_POINTS : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GET_OBSERVATION_POINTS", "observation_name", c => c.String(maxLength: 32));
            AlterColumn("dbo.GET_OBSERVATION_POINTS", "part_number", c => c.String(maxLength: 32));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GET_OBSERVATION_POINTS", "part_number", c => c.String());
            AlterColumn("dbo.GET_OBSERVATION_POINTS", "observation_name", c => c.String());
        }
    }
}
