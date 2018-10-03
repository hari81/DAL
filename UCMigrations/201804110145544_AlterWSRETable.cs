namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterWSRETable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WSREs", "CustomerReference", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WSREs", "CustomerReference");
        }
    }
}
