namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterQuoteTables : DbMigration
    {
        public override void Up()
        {
            Sql("delete from TRACK_QUOTE_DETAIL where quote_auto not in (select quote_auto from TRACK_QUOTE)");
            AddColumn("dbo.TRACK_QUOTE_DETAIL", "Comment", c => c.String());
            CreateIndex("dbo.TRACK_QUOTE", "inspection_auto");
            CreateIndex("dbo.TRACK_QUOTE_DETAIL", "quote_auto");
            AddForeignKey("dbo.TRACK_QUOTE", "inspection_auto", "dbo.TRACK_INSPECTION", "inspection_auto", cascadeDelete: false);
            AddForeignKey("dbo.TRACK_QUOTE_DETAIL", "quote_auto", "dbo.TRACK_QUOTE", "quote_auto", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TRACK_QUOTE_DETAIL", "quote_auto", "dbo.TRACK_QUOTE");
            DropForeignKey("dbo.TRACK_QUOTE", "inspection_auto", "dbo.TRACK_INSPECTION");
            DropIndex("dbo.TRACK_QUOTE_DETAIL", new[] { "quote_auto" });
            DropIndex("dbo.TRACK_QUOTE", new[] { "inspection_auto" });
            DropColumn("dbo.TRACK_QUOTE_DETAIL", "Comment");
        }
    }
}
