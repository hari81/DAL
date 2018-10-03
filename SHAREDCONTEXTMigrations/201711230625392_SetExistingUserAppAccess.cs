namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetExistingUserAppAccess : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.USER_TABLE SET ApplicationAccess = 3 WHERE ApplicationAccess IS NULL");
        }
        
        public override void Down()
        {
        }
    }
}
