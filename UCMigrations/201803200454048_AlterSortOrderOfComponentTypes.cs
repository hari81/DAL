namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterSortOrderOfComponentTypes : DbMigration
    {
        public override void Up()
        {
            Sql(@"update LU_COMPART_TYPE set sorder=4 where comparttype_auto=233
update LU_COMPART_TYPE set sorder=5 where comparttype_auto=236
update LU_COMPART_TYPE set sorder=6 where comparttype_auto=237
update LU_COMPART_TYPE set sorder=7 where comparttype_auto=240
update LU_COMPART_TYPE set sorder=8 where comparttype_auto=234
update LU_COMPART_TYPE set sorder=9 where comparttype_auto=235
");
        }
        
        public override void Down()
        {
        }
    }
}
