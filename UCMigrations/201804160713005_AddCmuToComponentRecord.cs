namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCmuToComponentRecord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WSREComponentRecords", "Cmu", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WSREComponentRecords", "Cmu");
        }
    }
}
