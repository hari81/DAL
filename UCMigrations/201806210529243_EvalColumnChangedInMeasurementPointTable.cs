namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EvalColumnChangedInMeasurementPointTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MEASUREMENT_POINT_RECORD", "EvalCode", c => c.String());
            DropColumn("dbo.MEASUREMENT_POINT_RECORD", "Eval");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MEASUREMENT_POINT_RECORD", "Eval", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.MEASUREMENT_POINT_RECORD", "EvalCode");
        }
    }
}
