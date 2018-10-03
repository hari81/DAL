namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TT271AddPrimaryKeyTrackInspectionImages : DbMigration
    {
        public override void Up()
        {
            Sql(query);
        }
        
        public override void Down()
        {
        }

        string query = @"
DELETE TRACK_INSPECTION_IMAGES
WHERE ID = (SELECT MAX(ID) FROM TRACK_INSPECTION_IMAGES D2 
WHERE ID = D2.ID) 
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
WHERE CONSTRAINT_TYPE = 'PRIMARY KEY' AND TABLE_NAME = 'TRACK_INSPECTION_IMAGES' 
AND TABLE_SCHEMA ='dbo')
BEGIN
   ALTER TABLE TRACK_INSPECTION_IMAGES ADD CONSTRAINT pk_TrackInspectionImages PRIMARY KEY (ID)
END
";

    }
}
