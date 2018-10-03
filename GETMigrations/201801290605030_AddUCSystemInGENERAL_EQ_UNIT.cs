namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUCSystemInGENERAL_EQ_UNIT : DbMigration
    {
        public override void Up()
        {// Added in UCMigrations
            //CreateIndex("dbo.GENERAL_EQ_UNIT", "module_ucsub_auto");
            //AddForeignKey("dbo.GENERAL_EQ_UNIT", "module_ucsub_auto", "dbo.LU_Module_Sub", "Module_sub_auto");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.GENERAL_EQ_UNIT", "module_ucsub_auto", "dbo.LU_Module_Sub");
            //DropIndex("dbo.GENERAL_EQ_UNIT", new[] { "module_ucsub_auto" });
        }
    }
}
