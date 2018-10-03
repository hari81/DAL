namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableForLinksConditionUC2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LU_LINKS_CONDITION", newName: "LuLinksConditions");
            AlterColumn("dbo.LuLinksConditions", "Condition", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LuLinksConditions", "Condition", c => c.String(maxLength: 100, unicode: false));
            RenameTable(name: "dbo.LuLinksConditions", newName: "LU_LINKS_CONDITION");
        }
    }
}
