namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableForMobileUploadImageTemporaryUC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TEMP_UPLOAD_IMAGE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UploadInspectionId = c.Int(nullable: false),
                        Title = c.String(),
                        Comment = c.String(),
                        FileName = c.String(),
                        Data = c.Binary(),
                        upload_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TEMP_UPLOAD_IMAGE");
        }
    }
}
