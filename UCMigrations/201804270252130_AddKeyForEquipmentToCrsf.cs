namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKeyForEquipmentToCrsf : DbMigration
    {
        public override void Up()
        {
            // Set all equipment at non existant jobsites to be at the unknown jobsite. 
            Sql(@"declare @jobsiteId BIGINT
select TOP 1 @jobsiteId = crsf_auto from CRSF where site_name like '%Unknown%' or site_name like '%UNKNOWN%' or site_name like '%unknown%'
update equipment set crsf_auto = @jobsiteId where crsf_auto not in (select crsf_auto from CRSF)");

            CreateIndex("dbo.EQUIPMENT", "crsf_auto");
            AddForeignKey("dbo.EQUIPMENT", "crsf_auto", "dbo.CRSF", "crsf_auto", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EQUIPMENT", "crsf_auto", "dbo.CRSF");
            DropIndex("dbo.EQUIPMENT", new[] { "crsf_auto" });
        }
    }
}
