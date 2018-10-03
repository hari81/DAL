namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImportCurrency : DbMigration
    {
        public override void Up()
        {
            /*CreateTable(
                "dbo.CURRENCY",
                c => new
                    {
                        currency_auto = c.Int(nullable: false, identity: true),
                        currency_code = c.String(nullable: false, maxLength: 5, unicode: false),
                        currency_name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.currency_auto);*/
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.CURRENCY");
        }
    }
}
