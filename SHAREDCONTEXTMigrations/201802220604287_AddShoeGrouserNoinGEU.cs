namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShoeGrouserNoinGEU : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.GENERAL_EQ_UNIT", "ShoeGrouserNo", c => c.Int());
        }
        
        public override void Down()
        {
            //DropColumn("dbo.GENERAL_EQ_UNIT", "ShoeGrouserNo");
        }
    }
}
