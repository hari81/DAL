namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HelpCentreUrlAddedToTheBranding : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DealershipBranding", "HelpCentreUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DealershipBranding", "HelpCentreUrl");
        }
    }
}
