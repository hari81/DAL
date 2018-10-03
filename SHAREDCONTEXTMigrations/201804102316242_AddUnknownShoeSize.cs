namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnknownShoeSize : DbMigration
    {
        public override void Up()
        {
            Sql(@"
SET IDENTITY_INSERT SHOE_SIZE ON
INSERT INTO SHOE_SIZE (Id, Title, Size) VALUES
(0,'Unknown',0)
SET IDENTITY_INSERT SHOE_SIZE OFF
");
        }
        
        public override void Down()
        {
        }
    }
}
