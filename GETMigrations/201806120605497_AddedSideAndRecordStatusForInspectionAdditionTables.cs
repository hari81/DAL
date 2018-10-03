namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSideAndRecordStatusForInspectionAdditionTables : DbMigration
    {
        public override void Up()
        {
            /*
            AddColumn("dbo.INSPECTION_COMPARTTYPE_RECORD", "Side", c => c.Int(nullable: false));
            AddColumn("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", "RecordStatus", c => c.Int(nullable: false));
            */
        }
        
        public override void Down()
        {
            /*
            DropColumn("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", "RecordStatus");
            DropColumn("dbo.INSPECTION_COMPARTTYPE_RECORD", "Side");
            */
        }
    }
}
