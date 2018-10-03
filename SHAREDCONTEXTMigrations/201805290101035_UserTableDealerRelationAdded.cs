namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTableDealerRelationAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.USER_DEALER_RELATION", "USER_TABLE_user_auto", c => c.Long());
            CreateIndex("dbo.USER_DEALER_RELATION", "USER_TABLE_user_auto");
            AddForeignKey("dbo.USER_DEALER_RELATION", "USER_TABLE_user_auto", "dbo.USER_TABLE", "user_auto");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.USER_DEALER_RELATION", "USER_TABLE_user_auto", "dbo.USER_TABLE");
            DropIndex("dbo.USER_DEALER_RELATION", new[] { "USER_TABLE_user_auto" });
            DropColumn("dbo.USER_DEALER_RELATION", "USER_TABLE_user_auto");
        }
    }
}
