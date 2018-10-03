namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ObservationNoteColumnAddedSpsUpdated : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.INSPECTION_COMPARTTYPE_RECORD", "ObservationNote", c => c.String());
        }
        
        public override void Down()
        {
            //DropColumn("dbo.INSPECTION_COMPARTTYPE_RECORD", "ObservationNote");
        }
    }
}
