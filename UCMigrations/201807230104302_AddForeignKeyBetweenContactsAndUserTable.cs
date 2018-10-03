namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyBetweenContactsAndUserTable : DbMigration
    {
        public override void Up()
        {
            Sql("delete from CONTACTS where user_auto not in (select user_auto from USER_TABLE)");
            CreateIndex("dbo.CONTACTS", "user_auto");
            AddForeignKey("dbo.CONTACTS", "user_auto", "dbo.USER_TABLE", "user_auto", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CONTACTS", "user_auto", "dbo.USER_TABLE");
            DropIndex("dbo.CONTACTS", new[] { "user_auto" });
        }
    }
}
