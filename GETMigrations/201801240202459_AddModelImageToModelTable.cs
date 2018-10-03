namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelImageToModelTable : DbMigration
    {
        public override void Up()
        {
            //Already executed in UC Context
            //AddColumn("dbo.MODEL", "ModelImage", c => c.Binary());
        }
        
        public override void Down()
        {
            //DropColumn("dbo.MODEL", "ModelImage");
        }
    }
}
