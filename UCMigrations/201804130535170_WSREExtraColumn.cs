namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WSREExtraColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LU_Module_Sub", "Make_make_auto", c => c.Int());
            AddColumn("dbo.LU_Module_Sub", "Model_model_auto", c => c.Int());
            AddColumn("dbo.WSREs", "SystemLife", c => c.Int(nullable: false));
            CreateIndex("dbo.LU_Module_Sub", "Make_make_auto");
            CreateIndex("dbo.LU_Module_Sub", "Model_model_auto");
            AddForeignKey("dbo.LU_Module_Sub", "Make_make_auto", "dbo.MAKE", "make_auto");
            AddForeignKey("dbo.LU_Module_Sub", "Model_model_auto", "dbo.MODEL", "model_auto");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LU_Module_Sub", "Model_model_auto", "dbo.MODEL");
            DropForeignKey("dbo.LU_Module_Sub", "Make_make_auto", "dbo.MAKE");
            DropIndex("dbo.LU_Module_Sub", new[] { "Model_model_auto" });
            DropIndex("dbo.LU_Module_Sub", new[] { "Make_make_auto" });
            DropColumn("dbo.WSREs", "SystemLife");
            DropColumn("dbo.LU_Module_Sub", "Model_model_auto");
            DropColumn("dbo.LU_Module_Sub", "Make_make_auto");
        }
    }
}
