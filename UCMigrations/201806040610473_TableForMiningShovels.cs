namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableForMiningShovels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrackInspectionImageTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.TRACK_INSPECTION", "CustomerContact", c => c.String(maxLength: 500));
            AddColumn("dbo.TRACK_INSPECTION", "TrammingHours", c => c.Int(nullable: false));
            AddColumn("dbo.TRACK_INSPECTION", "GeneralNotes", c => c.String(maxLength: 1000));
            AddColumn("dbo.TrackInspectionImagesMains", "ImageType", c => c.Int(nullable: false));
            CreateIndex("dbo.TrackInspectionImagesMains", "ImageType");
            AddForeignKey("dbo.TrackInspectionImagesMains", "ImageType", "dbo.TrackInspectionImageTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrackInspectionImagesMains", "ImageType", "dbo.TrackInspectionImageTypes");
            DropIndex("dbo.TrackInspectionImagesMains", new[] { "ImageType" });
            DropColumn("dbo.TrackInspectionImagesMains", "ImageType");
            DropColumn("dbo.TRACK_INSPECTION", "GeneralNotes");
            DropColumn("dbo.TRACK_INSPECTION", "TrammingHours");
            DropColumn("dbo.TRACK_INSPECTION", "CustomerContact");
            DropTable("dbo.TrackInspectionImageTypes");
        }
    }
}
