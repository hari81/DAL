namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FamilyColumnAddedToAdditionalTable : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", "FamilyId", c => c.Int());
            //CreateIndex("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", "FamilyId");
            //AddForeignKey("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", "FamilyId", "dbo.TYPE", "type_auto");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", "FamilyId", "dbo.TYPE");
            //DropIndex("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", new[] { "FamilyId" });
            //DropColumn("dbo.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL", "FamilyId");
        }
    }
}
