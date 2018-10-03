namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnToComponentRecords : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WSREComponentRecords", "RemainingLife", c => c.Int(nullable: false));
            CreateIndex("dbo.GENERAL_EQ_UNIT", "make_auto");
            AddForeignKey("dbo.GENERAL_EQ_UNIT", "make_auto", "dbo.MAKE", "make_auto");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GENERAL_EQ_UNIT", "make_auto", "dbo.MAKE");
            DropIndex("dbo.GENERAL_EQ_UNIT", new[] { "make_auto" });
            DropColumn("dbo.WSREComponentRecords", "RemainingLife");
        }
    }
}
