namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNameToDealershipBranding : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DealershipBranding", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DealershipBranding", "Name");
        }
    }
}
