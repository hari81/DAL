namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HowToUseImageAddedForMeasurementPointPossibleTools : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MEASUREMENT_POSSIBLE_TOOLS", "HowToUseImage", c => c.Binary());
            AddColumn("dbo.MEASUREMENT_POSSIBLE_TOOLS", "HowToUseText", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MEASUREMENT_POSSIBLE_TOOLS", "HowToUseText");
            DropColumn("dbo.MEASUREMENT_POSSIBLE_TOOLS", "HowToUseImage");
        }
    }
}
