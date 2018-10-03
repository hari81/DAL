namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTableApplicationAccessColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.USER_TABLE", "ApplicationAccess", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.USER_TABLE", "ApplicationAccess");
        }
    }
}
