namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEquipmentPhotoColumn : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Mbl_NewEquipment", "EquipmentPhoto", c => c.Binary());
        }
        
        public override void Down()
        {
            //DropColumn("dbo.Mbl_NewEquipment", "EquipmentPhoto");
        }
    }
}
