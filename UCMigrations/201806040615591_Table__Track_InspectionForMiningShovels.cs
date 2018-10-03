namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Table__Track_InspectionForMiningShovels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TRACK_INSPECTION", "TrammingHours", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TRACK_INSPECTION", "TrammingHours", c => c.Int(nullable: false));
        }
    }
}
