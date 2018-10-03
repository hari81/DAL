namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAcceptEvalAsReading : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.LU_COMPART", "AcceptEvalAsReading", c => c.Boolean(nullable: false));
            //AddColumn("dbo.TRACK_INSPECTION_DETAIL", "ReadingEnteredByEval", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.TRACK_INSPECTION_DETAIL", "ReadingEnteredByEval");
            //DropColumn("dbo.LU_COMPART", "AcceptEvalAsReading");
        }
    }
}
