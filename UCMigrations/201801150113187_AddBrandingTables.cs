namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBrandingTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationStyles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IdentityCSSFile = c.String(),
                        UCCSSFile = c.String(),
                        UCUICSSFile = c.String(),
                        GETCSSFile = c.String(),
                        GETUICSSFile = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DealershipBranding",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DealershipId = c.Int(nullable: false),
                        ApplicationStyleId = c.Int(nullable: false),
                        DealershipLogo = c.Binary(),
                        IdentityHost = c.String(maxLength: 450),
                        UCHost = c.String(maxLength: 450),
                        UCUIHost = c.String(maxLength: 450),
                        GETHost = c.String(maxLength: 450),
                        GETUIHost = c.String(maxLength: 450),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationStyles", t => t.ApplicationStyleId, cascadeDelete: true)
                .ForeignKey("dbo.Dealerships", t => t.DealershipId, cascadeDelete: true)
                .Index(t => t.DealershipId)
                .Index(t => t.ApplicationStyleId)
                .Index(t => t.IdentityHost, unique: true)
                .Index(t => t.UCHost, unique: true)
                .Index(t => t.UCUIHost, unique: true)
                .Index(t => t.GETHost, unique: true)
                .Index(t => t.GETUIHost, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DealershipBranding", "DealershipId", "dbo.Dealerships");
            DropForeignKey("dbo.DealershipBranding", "ApplicationStyleId", "dbo.ApplicationStyles");
            DropIndex("dbo.DealershipBranding", new[] { "GETUIHost" });
            DropIndex("dbo.DealershipBranding", new[] { "GETHost" });
            DropIndex("dbo.DealershipBranding", new[] { "UCUIHost" });
            DropIndex("dbo.DealershipBranding", new[] { "UCHost" });
            DropIndex("dbo.DealershipBranding", new[] { "IdentityHost" });
            DropIndex("dbo.DealershipBranding", new[] { "ApplicationStyleId" });
            DropIndex("dbo.DealershipBranding", new[] { "DealershipId" });
            DropTable("dbo.DealershipBranding");
            DropTable("dbo.ApplicationStyles");
        }
    }
}
