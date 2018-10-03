namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makeLengthsDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GET_COMPONENT", "initial_length", c => c.Decimal(precision: 16, scale: 5, storeType: "numeric"));
            AlterColumn("dbo.GET_COMPONENT", "worn_length", c => c.Decimal(precision: 16, scale: 5, storeType: "numeric"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GET_COMPONENT", "worn_length", c => c.Int());
            AlterColumn("dbo.GET_COMPONENT", "initial_length", c => c.Int());
        }
    }
}
