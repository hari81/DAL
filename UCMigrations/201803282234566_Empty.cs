namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Empty : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.APPLICATION_LU_CONFIG", "value_key", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.APPLICATION_LU_CONFIG", "value_key", c => c.String(nullable: false, maxLength: 1000, unicode: false));
        }
    }
}
