namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotesAddedToTheMEASUREMENTPOINTRECORD : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.MEASUREMENT_POINT_RECORD", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            //DropColumn("dbo.MEASUREMENT_POINT_RECORD", "Notes");
        }
    }
}
