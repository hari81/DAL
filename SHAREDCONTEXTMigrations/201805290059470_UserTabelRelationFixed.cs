namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTabelRelationFixed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.USER_DEALERGROUP_RELATION", "USER_TABLE_user_auto1", "dbo.USER_TABLE");
            DropIndex("dbo.USER_DEALERGROUP_RELATION", new[] { "USER_TABLE_user_auto1" });
            DropColumn("dbo.USER_DEALERGROUP_RELATION", "USER_TABLE_user_auto1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.USER_DEALERGROUP_RELATION", "USER_TABLE_user_auto1", c => c.Long());
            CreateIndex("dbo.USER_DEALERGROUP_RELATION", "USER_TABLE_user_auto1");
            AddForeignKey("dbo.USER_DEALERGROUP_RELATION", "USER_TABLE_user_auto1", "dbo.USER_TABLE", "user_auto");
        }
    }
}
