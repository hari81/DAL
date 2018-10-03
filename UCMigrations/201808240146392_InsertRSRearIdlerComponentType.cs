namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertRSRearIdlerComponentType : DbMigration
    {
        public override void Up()
        {
            Sql(insertData1);
        }
        
        public override void Down()
        {
        }

        public const string insertData1 = @" 
SET IDENTITY_INSERT LU_COMPART_TYPE ON;

DECLARE @isExisting AS INT = 0;
SET @isExisting = (SELECT COUNT (*) FROM LU_COMPART_TYPE WHERE comparttype_auto = 446);

IF @isExisting = 0
	INSERT INTO LU_COMPART_TYPE (comparttype_auto, comparttypeid, comparttype, protected, modified_user_auto, modified_date, system_auto)
	VALUES(446, 'RearIdler', 'RS Rear Idler', 0, 1, '2018-08-24 11:14:37.620', 7);

SET IDENTITY_INSERT LU_COMPART_TYPE OFF;
";
    }
}
