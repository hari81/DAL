namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GET_equipmentidauto_nullable : DbMigration
    {
        public override void Up()
        {
            // GET-31 Change has already been done in the GETContext
            //AddColumn("dbo.GET", "on_equipment", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.GET", "on_equipment");
        }
    }
}
