namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDefinitionForHiddenRecord2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", "MEASUREMENT_POINT_RECORD_Id", "dbo.MEASUREMENT_POINT_RECORD");
            DropIndex("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", new[] { "MEASUREMENT_POINT_RECORD_Id" });
            DropColumn("dbo.REPORT_HIDDEN_MEASUREMENT_POINT_RECORD", "MEASUREMENT_POINT_RECORD_Id");
        }
        
        public override void Down()
        {
        }
    }
}
