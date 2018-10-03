namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OEMColumnAddedTotheMakeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MAKE", "OEM", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MAKE", "OEM");
        }
    }
}
