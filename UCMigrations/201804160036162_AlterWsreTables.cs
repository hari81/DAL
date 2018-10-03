namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterWsreTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WSREs", "OverallEval", c => c.String());
            AddColumn("dbo.WSREComponentRecords", "WornPercentage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WSREComponentRecords", "WornPercentage");
            DropColumn("dbo.WSREs", "OverallEval");
        }
    }
}
