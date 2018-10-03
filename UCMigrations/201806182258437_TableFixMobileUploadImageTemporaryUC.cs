namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableFixMobileUploadImageTemporaryUC : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TEMP_UPLOAD_IMAGE", "UploadDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.TEMP_UPLOAD_IMAGE", "upload_date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TEMP_UPLOAD_IMAGE", "upload_date", c => c.DateTime(nullable: false));
            DropColumn("dbo.TEMP_UPLOAD_IMAGE", "UploadDate");
        }
    }
}
