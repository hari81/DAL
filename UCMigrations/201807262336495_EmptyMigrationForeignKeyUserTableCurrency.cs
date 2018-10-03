namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmptyMigrationForeignKeyUserTableCurrency : DbMigration
    {
        public override void Up()
        {
            //CreateIndex("dbo.USER_TABLE", "currency_auto");
            //AddForeignKey("dbo.USER_TABLE", "currency_auto", "dbo.CURRENCY", "currency_auto", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.USER_TABLE", "currency_auto", "dbo.CURRENCY");
            //DropIndex("dbo.USER_TABLE", new[] { "currency_auto" });
        }
    }
}
