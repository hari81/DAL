namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableForLinksConditionUC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LU_LINKS_CONDITION",
                c => new
                    {
                        ConditionId = c.Long(nullable: false, identity: true),
                        Condition = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ConditionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LU_LINKS_CONDITION");
        }
    }
}
