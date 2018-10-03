namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_repairer_workshop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GET_REPAIRER",
                c => new
                    {
                        repairer_auto = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        customer = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.repairer_auto)
                .ForeignKey("dbo.CUSTOMER", t => t.customer, cascadeDelete: false)
                .Index(t => t.customer);
            
            CreateTable(
                "dbo.GET_WORKSHOP",
                c => new
                    {
                        workshop_auto = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        repairer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.workshop_auto)
                .ForeignKey("dbo.GET_REPAIRER", t => t.repairer, cascadeDelete: false)
                .Index(t => t.repairer);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GET_WORKSHOP", "repairer", "dbo.GET_REPAIRER");
            DropForeignKey("dbo.GET_REPAIRER", "customer", "dbo.CUSTOMER");
            DropIndex("dbo.GET_WORKSHOP", new[] { "repairer" });
            DropIndex("dbo.GET_REPAIRER", new[] { "customer" });
            DropTable("dbo.GET_WORKSHOP");
            DropTable("dbo.GET_REPAIRER");
        }
    }
}
