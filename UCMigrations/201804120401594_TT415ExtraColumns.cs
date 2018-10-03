namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TT415ExtraColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WSREComponentImages", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.WSRECrackTestImages", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.WSREDipTestConditions", "Colour", c => c.String());
            AddColumn("dbo.WSREDipTestImages", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.WSREInitialImages", "Deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WSREInitialImages", "Deleted");
            DropColumn("dbo.WSREDipTestImages", "Deleted");
            DropColumn("dbo.WSREDipTestConditions", "Colour");
            DropColumn("dbo.WSRECrackTestImages", "Deleted");
            DropColumn("dbo.WSREComponentImages", "Deleted");
        }
    }
}
