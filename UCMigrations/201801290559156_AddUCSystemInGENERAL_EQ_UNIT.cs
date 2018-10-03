namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUCSystemInGENERAL_EQ_UNIT : DbMigration
    {
        public override void Up()
        {
            // Not able to apply these changes because Index and foreign key already exist!
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
