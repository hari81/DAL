namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateScaleAndPrecisionForLengths : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GET_OBSERVATION_POINT_INSPECTION", "measurement", c => c.Decimal(nullable: false, precision: 16, scale: 3, storeType: "numeric"));
            AlterColumn("dbo.GET_COMPONENT_INSPECTION", "measurement", c => c.Decimal(nullable: false, precision: 16, scale: 3, storeType: "numeric"));
            AlterColumn("dbo.GET_COMPONENT", "initial_length", c => c.Decimal(precision: 16, scale: 3, storeType: "numeric"));
            AlterColumn("dbo.GET_COMPONENT", "worn_length", c => c.Decimal(precision: 16, scale: 3, storeType: "numeric"));
            AlterColumn("dbo.GET_OBSERVATION_POINTS", "initial_length", c => c.Decimal(precision: 16, scale: 3, storeType: "numeric"));
            AlterColumn("dbo.GET_OBSERVATION_POINTS", "worn_length", c => c.Decimal(precision: 16, scale: 3, storeType: "numeric"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GET_OBSERVATION_POINTS", "worn_length", c => c.Decimal(precision: 16, scale: 5, storeType: "numeric"));
            AlterColumn("dbo.GET_OBSERVATION_POINTS", "initial_length", c => c.Decimal(precision: 16, scale: 5, storeType: "numeric"));
            AlterColumn("dbo.GET_COMPONENT", "worn_length", c => c.Decimal(precision: 16, scale: 5, storeType: "numeric"));
            AlterColumn("dbo.GET_COMPONENT", "initial_length", c => c.Decimal(precision: 16, scale: 5, storeType: "numeric"));
            AlterColumn("dbo.GET_COMPONENT_INSPECTION", "measurement", c => c.Decimal(nullable: false, precision: 16, scale: 5, storeType: "numeric"));
            AlterColumn("dbo.GET_OBSERVATION_POINT_INSPECTION", "measurement", c => c.Decimal(nullable: false, precision: 16, scale: 5, storeType: "numeric"));
        }
    }
}
