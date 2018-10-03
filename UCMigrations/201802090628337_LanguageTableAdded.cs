namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LanguageTableAdded : DbMigration
    {
        public override void Up()
        {
            /*
            CreateTable(
                "dbo.LANGUAGE",
                c => new
                    {
                        language_auto = c.Byte(nullable: false, identity: true),
                        language = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.language_auto);
            
            CreateIndex("dbo.USER_TABLE", "language_auto");
            AddForeignKey("dbo.USER_TABLE", "language_auto", "dbo.LANGUAGE", "language_auto", cascadeDelete: true);
            */
        }

        public override void Down()
        {
            /*
            DropForeignKey("dbo.USER_TABLE", "language_auto", "dbo.LANGUAGE");
            DropIndex("dbo.USER_TABLE", new[] { "language_auto" });
            DropTable("dbo.LANGUAGE");
            */
        }
    }
}
