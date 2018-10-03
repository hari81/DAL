namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelImageToModelTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MODEL", "ModelImage", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MODEL", "ModelImage");
        }
    }
}
