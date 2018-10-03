namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComponentsListIsAddedToEquipmentTable : DbMigration
    {
        public override void Up()
        {
            //CreateIndex("dbo.GENERAL_EQ_UNIT", "equipmentid_auto");
            //AddForeignKey("dbo.GENERAL_EQ_UNIT", "equipmentid_auto", "dbo.EQUIPMENT", "equipmentid_auto");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.GENERAL_EQ_UNIT", "equipmentid_auto", "dbo.EQUIPMENT");
            //DropIndex("dbo.GENERAL_EQ_UNIT", new[] { "equipmentid_auto" });
        }
    }
}
