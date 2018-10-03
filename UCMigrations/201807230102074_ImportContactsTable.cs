namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImportContactsTable : DbMigration
    {
        public override void Up()
        {
            /*CreateTable(
                "dbo.CONTACTS",
                c => new
                    {
                        equipmentid_auto = c.Long(nullable: false),
                        customer_auto = c.Long(nullable: false),
                        user_auto = c.Long(nullable: false),
                        Type = c.String(nullable: false, maxLength: 20, unicode: false),
                        crsf_auto = c.Long(nullable: false),
                        EvalA = c.Boolean(nullable: false),
                        EvalB = c.Boolean(nullable: false),
                        EvalC = c.Boolean(nullable: false),
                        EvalX = c.Boolean(nullable: false),
                        wty_letter = c.Boolean(nullable: false),
                        modified_date = c.DateTime(),
                        modified_user = c.Long(),
                        service = c.Boolean(nullable: false),
                        eq_health = c.Boolean(nullable: false),
                        eq_undercarriage = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.equipmentid_auto, t.customer_auto, t.user_auto, t.Type, t.crsf_auto });*/
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.CONTACTS");
        }
    }
}
