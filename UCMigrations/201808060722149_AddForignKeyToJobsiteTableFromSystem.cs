namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForignKeyToJobsiteTableFromSystem : DbMigration
    {
        public override void Up()
        {
            Sql("update lu_module_sub set crsf_auto=NULL where crsf_auto not in (select crsf_auto from CRSF)");
            CreateIndex("dbo.LU_Module_Sub", "crsf_auto");
            AddForeignKey("dbo.LU_Module_Sub", "crsf_auto", "dbo.CRSF", "crsf_auto");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LU_Module_Sub", "crsf_auto", "dbo.CRSF");
            DropIndex("dbo.LU_Module_Sub", new[] { "crsf_auto" });
        }
    }
}
