namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TempImageTableForWSRE : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WSRE_TEMP_UPLOAD_IMAGE",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UploadInspectionId = c.Int(),
                        Title = c.String(),
                        Comment = c.String(),
                        FileName = c.String(),
                        Data = c.Binary(),
                        UploadDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WSRE_TEMP_UPLOAD_IMAGE");
        }
    }
}
