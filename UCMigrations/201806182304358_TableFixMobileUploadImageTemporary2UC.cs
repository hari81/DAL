namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableFixMobileUploadImageTemporary2UC : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TEMP_UPLOAD_IMAGE", "UploadInspectionId", c => c.Int());
            AlterColumn("dbo.TEMP_UPLOAD_IMAGE", "UploadDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TEMP_UPLOAD_IMAGE", "UploadDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TEMP_UPLOAD_IMAGE", "UploadInspectionId", c => c.Int(nullable: false));
        }
    }
}
