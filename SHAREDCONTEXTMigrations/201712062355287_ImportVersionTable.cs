namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImportVersionTable : DbMigration
    {
        public override void Up()
        {
            /*CreateTable(
                "dbo.VERSION",
                c => new
                    {
                        InstallDate = c.DateTime(nullable: false),
                        VersionNo = c.String(nullable: false, maxLength: 15, unicode: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 20, unicode: false),
                        Comment = c.String(maxLength: 1000, unicode: false),
                        dbVersion = c.String(maxLength: 50, unicode: false),
                        dbDate = c.DateTime(),
                        appDate = c.DateTime(),
                        MailService = c.String(maxLength: 10, unicode: false),
                        MailServiceDateUpdated = c.DateTime(),
                        PrintTool = c.String(maxLength: 10, unicode: false),
                        PrintToolDateUpdated = c.DateTime(),
                        IFTLab = c.String(maxLength: 10, unicode: false),
                        IFTLabDateUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.InstallDate, t.VersionNo, t.UpdatedBy });*/
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VERSION");
        }
    }
}
