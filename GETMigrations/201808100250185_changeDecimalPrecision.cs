namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDecimalPrecision : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GET_OBSERVATION_POINT_INSPECTION", "measurement", c => c.Decimal(nullable: false, precision: 16, scale: 5, storeType: "numeric"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GET_OBSERVATION_POINT_INSPECTION", "measurement", c => c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"));
        }
    }
}
